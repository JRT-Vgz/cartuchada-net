using _2_Services.Interfaces;
using _3_Data.Models;

namespace Cartuchada.Forms.Miscelanea_Forms
{
    public partial class FormStatistics : Form
    {
        private readonly IGetAllQuery<ShopStatModel> _getAllShopStatsQuery;
        private bool _isClosing = false;

        public bool IsClosing { get { return _isClosing; } }

        public FormStatistics(IGetAllQuery<ShopStatModel> getAllShopStatsQuery)
        {
            InitializeComponent();
            _getAllShopStatsQuery = getAllShopStatsQuery;
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormStatistics_Load(object sender, EventArgs e)
        {
            CreateColumns();
            await RefreshColumns();
        }

        private void CreateColumns()
        {
            dgv_statistics.AutoGenerateColumns = false;
            dgv_statistics.Columns.Clear();
            dgv_statistics.DefaultCellStyle.SelectionBackColor = dgv_statistics.DefaultCellStyle.BackColor;
            dgv_statistics.DefaultCellStyle.SelectionForeColor = dgv_statistics.DefaultCellStyle.ForeColor;

            var leftColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "",
                DataPropertyName = "",
                Name = "colName",
                Width = 230
            };
            leftColumn.DefaultCellStyle.BackColor = Color.LightGray;
            leftColumn.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgv_statistics.Columns.Add(leftColumn);

            var nameColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "",
                DataPropertyName = "Name",
                Name = "colName",
                Width = 300
            };
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_statistics.Columns.Add(nameColumn);

            var quantityColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "",
                DataPropertyName = "Quantity",
                Name = "colQuantity",
                Width = 35
            };
            quantityColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_statistics.Columns.Add(quantityColumn);

            var rightColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "",
                DataPropertyName = "",
                Name = "colName",
                Width = 230
            };
            rightColumn.DefaultCellStyle.BackColor = Color.LightGray;
            rightColumn.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgv_statistics.Columns.Add(rightColumn);
        }

        private async Task RefreshColumns()
        {
            var shopStats = await _getAllShopStatsQuery.ExecuteQueryAsync();

            int gamesCount = shopStats.Count();
            AdjustTableSize(gamesCount);

            dgv_statistics.DataSource = shopStats;
        }

        private void AdjustTableSize(int gamesCount)
        {
            if (gamesCount > 14) { this.Width = 833; }
            else { this.Width = 816; }
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- BACK ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormStatistics_FormClosing(object sender, FormClosingEventArgs e)
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
