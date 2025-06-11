

using _2_Services.Interfaces;
using _3_Data.Models.Management_Models;

namespace Cartuchada.Forms.Miscelanea_Forms
{
    public partial class FormLog : Form
    {
        private readonly IGetAllQuery<LogModel> _getAllLogEntriesQuery;
        private bool _isClosing = false;

        public bool IsClosing { get { return _isClosing; } }

        public FormLog(IGetAllQuery<LogModel> getAllLogEntriesQuery)
        {
            InitializeComponent();
            _getAllLogEntriesQuery = getAllLogEntriesQuery;
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormLog_Load(object sender, EventArgs e)
        {
            CreateColumns();
            await RefreshColumns();
        }

        private void CreateColumns()
        {
            dgv_log.AutoGenerateColumns = false;
            dgv_log.Columns.Clear();
            dgv_log.DefaultCellStyle.SelectionBackColor = dgv_log.DefaultCellStyle.BackColor;
            dgv_log.DefaultCellStyle.SelectionForeColor = dgv_log.DefaultCellStyle.ForeColor;

            var dateColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                DataPropertyName = "Date",
                Name = "colDate",
                Width = 95
            };
            dateColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_log.Columns.Add(dateColumn);

            dgv_log.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Entrada",
                DataPropertyName = "Entry",
                Name = "colEntry",
                Width = 700
            });
        }

        private async Task RefreshColumns()
        {
            var logEntries = await _getAllLogEntriesQuery.ExecuteQueryAsync();

            int gamesCount = logEntries.Count();
            AdjustTableSize(gamesCount);

            dgv_log.DataSource = logEntries
                .OrderByDescending(l => l.Id)
                .ToList();
        }

        private void AdjustTableSize(int gamesCount)
        {
            if (gamesCount > 14) { this.Width = 833; }
            else { this.Width = 816; }
        }

        private void dgv_log_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_log.Columns[e.ColumnIndex].Name == "colDate" && e.Value is DateTime dateValue)
            {
                e.Value = dateValue.ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- BACK ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormLog_FormClosing(object sender, FormClosingEventArgs e)
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
