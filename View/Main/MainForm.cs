using CasinoCounterSystem.View.Home;
using CasinoCounterSystem.View.Machine;
using CasinoCounterSystem.View.Route;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CasinoCounterSystem.Controller;
using CasinoCounterSystem.Model;

namespace CasinoCounterSystem.View
{
    public partial class MainForm : Form
    {

        private UCHome ucHome;
        private UITreeView routeTree;
        private readonly RouteController routeController = new RouteController();
        private readonly MachineController machineController = new MachineController();


        private ContextMenuStrip treeMenu;
        private ToolStripMenuItem miEdit;
        private ToolStripMenuItem miDelete;

        public MainForm()
        {
            InitializeComponent();

            // SOLO esta línea
            this.AutoScaleMode = AutoScaleMode.None;

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Crear instancia de UCHome y suscribirse a sus eventos
            ucHome = new UCHome();
            ucHome.AddMachineClicked += UcHome_AddMachineClicked!;
            ucHome.AddRouteClicked += UcHome_AddRouteClicked!;

            // Suscribir evento al botón Home del sidebar
            btnHome.Click += BtnHome_Click!;

            // Crear el UITreeView en el sidebar (debajo de los botones)
            BuildRouteTreeInSidebar();

            BuildTreeContextMenu();
            ApplyRolePermissionsToTreeMenu();
            routeTree.NodeMouseClick += RouteTree_NodeMouseClick!;

            // Cargar la vista Home inicial
            LoadView(ucHome);

            // Cargar el árbol de Rutas → Máquinas
            LoadRoutesTree();
        }

        private void UcHome_AddMachineClicked(object sender, EventArgs e)
        {
            // Crear instancia de UCMachineCreate y suscribirse a sus eventos
            var ucMachineCreate = new UCMachineCreate();
            ucMachineCreate.CancelClicked += (s, args) => LoadView(ucHome);
            ucMachineCreate.MachineCreated += (s, args) =>
            {
                LoadRoutesTree();

                LoadView(ucHome);
            };

            LoadView(ucMachineCreate);
        }

        private void UcHome_AddRouteClicked(object sender, EventArgs e)
        {
            // Crear instancia de UCRouteCreate y suscribirse a sus eventos
            var ucRouteCreate = new UCRouteCreate();
            ucRouteCreate.CancelClicked += (s, args) => LoadView(ucHome);
            ucRouteCreate.RouteCreated += (s, args) =>
            {
                LoadRoutesTree();

                LoadView(ucHome);
            };

            LoadView(ucRouteCreate);
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            // Volver a la vista Home
            LoadView(ucHome);
        }

        private void btnRegisterCounters_Click(object sender, EventArgs e)
        {
            var frmCounterRecord = new FrmCounterRecord();


            frmCounterRecord.RecordSaved += (s, args) =>
            {

                LoadRoutesTree();


                var ucDetail = new UCMachineDetail(args.MachineId, selectRecordId: args.NewRecordId);
                LoadView(ucDetail);
            };

            // Mostrar modeless para que quede abierto
            frmCounterRecord.Show(this);
        }

        private void LoadView(UserControl uc)
        {
            panelRight.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelRight.Controls.Add(uc);
        }

        private void BuildRouteTreeInSidebar()
        {
            routeTree = new UITreeView
            {
                Name = "routeTree",
                ShowLines = true,
                Font = new Font("Microsoft Sans Serif", 10F),

                // Estética para combinar con el sidebar azul
                FillColor = Color.Navy,
                ForeColor = Color.White,
                HoverColor = Color.FromArgb(40, 40, 120),
                RectColor = Color.Navy
            };

            // Ubicación: debajo de lineBtnRegisterCounter
            int y = lineBtnRegisterCounter.Location.Y + 24;
            routeTree.Location = new Point(12, y);
            routeTree.Size = new Size(222, sidebarPanel.Height - y - 80);
            routeTree.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;

            routeTree.AfterSelect += RouteTree_AfterSelect;

            sidebarPanel.Controls.Add(routeTree);
        }

        private void LoadRoutesTree()
        {
            routeTree.Nodes.Clear();

            var routes = routeController.GetAllRoutes();
            foreach (var route in routes)
            {
                // Nodo de ruta
                var routeNode = new TreeNode
                {
                    Text = $"📂 {route.RouteName}",
                    Tag = new NodeTag { Type = NodeType.Route, Id = route.RouteId }
                };

                // Hijos: máquinas por ruta
                var machines = machineController.GetMachinesByRoute(route.RouteId);
                foreach (var m in machines)
                {
                    var label = string.IsNullOrWhiteSpace(m.NumberMachine)
                        ? $"Machine {m.MachineId}"
                        : m.NumberMachine;

                    var machineNode = new TreeNode
                    {
                        Text = $"🎰 {label}",
                        Tag = new NodeTag { Type = NodeType.Machine, Id = m.MachineId }
                    };

                    routeNode.Nodes.Add(machineNode);
                }

                routeTree.Nodes.Add(routeNode);
            }

            routeTree.ExpandAll(); // opcional
        }

        private void RouteTree_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is not NodeTag tag) return;

            switch (tag.Type)
            {
                case NodeType.Route:
                    // Aquí podrías cargar un UserControl con listado/resumen de esa ruta
                    // var uc = new UCRouteList(tag.Id);
                    // LoadView(uc);
                    break;

                case NodeType.Machine:
                    // Ejemplo: mostrar info rápida o cargar un detalle en panelRight
                    var m = machineController.GetMachineById(tag.Id);
                    if (m != null)
                    {
                        var ucDetail = new UCMachineDetail(tag.Id);
                        LoadView(ucDetail);
                        break;
                    }
                    break;
            }
        }

        private enum NodeType { Route, Machine }

        private class NodeTag
        {
            public NodeType Type { get; set; }
            public int Id { get; set; }
        }

        private void BuildTreeContextMenu()
        {
            treeMenu = new ContextMenuStrip();
            miEdit = new ToolStripMenuItem("✏️ Edit");
            miDelete = new ToolStripMenuItem("🗑️ Delete");
            treeMenu.Items.AddRange(new ToolStripItem[] { miEdit, miDelete });

            miEdit.Click += (s, e) => EditSelectedNode();
            miDelete.Click += (s, e) => DeleteSelectedNode();
        }

        private void RouteTree_NodeMouseClick(object? sender, TreeNodeMouseClickEventArgs e)
        {
            if (!SessionManager.IsAdmin) return;
            if (e.Button != MouseButtons.Right) return;

            routeTree.SelectedNode = e.Node;
            if (e.Node?.Tag is not NodeTag tag) return;

            // Habilitar/Deshabilitar "Delete" según reglas
            if (tag.Type == NodeType.Route)
            {
                var machines = machineController.GetMachinesByRoute(tag.Id);
                miDelete.Enabled = machines.Count == 0; // Ruta solo si NO tiene máquinas
            }
            else
            {
                miDelete.Enabled = true; // Máquina: validamos adentro por contadores
            }

            treeMenu.Show(routeTree, e.Location);
        }

        private void EditSelectedNode()
        {
            if (routeTree.SelectedNode?.Tag is not NodeTag tag) return;

            if (tag.Type == NodeType.Route)
            {
                var uc = new View.Route.UCRouteCreate();
                uc.InitEditMode(tag.Id);
                uc.CancelClicked += (s, e) => LoadView(ucHome);
                uc.RouteUpdated += (s, e) => { LoadRoutesTree(); LoadView(ucHome); };
                LoadView(uc);
            }
            else if (tag.Type == NodeType.Machine)
            {
                OpenMachineEditor(tag.Id);
            }
        }

        private void OpenMachineEditor(int machineId)
        {
            var uc = new View.Machine.UCMachineCreate();
            uc.InitEditMode(machineId);
            uc.CancelClicked += (s, e) => LoadView(ucHome);
            uc.MachineUpdated += (s, e) =>
            {
                LoadRoutesTree();

                // Refrescar panel derecho con el detalle de la máquina editada
                var detail = new UCMachineDetail(machineId);
                LoadView(detail);
            };
            LoadView(uc);
        }

        private void DeleteSelectedNode()
        {
            if (routeTree.SelectedNode?.Tag is not NodeTag tag) return;

            if (tag.Type == NodeType.Route)
            {
                // Seguridad: solo si no tiene máquinas
                var machines = machineController.GetMachinesByRoute(tag.Id);
                if (machines.Count > 0)
                {
                    MessageBox.Show("This route has machines assigned. Move them or delete them first.",
                                    "Cannot delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show("Delete this route?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;

                var ok = routeController.DeleteRoute(tag.Id);
                if (ok) LoadRoutesTree();
                else MessageBox.Show("Could not delete the route.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DeleteMachineFlow(tag.Id);
            }
        }

        private void DeleteMachineFlow(int machineId)
        {
            var crc = new CounterRecordController();
            var count = crc.CountByMachine(machineId);

            // Permitir borrar solo si no hay registros, o si existe SOLO el inicial
            bool canDelete = false;
            if (count == 0) canDelete = true;
            else if (count == 1)
            {
                var rec = crc.GetCounterRecordsByMachine(machineId).FirstOrDefault();
                if (rec != null && rec.RecordDate.Date == new DateTime(2006, 3, 14))
                    canDelete = true;
            }

            if (!canDelete)
            {
                MessageBox.Show("This machine has counter records. For safety, it cannot be deleted.",
                                "Cannot delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Delete this machine? This will also remove its initial counter record.",
                                          "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            // Borrar counters (si hay) y luego la máquina (evita violar FK)
            crc.DeleteAllByMachine(machineId);

            var ok = machineController.DeleteMachine(machineId);
            if (ok)
            {
                LoadRoutesTree();
                // Si el detalle de esta máquina estaba abierto, vuelve a Home
                LoadView(ucHome);
            }
            else
            {
                MessageBox.Show("Could not delete the machine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyRolePermissionsToTreeMenu()
        {
            bool canModify = SessionManager.IsAdmin;

            // Oculta/mostrar opciones del menú
            if (miEdit != null) miEdit.Visible = canModify;
            if (miDelete != null) miDelete.Visible = canModify;

            // Quita el menú contextual entero para operadores
            routeTree.ContextMenuStrip = canModify ? treeMenu : null;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Do you want to log out?",
                                          "Log out",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            
            foreach (Form owned in this.OwnedForms)
            {
                try { owned.Close(); } catch { }
            }

            
            this.Close();
        }

    }
}
