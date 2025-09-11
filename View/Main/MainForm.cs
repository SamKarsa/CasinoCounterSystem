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
                // Aquí puedes mostrar un mensaje de éxito y volver al Home
                MessageBox.Show("Machine created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Aquí puedes mostrar un mensaje de éxito y volver al Home
                MessageBox.Show("Route created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            FrmCounterRecord frmCounterRecord = new FrmCounterRecord();
            frmCounterRecord.Show();
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
                        // Reemplaza este MessageBox por tu UCMachineDetail/Editor si lo tienes
                        MessageBox.Show(
                            $"Machine: {m.NumberMachine}\nRouteId: {m.RouteId}\nCliente: {m.InfoMachine?.NameClient ?? "-"}",
                            "Machine Info",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
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
    }
}
