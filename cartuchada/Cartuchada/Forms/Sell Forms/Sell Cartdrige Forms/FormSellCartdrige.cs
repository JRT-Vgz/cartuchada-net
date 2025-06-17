using _1_Domain.Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Services.Cartdrige_Services;
using _2_Services.Services.Purchase_Services;
using _3_Repository.Query_Objects;
using Microsoft.Extensions.DependencyInjection;

namespace Cartuchada.Forms.Sell_Forms.Sell_Cartdrige_Forms
{
    public partial class FormSellCartdrige : Form
    {
        private readonly GetAllCartdrigesService _getAllCartdrigesService;
        private readonly FilterCartdrigeQuery _filterCartdrigeQuery;
        private readonly IServiceProvider _serviceProvider;
        private readonly RevertPurchaseCartdrigeService _revertPurchaseCartdrigeService;

        private IEnumerable<Cartdrige> _filteredCartdriges;

        private bool _isClosing = false;
        public bool IsClosing { get { return _isClosing; } }

        public FormSellCartdrige(GetAllCartdrigesService getAllCartdrigesService,
            FilterCartdrigeQuery filterCartdrigeQuery,
            IServiceProvider serviceProvider,
            RevertPurchaseCartdrigeService revertPurchaseCartdrigeService)
        {
            InitializeComponent();
            _getAllCartdrigesService = getAllCartdrigesService;
            _filterCartdrigeQuery = filterCartdrigeQuery;
            _serviceProvider = serviceProvider;
            _revertPurchaseCartdrigeService = revertPurchaseCartdrigeService;
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormSellCartdrige_Load(object sender, EventArgs e)
        {
            CreateColumns();
            await LoadAllData();
        }

        private void CreateColumns()
        {
            dgv_cartdrigeCatalogue.AutoGenerateColumns = false;
            dgv_cartdrigeCatalogue.Columns.Clear();
            dgv_cartdrigeCatalogue.DefaultCellStyle.SelectionBackColor = dgv_cartdrigeCatalogue.DefaultCellStyle.BackColor;
            dgv_cartdrigeCatalogue.DefaultCellStyle.SelectionForeColor = dgv_cartdrigeCatalogue.DefaultCellStyle.ForeColor;

            var sellButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "colSell",
                Text = "Vender",
                UseColumnTextForButtonValue = true,
                Width = 79
            };
            sellButtonColumn.DefaultCellStyle.BackColor = Color.LimeGreen;
            sellButtonColumn.DefaultCellStyle.SelectionBackColor = Color.LimeGreen;
            dgv_cartdrigeCatalogue.Columns.Add(sellButtonColumn);

            var referenceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Ref.",
                DataPropertyName = "Reference",
                Name = "colReference",
                Width = 45
            };
            referenceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_cartdrigeCatalogue.Columns.Add(referenceColumn);


            dgv_cartdrigeCatalogue.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Name",
                Name = "colName",
                Width = 515
            });

            var regionColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Región",
                DataPropertyName = "Region",
                Name = "colRegion",
                Width = 55
            };
            regionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_cartdrigeCatalogue.Columns.Add(regionColumn);

            var conditionColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Cond.",
                DataPropertyName = "Condition",
                Name = "coldCondition",
                Width = 50
            };
            conditionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_cartdrigeCatalogue.Columns.Add(conditionColumn);

            var purchasePriceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Compra",
                DataPropertyName = "PurchasePrice",
                Name = "colPurchasePrice",
                Width = 50
            };
            purchasePriceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            purchasePriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_cartdrigeCatalogue.Columns.Add(purchasePriceColumn);
        }

        private async Task LoadAllData()
        {
            _filteredCartdriges = await _getAllCartdrigesService.ExecuteAsync();
            await RefreshColumns();
        }

        private async Task RefreshColumns()
        {
            int cartdrigeCount = _filteredCartdriges.Count();
            AdjustTableSize(cartdrigeCount);

            dgv_cartdrigeCatalogue.DataSource = _filteredCartdriges
                .OrderBy(c => c.Reference)
                .ToList();
        }

        private void AdjustTableSize(int cartdrigeCount)
        {
            if (cartdrigeCount > 14) { this.Width = 833; }
            else { this.Width = 816; }
        }


        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- SEARCH TEXTBOX -----------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void txt_searchReference_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Enter
            {
                e.Handled = true;

                string searchFilter = txt_searchReference.Text;
                if (string.IsNullOrWhiteSpace(searchFilter))
                {
                    await LoadAllData();
                }
                else
                {
                    await FilterCartdrigesByReferenceAsync(searchFilter);
                }
            }
        }
        private async Task FilterCartdrigesByReferenceAsync(string searchFilter)
        {
            _filteredCartdriges = await _filterCartdrigeQuery.ExecuteQueryAsync(c => c.Reference.Name.Contains(searchFilter));
            await RefreshColumns();
        }

        private async void txt_searchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Enter
            {
                e.Handled = true;

                string searchFilter = txt_searchName.Text;
                if (string.IsNullOrWhiteSpace(searchFilter))
                {
                    await LoadAllData();
                }
                else
                {
                    await FilterCartdrigesByNameAsync(searchFilter);
                }
            }
        }

        private async Task FilterCartdrigesByNameAsync(string searchFilter)
        {
            _filteredCartdriges = await _filterCartdrigeQuery.ExecuteQueryAsync(c => c.Game.Name.Contains(searchFilter));
            await RefreshColumns();
        }


        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------- COLUMN BUTTONS ----------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void dgv_cartdrigeCatalogue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            string reference = dgv_cartdrigeCatalogue.Rows[e.RowIndex].Cells["colReference"].Value.ToString();
            var cartdrige = _filteredCartdriges.FirstOrDefault(g => g.Reference == reference);

            // SELL CARTDRIGE BUTTON:
            if (dgv_cartdrigeCatalogue.Columns[e.ColumnIndex].Name == "colSell")
            {
                var frm = _serviceProvider.GetRequiredService<FormManageSellCartdrige>();
                frm.SetInfo(cartdrige);
                frm.ShowDialog();

                if (frm.CartdrigeSold)
                {
                    await LoadAllData();
                }

                txt_searchReference.Focus();
            }

            // REVERT CARTDRIGE PURCHASE BUTTON:
            //else if (dgv_cartdrigeCatalogue.Columns[e.ColumnIndex].Name == "colRevertPurchase")
            //{
            //    var confirmRevert = MessageBox.Show($"¿Seguro que quieres revertir la compra del juego {cartdrige.Name} con referencia " +
            //        $"{cartdrige.Reference}?",
            //        "Confirmar revertir compra", MessageBoxButtons.YesNo);

            //    if (confirmRevert == DialogResult.Yes) { await RevertCartdrigePurchase(cartdrige); }
            //}
        }

        //private async Task RevertCartdrigePurchase(Cartdrige cartdrige)
        //{
        //    try
        //    {
        //        await _revertPurchaseCartdrigeService.ExecuteAsync(cartdrige);

        //        await LoadAllData();
        //    }
        //    catch (ProductValidationException ex)
        //    {
        //        string message = string.Empty;
        //        foreach (var error in ex.Errors) { message += $"- {error}\n"; }
        //        MessageBox.Show(message, ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}


        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- BACK ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormSellCartdrige_FormClosing(object sender, FormClosingEventArgs e)
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
