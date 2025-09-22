using CasinoCounterSystem.Controller;
using CasinoCounterSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CasinoCounterSystem.View.Machine
{
    public partial class UCMachineDetail : UserControl
    {
        private readonly MachineController machineController = new MachineController();
        private readonly CounterRecordController counterRecordController = new CounterRecordController();
        private int machineId;
        private decimal commissionRate = 0.50m;

        public UCMachineDetail(int machineId)
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.machineId = machineId;

            LoadMachineData();
        }

        private class CounterRecordRow
        {
            public int CounterRecordId { get; set; }
            public DateTime Date { get; set; }

            // Originales
            public long InA { get; set; }
            public long OutB { get; set; }
            public decimal Total { get; set; }

            // Calculados (null en el primer registro)
            public decimal? InOut { get; set; }       // ((ΔIN - ΔOUT) * coinValue)
            public decimal? Saldo { get; set; }       // InOut * commissionRate
            public decimal? FaltaSobra { get; set; }  // Total - InOut
        }


        private void LoadMachineData()
        {
            var machine = machineController.GetMachineById(machineId);
            if (machine != null)
            {
                lblMachineNumber.Text = machine.NumberMachine;

                lblTypeMachine.Text = machine.TypeMachine?.NameTypeMachine
                                      ?? machine.TypeMachineId.ToString();

                // Solo para mostrar en pantalla
                lblCoinType.Text = machine.CoinType?.NumCoin != null
                                   ? $"${machine.CoinType.NumCoin}"
                                   : machine.CoinTypeId.ToString();
            }

            // 1) Traer registros y ordenar por fecha ASC para comparar contra el anterior
            var records = counterRecordController
                            .GetCounterRecordsByMachine(machineId)
                            .OrderBy(r => r.RecordDate)
                            .ToList();

            // 2) Valor de moneda (SIEMPRE estará, pero dejamos fallback por seguridad)
            decimal coinValue = 1m;
            if (machine?.CoinType?.NumCoin != null)
            {
                // Si NumCoin es int/long → conviértelo a decimal
                coinValue = Convert.ToDecimal(machine.CoinType.NumCoin);
            }

            // 3) Construir filas con cálculos contra el registro anterior
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
                    // Primer registro (inicial 14/03/2006): sin comparación
                    row.InOut = null;
                    row.Saldo = null;
                    row.FaltaSobra = null;
                }

                rows.Add(row);
            }

            // (Opcional) para ver el más reciente primero:
            // rows.Reverse();

            // 4) Configurar DataGridView

            // 4) Configurar DataGridView con estilo Navy moderno
            // Colócalo justo después del comentario "4) Configurar DataGridView" y antes de la configuración de columnas

            // Configuración básica
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;

            // Header con estilo Navy (sin bordes)
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 8, 0, 8);
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Configuración de celdas (con bordes horizontales sutiles)
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.FromArgb(220, 225, 235); // Gris azulado claro

            // Filas normales
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.RowsDefaultCellStyle.ForeColor = Color.FromArgb(45, 55, 75); // Gris azulado oscuro
            dataGridView1.RowsDefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dataGridView1.RowsDefaultCellStyle.Padding = new Padding(8, 6, 8, 6);

            // Filas alternas con azul muy suave
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 252);
            dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(45, 55, 75);
            dataGridView1.AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dataGridView1.AlternatingRowsDefaultCellStyle.Padding = new Padding(8, 6, 8, 6);

            // Selección muy suave que permite ver los colores de falta/sobra
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 245, 250); // Azul muy muy claro
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(45, 55, 75); // Mantiene el texto oscuro

            // Evitar que el header cambie de color al seleccionar
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Navy; // Mantiene Navy siempre
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White; // Mantiene blanco siempre

            // Configuraciones adicionales para mejor apariencia
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;

            // Ocultar header de filas (números) si no lo necesitas
            dataGridView1.RowHeadersVisible = false;

            // Configurar el borde del componente Sunny.UI
            dataGridView1.RectColor = Color.Navy;







            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.ReadOnly = true; // luego habilitas edición desde el botón
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToResizeColumns = false; // bloquea redimensionar columnas
            dataGridView1.AllowUserToResizeRows = false;    // bloquea redimensionar filas


            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CounterRecordRow.Date),
                HeaderText = "Date",
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

            // Columna EDITAR (emoji)
            var colEdit = new DataGridViewButtonColumn
            {
                Name = "colEdit",
                HeaderText = "",
                Width = 54,
                FlatStyle = FlatStyle.Popup,
                UseColumnTextForButtonValue = true,
                Text = "📝", // o "✏️"
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            colEdit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEdit.DefaultCellStyle.Font = new Font("Segoe UI Emoji", 10F);
            colEdit.ToolTipText = "Editar";
            dataGridView1.Columns.Add(colEdit);

            // Columna ELIMINAR (emoji)
            var colDelete = new DataGridViewButtonColumn
            {
                Name = "colDelete",
                HeaderText = "",
                Width = 54,
                FlatStyle = FlatStyle.Popup,
                UseColumnTextForButtonValue = true,
                Text = "🗑️",
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            colDelete.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDelete.DefaultCellStyle.Font = new Font("Segoe UI Emoji", 10F);
            colDelete.ToolTipText = "Eliminar";
            dataGridView1.Columns.Add(colDelete);


            // 5) Asignar datos
            dataGridView1.DataSource = rows;

            // 6) Colorear Falta/Sobra: <0 rojo, >0 verde
            dataGridView1.CellFormatting -= DataGridView1_CellFormatting;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;

            // 7) Click en botón Editar (queda el hook)
            dataGridView1.CellClick -= DataGridView1_CellClick;
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void DataGridView1_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName == nameof(CounterRecordRow.FaltaSobra))
            {
                if (e.Value is decimal val)
                {
                    var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.Style.ForeColor = val < 0 ? Color.Red : (val > 0 ? Color.Green : Color.Black);
                }
            }
        }

        private void DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var row = dataGridView1.Rows[e.RowIndex].DataBoundItem as CounterRecordRow;
                if (row == null) return;

                int counterRecordId = row.CounterRecordId;
                // TODO: abre tu formulario de edición
                // new FrmEditCounterRecord(counterRecordId).ShowDialog();
            }
        }
    }
}
