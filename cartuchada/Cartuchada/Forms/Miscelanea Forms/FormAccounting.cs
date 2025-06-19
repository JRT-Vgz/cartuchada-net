
using _2_Services.Interfaces;
using _3_Data.Models.Management_Models;

namespace Cartuchada.Forms.Miscelanea_Forms
{
    public partial class FormAccounting : Form
    {
        private readonly IGetAllQuery<AccountingModel> _getAllAccountingQuery;

        private IEnumerable<AccountingModel> _accountingData;
        private bool _isClosing = false;
        public bool IsClosing { get { return _isClosing; } }

        public FormAccounting(IGetAllQuery<AccountingModel> getAllAccountingQuery)
        {
            InitializeComponent();
            _getAllAccountingQuery = getAllAccountingQuery;
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormAccounting_Load(object sender, EventArgs e)
        {
            await LoadAccountingData();
            LoadComboBox();
            LoadAccountingColumns();
            LoadHistoricalAccountingColumns();
            ShowHistoricalData();
        }

        private async Task LoadAccountingData()
        {
            _accountingData = await _getAllAccountingQuery.ExecuteQueryAsync();
        }

        private void LoadComboBox()
        {
            int[] years = _accountingData
            .Select(a => a.Date.Year)
            .Distinct()
            .OrderByDescending(a => a)
            .ToArray();

            if (years.Length == 0) { return; }

            cbo_yearFilter.DataSource = years;
            cbo_yearFilter.SelectedIndex = 0;
        }

        private void LoadAccountingColumns()
        {
            dgv_accounting.AutoGenerateColumns = false;
            dgv_accounting.Columns.Clear();
            dgv_accounting.DefaultCellStyle.SelectionBackColor = dgv_accounting.DefaultCellStyle.BackColor;
            dgv_accounting.DefaultCellStyle.SelectionForeColor = dgv_accounting.DefaultCellStyle.ForeColor;

            dgv_accounting.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                DataPropertyName = "Date",
                Name = "colDate",
                Width = 100
            });

            dgv_accounting.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ingresos",
                DataPropertyName = "Income",
                Name = "colIncome",
                Width = 100
            });

            dgv_accounting.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Gastos",
                DataPropertyName = "Expenses",
                Name = "colExpenses",
                Width = 100
            });

            dgv_accounting.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total",
                DataPropertyName = "Total",
                Name = "colTotal",
                Width = 100
            });
        }

        private void dgv_accounting_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Formatea la celda de fecha para que aparezca el nombre del mes o TOTAL si es la ultima fila.
            if (dgv_accounting.Columns[e.ColumnIndex].Name == "colDate")
            {
                if (e.Value != null && e.Value is DateTime dateValue)
                {
                    if (dateValue == DateTime.MinValue) { e.Value = "TOTAL " + cbo_yearFilter.SelectedValue; }
                    else
                    {
                        string monthName = dateValue.ToString("MMMM", new System.Globalization.CultureInfo("es-ES"));
                        monthName = char.ToUpper(monthName[0]) + monthName.Substring(1);

                        e.Value = monthName;
                    }
                }
            }
        }

        private void LoadHistoricalAccountingColumns()
        {
            dgv_historicalAccounting.AutoGenerateColumns = false;
            dgv_historicalAccounting.Columns.Clear();
            dgv_historicalAccounting.DefaultCellStyle.SelectionBackColor = dgv_historicalAccounting.DefaultCellStyle.BackColor;
            dgv_historicalAccounting.DefaultCellStyle.SelectionForeColor = dgv_historicalAccounting.DefaultCellStyle.ForeColor;

            dgv_historicalAccounting.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ingresos",
                DataPropertyName = "Income",
                Name = "colIncome",
                Width = 100
            });

            dgv_historicalAccounting.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Gastos",
                DataPropertyName = "Expenses",
                Name = "colExpenses",
                Width = 100
            });

            dgv_historicalAccounting.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total",
                DataPropertyName = "Total",
                Name = "colTotal",
                Width = 100
            });
        }

        private void ShowSelectedYearData()
        {
            int selectedYear = (int)cbo_yearFilter.SelectedItem;

            List<AccountingModel> currentYearData = _accountingData
                .Where(a => a.Date.Year == selectedYear)
                .ToList();

            AccountingModel totalYearBalanceModel = CreateTotalYearBalanceModel(currentYearData);

            currentYearData.Add(totalYearBalanceModel);

            dgv_accounting.DataSource = currentYearData;
        }

        private AccountingModel CreateTotalYearBalanceModel(List<AccountingModel> currentYearData)
        {
            return new AccountingModel
            {
                Income = CalculateTotal(currentYearData, column => column.Income),
                Expenses = CalculateTotal(currentYearData, column => column.Expenses),
                Total = CalculateTotal(currentYearData, column => column.Total)
            };
        }

        private void ShowHistoricalData()
        {
            List<AccountingModel> historicalData = new List<AccountingModel>
            {
                new AccountingModel
                {
                    Income = CalculateTotal(_accountingData.ToList(), column => column.Income),
                    Expenses = CalculateTotal(_accountingData.ToList(), column => column.Expenses),
                    Total = CalculateTotal(_accountingData.ToList(), column => column.Total)
                }
            };

            dgv_historicalAccounting.DataSource = historicalData;
        }

        private decimal CalculateTotal(List<AccountingModel> currentYearData, Func<AccountingModel, decimal> lambda)
            => currentYearData.Sum(lambda);


        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------------- COMBO BOX -------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void cbo_yearFilter_SelectedIndexChanged(object sender, EventArgs e)
            => ShowSelectedYearData();


        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- BACK ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormAccounting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                _isClosing = true;
                Application.Exit();
            }
        }

        private void btn_mainMenu_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
