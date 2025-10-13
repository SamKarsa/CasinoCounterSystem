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
        
        private readonly MachineController machineController = new MachineController();
        private readonly CounterRecordController counterRecordController = new CounterRecordController();
        private int? selectRecordId;
        private int machineId;
        private decimal commissionRate = 0.50m;
        private static readonly DateTime InitialRecordDate = new DateTime(2006, 3, 14);
       
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
            public bool IsInitial { get; set; }
        }

        public UCMachineDetail(int machineId, int? selectRecordId = null)
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.machineId = machineId;
            this.selectRecordId = selectRecordId;
            LoadMachineData();
        }

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

        private List<CounterRecordRow> BuildRows(Model.Machine? machine)
        {
            decimal coinValue = 1m;
            if (machine?.CoinType?.NumCoin != null)
                coinValue = Convert.ToDecimal(machine.CoinType.NumCoin);

            // 2) Detectar si la máquina es Poker (robusto contra mayúsculas/espacios)
            bool isPoker = false;
            var typeName = machine?.TypeMachine?.NameTypeMachine;
            if (!string.IsNullOrWhiteSpace(typeName))
                isPoker = typeName.Trim().Equals("Poker", StringComparison.OrdinalIgnoreCase);

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
                    Total = cur.TotalDelivered,
                    IsInitial = (cur.RecordDate.Date == InitialRecordDate.Date)
                };

                if (i > 0)
                {
                    var prev = records[i - 1];
                    long deltaIn = cur.CounterIn - prev.CounterIn;
                    long deltaOut = cur.CounterOut - prev.CounterOut;

                    decimal inOutMoney;


                    if (isPoker)
                    {
                        inOutMoney = deltaOut * coinValue;
                    }
                    else
                    {
                        long units = deltaIn - deltaOut;
                        inOutMoney = units * coinValue;
                    }

                    row.InOut = Math.Round(inOutMoney, 2, MidpointRounding.AwayFromZero);
                    row.Saldo = Math.Round(cur.TotalDelivered * commissionRate, 2, MidpointRounding.AwayFromZero);
                    row.FaltaSobra = Math.Round(cur.TotalDelivered - inOutMoney, 2, MidpointRounding.AwayFromZero);
                }
                else
                {

                    row.InOut = null;
                    row.Saldo = null;
                    row.FaltaSobra = null;
                }

                row.CanDelete = row.Date.Date != InitialRecordDate.Date;

                rows.Add(row);
            }

            return rows;
        }
      
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
            dataGridView1.RectColor = Color.Navy;
            dataGridView1.ShowCellToolTips = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;

            dataGridView1.ScrollBars = ScrollBars.Vertical;
        }
         
        private void BuildGridColumns()
        {
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CounterRecordRow.Date),
                HeaderText = "Fecha",
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
                HeaderText = "Total",
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
                HeaderText = "Saldo",
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
                HeaderText = "Falta/Sobra",
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
                FlatStyle = FlatStyle.Flat,
                UseColumnTextForButtonValue = true,
                Text = "✎",
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, 
                MinimumWidth = 40,                                   
                FillWeight = 50
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
                FlatStyle = FlatStyle.Flat,
                UseColumnTextForButtonValue = true,
                Text = "🗑️",
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                MinimumWidth = 40,
                FillWeight = 50
            };
            colDelete.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDelete.DefaultCellStyle.Font = new Font("Segoe UI Symbol", 12F);
            colDelete.DefaultCellStyle.ForeColor = Color.FromArgb(180, 50, 50);
            colDelete.DefaultCellStyle.BackColor = Color.FromArgb(250, 240, 240);
            colDelete.DefaultCellStyle.SelectionBackColor = Color.FromArgb(250, 240, 240);
            colDelete.DefaultCellStyle.SelectionForeColor = Color.FromArgb(180, 50, 50);
            dataGridView1.Columns.Add(colDelete);
        }
           
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

        private void DataGridView1_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            // Cabeceras / índices inválidos
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dataGridView1.Columns[e.ColumnIndex];
            var row = dataGridView1.Rows[e.RowIndex];
            var rowObj = row.DataBoundItem as CounterRecordRow;
            if (rowObj == null) return; // rebindings/transiciones

            bool isInitial = rowObj.Date.Date == InitialRecordDate.Date;

            // ---------- Fila inicial: “ocultar” algunas celdas por estilo ----------
            if (isInitial)
            {
                // Fondo sutil para toda la fila
                row.DefaultCellStyle.BackColor = Color.FromArgb(245, 248, 252);
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 240, 246);

                // En la fila inicial, NO mostrar Date / InOut / Total / Saldo / FaltaSobra
                if (col.DataPropertyName == nameof(CounterRecordRow.Date) ||
                    col.DataPropertyName == nameof(CounterRecordRow.InOut) ||
                    col.DataPropertyName == nameof(CounterRecordRow.Total) ||
                    col.DataPropertyName == nameof(CounterRecordRow.Saldo) ||
                    col.DataPropertyName == nameof(CounterRecordRow.FaltaSobra))
                {
                    // Hacemos el texto del mismo color que el fondo => “invisible”
                    e.CellStyle.ForeColor = row.DefaultCellStyle.BackColor;
                    e.CellStyle.SelectionForeColor = row.DefaultCellStyle.BackColor;
                    e.CellStyle.Format = null; // sin formato especial
                    return; // ya aplicamos estilo, salimos
                }
            }

            // ---------- Colorizar Falta/Sobra (solo si no es la fila inicial) ----------
            if (!isInitial &&
                col.DataPropertyName == nameof(CounterRecordRow.FaltaSobra) &&
                e.Value is decimal val)
            {
                e.CellStyle.ForeColor = val < 0 ? Color.Red : (val > 0 ? Color.Green : Color.Black);
            }

            // ---------- Botón borrar deshabilitado visualmente cuando no se puede ----------
            if (col.Name == "colDelete")
            {
                if (!rowObj.CanDelete)
                {
                    // NO cambiar e.Value (evita reentradas). Solo estilo "apagado".
                    e.CellStyle.ForeColor = Color.Silver;
                    e.CellStyle.BackColor = Color.FromArgb(245, 245, 245);
                    e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
                    e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
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

                var frm = new FrmCounterRecord(id); 
                frm.RecordSaved += (s, ev) =>
                {
   
                    this.selectRecordId = ev.NewRecordId;  
                    LoadMachineData();
                };
                frm.ShowDialog(this.FindForm()); 
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
        
    }
}
