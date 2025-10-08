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
        private UITreeView routeTree = null!;
        private readonly RouteController routeController = new RouteController();
        private readonly MachineController machineController = new MachineController();


        private ContextMenuStrip treeMenu = null!;
        private ToolStripMenuItem miEdit = null!;
        private ToolStripMenuItem miDelete = null!;

        public MainForm()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            ucHome = new UCHome();
            ucHome.AddMachineClicked += UcHome_AddMachineClicked;
            ucHome.AddRouteClicked += UcHome_AddRouteClicked;
            btnHome.Click += BtnHome_Click;

            BuildRouteTreeInSidebar();
            BuildTreeContextMenu();
            ApplyRolePermissionsToTreeMenu();
            routeTree.NodeMouseClick += RouteTree_NodeMouseClick;

            LoadView(ucHome);
            LoadRoutesTree();
        }

        private void UcHome_AddMachineClicked(object? sender, EventArgs e)
        {

            var ucMachineCreate = new UCMachineCreate();
            ucMachineCreate.CancelClicked += (s, args) => LoadView(ucHome);
            ucMachineCreate.MachineCreated += (s, args) =>
            {
                LoadRoutesTree();

                LoadView(ucHome);
            };

            LoadView(ucMachineCreate);
        }

        private void UcHome_AddRouteClicked(object? sender, EventArgs e)
        {

            var ucRouteCreate = new UCRouteCreate();
            ucRouteCreate.CancelClicked += (s, args) => LoadView(ucHome);
            ucRouteCreate.RouteCreated += (s, args) =>
            {
                LoadRoutesTree();

                LoadView(ucHome);
            };

            LoadView(ucRouteCreate);
        }

        private void BtnHome_Click(object? sender, EventArgs e)
        {
            ClearTreeSelection();
            LoadView(ucHome);
        }

        private void ClearTreeSelection()
        {
            routeTree.SelectedNode = null;
            routeTree.Invalidate();
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
                FillColor = Color.Navy,
                ForeColor = Color.White,
                HoverColor = Color.FromArgb(20, 255, 255, 255),
                RectColor = Color.Navy,
                SelectedColor = Color.FromArgb(40, 255, 255, 255)
            };

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
                var routeNode = new TreeNode
                {
                    Text = $"📂 {route.RouteName}",
                    Tag = new NodeTag { Type = NodeType.Route, Id = route.RouteId }
                };

                var machines = machineController.GetMachinesByRoute(route.RouteId);
                foreach (var m in machines)
                {
                    var label = string.IsNullOrWhiteSpace(m.NumberMachine)
                        ? $"Maquina {m.MachineId}"
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

            routeTree.ExpandAll(); 
        }

        private void RouteTree_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is not NodeTag tag) return;

            switch (tag.Type)
            {
                case NodeType.Route:

                    break;
                case NodeType.Machine:
                   
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
            miEdit = new ToolStripMenuItem("✏️ Editar");
            miDelete = new ToolStripMenuItem("🗑️ Eliminar");
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

            if (tag.Type == NodeType.Route)
            {
                var machines = machineController.GetMachinesByRoute(tag.Id);
                miDelete.Enabled = machines.Count == 0; 
            }
            else
            {
                miDelete.Enabled = true; 
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
     
                var machines = machineController.GetMachinesByRoute(tag.Id);
                if (machines.Count > 0)
                {
                    MessageBox.Show("Esta ruta tiene máquinas asignadas. Muévelas o elimínalas primero.",
                                    "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show("¿Quieres eliminar esta ruta?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;

                var ok = routeController.DeleteRoute(tag.Id);
                if (ok) LoadRoutesTree();
                else MessageBox.Show("No se pudo eliminar la ruta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Esta máquina tiene registros de contadores. Por seguridad, no puede eliminarse.",
                                "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("¿Deseas eliminar esta máquina?",
                                          "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            crc.DeleteAllByMachine(machineId);

            var ok = machineController.DeleteMachine(machineId);
            if (ok)
            {
                LoadRoutesTree();
                LoadView(ucHome);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la máquina.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyRolePermissionsToTreeMenu()
        {
            bool canModify = SessionManager.IsAdmin;

            if (miEdit != null) miEdit.Visible = canModify;
            if (miDelete != null) miDelete.Visible = canModify;

            routeTree.ContextMenuStrip = canModify ? treeMenu : null;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Deseas cerrar sesión?",
                                          "Cerrar Sesión",
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
