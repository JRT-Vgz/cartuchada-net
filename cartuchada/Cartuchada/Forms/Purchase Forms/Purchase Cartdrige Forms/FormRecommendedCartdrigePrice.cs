

using _3_Mappers.DTOs.Purchase_Dtos;
using _3_Repository.Query_Objects;

namespace Cartuchada.Forms.Purchase_Forms.Purchase_Cartdrige_Forms
{
    public partial class FormRecommendedCartdrigePrice : Form
    {
        private readonly FilterSoldCartdrigeQuery _filterSoldCartdrigeQuery;
        private readonly FilterSpotedCartdrigeQuery _filterSpotedCartdrigeQuery;
        private bool _isClosing = false;

        public bool IsClosing { get { return _isClosing; } }

        public FormRecommendedCartdrigePrice(FilterSoldCartdrigeQuery filterSoldCartdrigeQuery,
            FilterSpotedCartdrigeQuery filterSpotedCartdrigeQuery)
        {
            InitializeComponent();
            _filterSoldCartdrigeQuery = filterSoldCartdrigeQuery;
            _filterSpotedCartdrigeQuery = filterSpotedCartdrigeQuery;
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormRecommendedCartdrigePrice_Load(object sender, EventArgs e)
        {
            rb_all.Checked = true;
            CreateSoldCartdrigeColumns();
            CreateSpotedCartdrigeColumns();
            await LoadSoldCartdrigesData();
            await LoadSpotedCartdrigesData();
        }

        private void CreateSoldCartdrigeColumns()
        {
            dgv_cartdrigeSales.AutoGenerateColumns = false;
            dgv_cartdrigeSales.Columns.Clear();
            dgv_cartdrigeSales.DefaultCellStyle.SelectionBackColor = dgv_cartdrigeSales.DefaultCellStyle.BackColor;
            dgv_cartdrigeSales.DefaultCellStyle.SelectionForeColor = dgv_cartdrigeSales.DefaultCellStyle.ForeColor;

            dgv_cartdrigeSales.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                DataPropertyName = "SaleDate",
                Name = "colSaleDate",
                Width = 90
            });

            dgv_cartdrigeSales.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Región",
                DataPropertyName = "Region",
                Name = "colRegion",
                Width = 90
            });

            dgv_cartdrigeSales.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Condición",
                DataPropertyName = "Condition",
                Name = "colCondition",
                Width = 90
            });

            dgv_cartdrigeSales.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Venta",
                DataPropertyName = "SalePrice",
                Name = "colSalePrice",
                Width = 90
            });
        }

        private void CreateSpotedCartdrigeColumns()
        {
            dgv_cartdrigeSpots.AutoGenerateColumns = false;
            dgv_cartdrigeSpots.Columns.Clear();
            dgv_cartdrigeSpots.DefaultCellStyle.SelectionBackColor = dgv_cartdrigeSpots.DefaultCellStyle.BackColor;
            dgv_cartdrigeSpots.DefaultCellStyle.SelectionForeColor = dgv_cartdrigeSpots.DefaultCellStyle.ForeColor;

            dgv_cartdrigeSpots.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                DataPropertyName = "PurchaseDate",
                Name = "colSaleDate",
                Width = 90
            });

            dgv_cartdrigeSpots.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Región",
                DataPropertyName = "Region",
                Name = "colRegion",
                Width = 90
            });

            dgv_cartdrigeSpots.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Condición",
                DataPropertyName = "Condition",
                Name = "colCondition",
                Width = 90
            });

            dgv_cartdrigeSpots.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Spot",
                DataPropertyName = "PurchasePrice",
                Name = "colSalePrice",
                Width = 90
            });
        }

        private async Task LoadSoldCartdrigesData()
        {
            string cartdrigeName = this.Text;
            var soldCartdrigesData = await _filterSoldCartdrigeQuery.ExecuteQueryAsync(s => s.Game.Name == cartdrigeName);

            dgv_cartdrigeSales.DataSource = soldCartdrigesData
                .OrderByDescending(s => s.SaleDate)
                .ToList();
        }

        private async Task LoadSpotedCartdrigesData()
        {
            string cartdrigeName = this.Text;
            var spotedCartdrigesData = await _filterSpotedCartdrigeQuery.ExecuteQueryAsync(s => s.Game.Name == cartdrigeName);

            dgv_cartdrigeSpots.DataSource = spotedCartdrigesData
                .OrderByDescending(s => s.PurchaseDate)
                .ToList();
        }

        public void SetInfo(CartdrigePurchaseDto cartdrigePurchaseDto)
        {
            this.Text = cartdrigePurchaseDto.Name;
        }


        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- SEARCH BUTTON ------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_search_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Búsqueda no implementada.");
        }



        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- BACK ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormRecommendedCartdrigePrice_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                _isClosing = true;
                Application.Exit();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
