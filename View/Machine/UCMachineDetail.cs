using CasinoCounterSystem.Controller;
using CasinoCounterSystem.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CasinoCounterSystem.View.Machine
{
    public partial class UCMachineDetail : UserControl
    {
        #region === Constantes & Campos ===
        private readonly MachineController machineController = new MachineController();
        private readonly CounterRecordController counterRecordController = new CounterRecordController();
        private int? selectRecordId;

        private int machineId;
        private decimal commissionRate = 0.50m;

        // Registro inicial 
        private static readonly DateTime InitialRecordDate = new DateTime(2006, 3, 14);
        #endregion

        #region === DTO de la grilla ===
        private class CounterRecordRow
        {
            public int CounterRecordId { get; set; }
            public DateTime Date { get; set; }
            public long InA { get; set; }
            public long OutB { get; set; }
            public decimal Total { get; set; }
            public decimal? InOut { get; set; }
            public decimal? Saldo { get; set; }
            public decimal? FaltaSobra { get; set; }
            public bool CanDelete { get; set; }
        }
        #endregion

        #region === Ctor ===
        public UCMachineDetail(int machineId, int? selectRecordId = null)
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.machineId = machineId;
            this.selectRecordId = selectRecordId;
            LoadMachineData();
        }
        #endregion

        #region === Carga principal (Orquestador) ===
        private void LoadMachineData()
        {
            var machine = FetchMachineAndPaintHeader();
            var rows = BuildRows(machine);
            ConfigureGridTheme();
            BuildGridColumns();
            BindRows(rows);
            WireGridEvents();
            SelectAndScrollToRecord();
        }

        private void SelectAndScrollToRecord()
        {
            if (!selectRecordId.HasValue) return;

            var list = dataGridView1.DataSource as System.Collections.Generic.IList<CounterRecordRow>;
            if (list == null) return;

            int idx = -1;
            for (int i = 0; i < list.Count; i++)
                if (list[i].CounterRecordId == selectRecordId.Value) { idx = i; break; }

            if (idx < 0 || idx >= dataGridView1.Rows.Count) return;

            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = dataGridView1.Rows[idx].Cells[0];
            dataGridView1.Rows[idx].Selected = true;
            try { dataGridView1.FirstDisplayedScrollingRowIndex = idx; } catch {}

        }
        #endregion

        #region === Traer máquina y pintar header ===
        private Model.Machine? FetchMachineAndPaintHeader()
        {
            var machine = machineController.GetMachineById(machineId);
            if (machine == null) return null;

            lblMachineNumber.Text = machine.NumberMachine;
            lblTypeMachine.Text = machine.TypeMachine?.NameTypeMachine ?? machine.TypeMachineId.ToString();
            lblCoinType.Text = machine.CoinType?.NumCoin != null
                                ? $"${machine.CoinType.NumCoin}"
                                : machine.CoinTypeId.ToString();
            return machine;
        }
        #endregion

        #region === Construir filas con cálculos ===
        private List<CounterRecordRow> BuildRows(Model.Machine? machine)
        {
            // Valor de moneda (fallback = 1)
            decimal coinValue = 1m;
            if (machine?.CoinType?.NumCoin != null)
                coinValue = Convert.ToDecimal(machine.CoinType.NumCoin);

            // Registros ASC por fecha para comparar con el anterior
            var records = counterRecordController
                            .GetCounterRecordsByMachine(machineId)
                            .OrderBy(r => r.RecordDate)
                            .ToList();

            var rows = new List<CounterRecordRow>();

            for (int i = 0; i < records.Count; i++)
            {
                var cur = records[i];

                var row = new CounterRecordRow
                {
                    CounterRecordId = cur.CounterRecordId,
                    Date = cur.RecordDate,
                    InA = cur.CounterIn,
                    OutB = cur.CounterOut,
                    Total = cur.TotalDelivered
                };

                if (i > 0)
                {
                    var prev = records[i - 1];
                    long deltaIn = cur.CounterIn - prev.CounterIn;
                    long deltaOut = cur.CounterOut - prev.CounterOut;
                    long units = deltaIn - deltaOut;

                    decimal inOutMoney = units * coinValue;

                    row.InOut = Math.Round(inOutMoney, 2, MidpointRounding.AwayFromZero);
                    row.Saldo = Math.Round(cur.TotalDelivered * commissionRate, 2, MidpointRounding.AwayFromZero);
                    row.FaltaSobra = Math.Round(cur.TotalDelivered - inOutMoney, 2, MidpointRounding.AwayFromZero);
                }
                else
                {
                    // Registro inicial: sin comparación
                    row.InOut = null;
                    row.Saldo = null;
                    row.FaltaSobra = null;
                }

                // Regla de borrado: NO se borra si es 14/03/2006
                row.CanDelete = row.Date.Date != InitialRecordDate.Date;

                rows.Add(row);
            }

            // Si querés ver el más reciente primero: rows.Reverse();
            return rows;
        }
        #endregion

        #region === Tema/estilo del grid ===
        private void ConfigureGridTheme()
        {
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Britannic Bold", 12F, FontStyle.Regular);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 8, 0, 8);
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.FromArgb(220, 225, 235);

            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.RowsDefaultCellStyle.ForeColor = Color.FromArgb(45, 55, 75);
            dataGridView1.RowsDefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dataGridView1.RowsDefaultCellStyle.Padding = new Padding(8, 6, 8, 6);

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 252);
            dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(45, 55, 75);
            dataGridView1.AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dataGridView1.AlternatingRowsDefaultCellStyle.Padding = new Padding(8, 6, 8, 6);

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 245, 250);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(45, 55, 75);

            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;

            // Propiedad de Sunny.UI
            dataGridView1.RectColor = Color.Navy;

            dataGridView1.ShowCellToolTips = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
        }
        #endregion

        #region === Construcción de columnas ===
        private void BuildGridColumns()
        {
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CounterRecordRow.Date),
                HeaderText = "DATE",
                Width = 122,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CounterRecordRow.InA),
                HeaderText = "IN (A)",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CounterRecordRow.OutB),
                HeaderText = "OUT (B)",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CounterRecordRow.InOut),
                HeaderText = "IN-OUT",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0"
                }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CounterRecordRow.Total),
                HeaderText = "TOTAL",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0"
                }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CounterRecordRow.Saldo),
                HeaderText = "SALDO",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0",
                    BackColor = Color.LightYellow
                }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CounterRecordRow.FaltaSobra),
                HeaderText = "FALTA/SOBRA",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0",
                    BackColor = Color.MistyRose
                }
            });

            var colEdit = new DataGridViewButtonColumn
            {
                Name = "colEdit",
                HeaderText = "",
                Width = 54,
                FlatStyle = FlatStyle.Flat,
                UseColumnTextForButtonValue = true,
                Text = "✎",
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            colEdit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEdit.DefaultCellStyle.Font = new Font("Segoe UI Symbol", 12F);
            colEdit.DefaultCellStyle.ForeColor = Color.Navy;
            colEdit.DefaultCellStyle.BackColor = Color.FromArgb(240, 245, 250);
            colEdit.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 245, 250);
            colEdit.DefaultCellStyle.SelectionForeColor = Color.Navy;
            dataGridView1.Columns.Add(colEdit);

            var colDelete = new DataGridViewButtonColumn
            {
                Name = "colDelete",
                HeaderText = "",
                Width = 54,
                FlatStyle = FlatStyle.Flat,
                UseColumnTextForButtonValue = true,
                Text = "🗑️",
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            colDelete.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDelete.DefaultCellStyle.Font = new Font("Segoe UI Symbol", 12F);
            colDelete.DefaultCellStyle.ForeColor = Color.FromArgb(180, 50, 50);
            colDelete.DefaultCellStyle.BackColor = Color.FromArgb(250, 240, 240);
            colDelete.DefaultCellStyle.SelectionBackColor = Color.FromArgb(250, 240, 240);
            colDelete.DefaultCellStyle.SelectionForeColor = Color.FromArgb(180, 50, 50);
            dataGridView1.Columns.Add(colDelete);
        }
        #endregion

        #region === Enlazar datos & eventos ===
        private void BindRows(List<CounterRecordRow> rows)
        {
            dataGridView1.DataSource = rows;
        }

        private void WireGridEvents()
        {
            dataGridView1.CellFormatting -= DataGridView1_CellFormatting;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;

            dataGridView1.CellClick -= DataGridView1_CellClick;
            dataGridView1.CellClick += DataGridView1_CellClick;
        }
        #endregion

        #region === Handlers ===
        private void DataGridView1_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridView1.Columns[e.ColumnIndex];

            if (col.DataPropertyName == nameof(CounterRecordRow.FaltaSobra) && e.Value is decimal val)
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Style.ForeColor = val < 0 ? Color.Red : (val > 0 ? Color.Green : Color.Black);
            }

            if (col.Name == "colDelete")
            {
                var row = dataGridView1.Rows[e.RowIndex].DataBoundItem as CounterRecordRow;
                if (row != null && !row.CanDelete)
                {
                    e.Value = ""; // sin ícono
                    var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.Style.ForeColor = Color.Silver;
                    cell.Style.BackColor = Color.FromArgb(245, 245, 245);
                    e.FormattingApplied = true;
                }
            }
        }

        private void DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var colName = dataGridView1.Columns[e.ColumnIndex].Name;
            var row = dataGridView1.Rows[e.RowIndex].DataBoundItem as CounterRecordRow;
            if (row == null) return;

            if (colName == "colEdit")
            {
                int id = row.CounterRecordId;

                var frm = new FrmCounterRecord(id); // 👈 abre en modo edición
                frm.RecordSaved += (s, ev) =>
                {
                    // refrescar lista y resaltar el actualizado
                    this.selectRecordId = ev.NewRecordId;  // para el scroll
                    LoadMachineData();
                };
                frm.Show(this.FindForm()); // modeless, mantén el detalle visible
                return;
            }


            if (colName == "colDelete")
            {
                if (!row.CanDelete) return;

                var confirm = MessageBox.Show(
                    $"¿Eliminar el registro del {row.Date:dd/MM/yyyy}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (confirm != DialogResult.Yes) return;

                try
                {
                    bool ok = counterRecordController.DeleteCounterRecord(row.CounterRecordId);
                    if (ok) LoadMachineData();
                    else MessageBox.Show("No se pudo eliminar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
