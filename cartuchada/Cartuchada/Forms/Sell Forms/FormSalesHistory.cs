

using _1_Domain.Product_Entities;
using _1_Domain.Sold_Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Services.Cartdrige_Services;
using _2_Services.Services.Console_Services;
using _2_Services.Services.SaleServices;
using _2_Services.Services.Sleeve_Services;
using _3_Presenters.View_Models;

namespace Cartuchada.Forms.Sell_Forms
{
    public partial class FormSalesHistory : Form
    {
        private readonly GetAllSoldCartdrigesService _getAllSoldCartdrigesService;
        private readonly GetAllSoldConsolesService _getAllSoldConsolesService;
        private readonly GetAllSoldSleevesService _getAllSoldSleevesService;
        private readonly RevertSellCartdrigeService<CartdrigePurchaseViewModel> _revertSellCartdrigeService;
        private readonly RevertSellConsoleService<ConsolePurchaseViewModel> _revertSellConsoleService;
        private readonly RevertSellSleeveService _revertSellSleeveService;

        private IEnumerable<object> _salesHistoryCurrentData;
        private bool _isClosing = false;

        public bool IsClosing { get { return _isClosing; } }

        public FormSalesHistory(GetAllSoldCartdrigesService getAllSoldCartdrigesService,
            GetAllSoldConsolesService getAllSoldConsolesService,
            GetAllSoldSleevesService getAllSoldSleevesService,
            RevertSellCartdrigeService<CartdrigePurchaseViewModel> revertSellCartdrigeService,
            RevertSellConsoleService<ConsolePurchaseViewModel> revertSellConsoleService,
            RevertSellSleeveService revertSellSleeveService)
        {
            InitializeComponent();
            _getAllSoldCartdrigesService = getAllSoldCartdrigesService;
            _getAllSoldConsolesService = getAllSoldConsolesService;
            _getAllSoldSleevesService = getAllSoldSleevesService;
            _revertSellCartdrigeService = revertSellCartdrigeService;
            _revertSellConsoleService = revertSellConsoleService;
            _revertSellSleeveService = revertSellSleeveService;
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormSalesHistory_Load(object sender, EventArgs e)
        {
            LoadDefaultCheckButton();
        }

        private void LoadDefaultCheckButton()
            => rb_historyCartdriges.Checked = true;

        // --------------------------------------- SHOW CARTDRIGE DATA --------------------------------------------
        private async Task ShowCartdrigeSaleHistoryData()
        {
            CreateCartdrigeSalesHistoryColumns();
            await LoadCartdrigeSaleHistoryData();
        }

        private void CreateCartdrigeSalesHistoryColumns()
        {
            dgv_salesHistory.AutoGenerateColumns = false;
            dgv_salesHistory.Columns.Clear();
            dgv_salesHistory.DefaultCellStyle.SelectionBackColor = dgv_salesHistory.DefaultCellStyle.BackColor;
            dgv_salesHistory.DefaultCellStyle.SelectionForeColor = dgv_salesHistory.DefaultCellStyle.ForeColor;

            var saleDateColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                DataPropertyName = "SaleDate",
                Name = "colSaleDate",
                Width = 70
            };
            saleDateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_salesHistory.Columns.Add(saleDateColumn);

            dgv_salesHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Name",
                Name = "colName",
                Width = 430
            });

            var regionColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Región",
                DataPropertyName = "Region",
                Name = "colRegion",
                Width = 50
            };
            regionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_salesHistory.Columns.Add(regionColumn);

            var conditionColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Cond.",
                DataPropertyName = "Condition",
                Name = "coldCondition",
                Width = 50
            };
            conditionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_salesHistory.Columns.Add(conditionColumn);

            var purchasePriceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Compra",
                DataPropertyName = "PurchasePrice",
                Name = "colPurchasePrice",
                Width = 50
            };
            purchasePriceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            purchasePriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_salesHistory.Columns.Add(purchasePriceColumn);

            var salePriceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Venta",
                DataPropertyName = "SalePrice",
                Name = "colSalePrice",
                Width = 50
            };
            salePriceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            salePriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_salesHistory.Columns.Add(salePriceColumn);

            var revertSaleButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "colRevertSale",
                Text = "Revertir venta",
                UseColumnTextForButtonValue = true,
                Width = 95
            };
            revertSaleButtonColumn.DefaultCellStyle.BackColor = Color.GreenYellow;
            revertSaleButtonColumn.DefaultCellStyle.SelectionBackColor = Color.GreenYellow;
            dgv_salesHistory.Columns.Add(revertSaleButtonColumn);
        }

        private async Task LoadCartdrigeSaleHistoryData()
        {
            _salesHistoryCurrentData = await _getAllSoldCartdrigesService.ExecuteAsync();
            await RefreshColumns();
        }


        // ---------------------------------------- SHOW CONSOLE DATA ---------------------------------------------
        private async Task ShowConsoleSaleHistoryData()
        {
            CreateConsoleSalesHistoryColumns();
            await LoadConsoleSaleHistoryData();
        }

        private void CreateConsoleSalesHistoryColumns()
        {
            dgv_salesHistory.AutoGenerateColumns = false;
            dgv_salesHistory.Columns.Clear();
            dgv_salesHistory.DefaultCellStyle.SelectionBackColor = dgv_salesHistory.DefaultCellStyle.BackColor;
            dgv_salesHistory.DefaultCellStyle.SelectionForeColor = dgv_salesHistory.DefaultCellStyle.ForeColor;

            var saleDateColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                DataPropertyName = "SaleDate",
                Name = "colSaleDate",
                Width = 70
            };
            saleDateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_salesHistory.Columns.Add(saleDateColumn);

            dgv_salesHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Name",
                Name = "colName",
                Width = 370
            });

            var purchasePriceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Compra",
                DataPropertyName = "PurchasePrice",
                Name = "colPurchasePrice",
                Width = 65
            };
            purchasePriceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            purchasePriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_salesHistory.Columns.Add(purchasePriceColumn);

            var sparePartsPriceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Piezas",
                DataPropertyName = "SparePartsPrice",
                Name = "colSparePartsPrice",
                Width = 65
            };
            sparePartsPriceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            sparePartsPriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_salesHistory.Columns.Add(sparePartsPriceColumn);

            var totalPriceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Total",
                DataPropertyName = "TotalPrice",
                Name = "colTotalPrice",
                Width = 65
            };
            totalPriceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            totalPriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_salesHistory.Columns.Add(totalPriceColumn);

            var salePriceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Venta",
                DataPropertyName = "SalePrice",
                Name = "colSalePrice",
                Width = 65
            };
            salePriceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            salePriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_salesHistory.Columns.Add(salePriceColumn);

            var revertSaleButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "colRevertSale",
                Text = "Revertir venta",
                UseColumnTextForButtonValue = true,
                Width = 95
            };
            revertSaleButtonColumn.DefaultCellStyle.BackColor = Color.GreenYellow;
            revertSaleButtonColumn.DefaultCellStyle.SelectionBackColor = Color.GreenYellow;
            dgv_salesHistory.Columns.Add(revertSaleButtonColumn);
        }

        private async Task LoadConsoleSaleHistoryData()
        {
            _salesHistoryCurrentData = await _getAllSoldConsolesService.ExecuteAsync();
            RefreshColumns();
        }


        // ---------------------------------------- SHOW SLEEVES DATA ----------------------------------------------
        private async Task ShowSleevesSaleHistoryData()
        {
            CreateSleevesSalesHistoryColumns();
            await LoadSleevesSaleHistoryData();
        }

        private void CreateSleevesSalesHistoryColumns()
        {
            dgv_salesHistory.AutoGenerateColumns = false;
            dgv_salesHistory.Columns.Clear();
            dgv_salesHistory.DefaultCellStyle.SelectionBackColor = dgv_salesHistory.DefaultCellStyle.BackColor;
            dgv_salesHistory.DefaultCellStyle.SelectionForeColor = dgv_salesHistory.DefaultCellStyle.ForeColor;

            var saleDateColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                DataPropertyName = "SaleDate",
                Name = "colSaleDate",
                Width = 70
            };
            saleDateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_salesHistory.Columns.Add(saleDateColumn);

            dgv_salesHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Name",
                Name = "colName",
                Width = 500
            });

            var quantityColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Cantidad",
                DataPropertyName = "Quantity",
                Name = "colQuantity",
                Width = 65
            };
            quantityColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            quantityColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_salesHistory.Columns.Add(quantityColumn);

            var salePriceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Venta",
                DataPropertyName = "SalePrice",
                Name = "colSalePrice",
                Width = 65
            };
            salePriceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            salePriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_salesHistory.Columns.Add(salePriceColumn);

            var revertSaleButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "colRevertSale",
                Text = "Revertir venta",
                UseColumnTextForButtonValue = true,
                Width = 95
            };
            revertSaleButtonColumn.DefaultCellStyle.BackColor = Color.GreenYellow;
            revertSaleButtonColumn.DefaultCellStyle.SelectionBackColor = Color.GreenYellow;
            dgv_salesHistory.Columns.Add(revertSaleButtonColumn);
        }

        private async Task LoadSleevesSaleHistoryData()
        {
            _salesHistoryCurrentData = await _getAllSoldSleevesService.ExecuteAsync();
            RefreshColumns();
        }


        // ---------------------------------------------------------------------------------------------------------
        private async Task RefreshColumns()
        {
            int gamesCount = _salesHistoryCurrentData.Count();
            AdjustTableSize(gamesCount);

            dgv_salesHistory.DataSource = _salesHistoryCurrentData
                .OrderByDescending(item =>
                {
                    var type = item.GetType();
                    var prop = type.GetProperty("SaleDate");
                    return prop != null ? prop.GetValue(item) : null;
                })
                .ToList();
        }

        private void AdjustTableSize(int gamesCount)
        {
            if (gamesCount > 14) { this.Width = 833; }
            else { this.Width = 816; }
        }


        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------- RADIO BUTTONS -----------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked) { return; }

            if (sender == rb_historyCartdriges)
            {
                await ShowCartdrigeSaleHistoryData();
            }
            else if (sender == rb_historyConsoles)
            {
                await ShowConsoleSaleHistoryData();
            }
            else if (sender == rb_historySleeves)
            {
                await ShowSleevesSaleHistoryData();
            }
        }


        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------- COLUMN BUTTONS ----------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void dgv_salesHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            if (dgv_salesHistory.Columns[e.ColumnIndex].Name != "colRevertSale") { return; }

            try
            {
                // REVERT SOLD CARTDRIGE
                if (rb_historyCartdriges.Checked)
                {
                    SoldCartdrige soldCartdrige = (SoldCartdrige)dgv_salesHistory.Rows[e.RowIndex].DataBoundItem;

                    var confirmRevert = MessageBox.Show($"¿Seguro que quieres revertir la venta del siguiente juego?\n\n" +
                        $"{soldCartdrige.Name.ToUpper()}\n" +
                        $"Fecha de venta: {soldCartdrige.SaleDate.ToString("dd/MM/yyyy")}\n" +
                        $"Región: {soldCartdrige.Region}\n" +
                        $"Condición: {soldCartdrige.Condition}\n" +
                        $"Precio de compra: {soldCartdrige.PurchasePrice}€\n" +
                        $"Precio de venta: {soldCartdrige.SalePrice}€\n",
                    "Confirmar revertir venta", MessageBoxButtons.YesNo);

                    if (confirmRevert == DialogResult.Yes) { await RevertSoldCartdrige(soldCartdrige); }
                }
                // REVERT SOLD CONSOLE
                else if (rb_historyConsoles.Checked)
                {
                    SoldVideoConsole soldVideoConsole = (SoldVideoConsole)dgv_salesHistory.Rows[e.RowIndex].DataBoundItem;

                    var confirmRevert = MessageBox.Show($"¿Seguro que quieres revertir la venta de la siguiente consola?\n\n" +
                        $"{soldVideoConsole.Name.ToUpper()}\n" +
                        $"Fecha de venta: {soldVideoConsole.SaleDate.ToString("dd/MM/yyyy")}\n" +
                        $"Precio de compra: {soldVideoConsole.PurchasePrice}€\n" +
                        $"Precio de piezas: {soldVideoConsole.SparePartsPrice}€\n" +
                        $"Precio total: {soldVideoConsole.TotalPrice}€\n" +
                        $"Precio de venta: {soldVideoConsole.SalePrice}€\n",
                    "Confirmar revertir venta", MessageBoxButtons.YesNo);

                    if (confirmRevert == DialogResult.Yes) { await RevertSoldConsole(soldVideoConsole); }
                }
                // REVERT SOLD SLEEVES
                else if (rb_historySleeves.Checked)
                {
                    SoldSleeve soldSleeve = (SoldSleeve)dgv_salesHistory.Rows[e.RowIndex].DataBoundItem;

                    var confirmRevert = MessageBox.Show($"¿Seguro que quieres revertir la venta de las siguientes fundas?\n\n" +
                        $"{soldSleeve.Name.ToUpper()}\n" +
                        $"Fecha de venta: {soldSleeve.SaleDate.ToString("dd/MM/yyyy")}\n" +
                        $"Cantidad: {soldSleeve.Quantity}\n" +
                        $"Precio de venta: {soldSleeve.SalePrice}€\n",
                    "Confirmar revertir venta", MessageBoxButtons.YesNo);

                    if (confirmRevert == DialogResult.Yes) { await RevertSoldSleeves(soldSleeve); }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private async Task RevertSoldCartdrige(SoldCartdrige soldCartdrige)
        {
            try
            {
                var viewModel = await _revertSellCartdrigeService.ExecuteAsync(soldCartdrige);

                MessageBox.Show(
                    $"{viewModel.Reference}\n\n" +
                    $"{viewModel.Name}\n" +
                    $"{viewModel.ProductType}\n" +
                    $"{viewModel.Region}\n" +
                    $"{viewModel.Condition}\n" +
                    $"{viewModel.PurchasePrice}",
                    "Venta revertida");

                await LoadCartdrigeSaleHistoryData();
            }
            catch (ProductValidationException ex)
            {
                Console.WriteLine(ex.Message);
                foreach (var error in ex.Errors) { Console.WriteLine(error); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private async Task RevertSoldConsole(SoldVideoConsole soldVideoConsole)
        {
            try
            {
                var viewModel = await _revertSellConsoleService.ExecuteAsync(soldVideoConsole);

                MessageBox.Show(
                    $"{viewModel.Reference}\n\n" +
                    $"{viewModel.Name}\n" +
                    $"{viewModel.PurchasePrice}\n" +
                    $"{viewModel.SparePartsPrice}\n" +
                    $"{viewModel.TotalPrice}",
                    "Venta revertida");

                await LoadConsoleSaleHistoryData();
            }
            catch (ProductValidationException ex)
            {
                Console.WriteLine(ex.Message);
                foreach (var error in ex.Errors) { Console.WriteLine(error); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private async Task RevertSoldSleeves(SoldSleeve soldSleeve)
        {
            try
            {
                await _revertSellSleeveService.ExecuteAsync(soldSleeve);

                await LoadSleevesSaleHistoryData();
            }
            catch (ProductValidationException ex)
            {
                Console.WriteLine(ex.Message);
                foreach (var error in ex.Errors) { Console.WriteLine(error); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }




        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- BACK ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormSalesHistory_FormClosing(object sender, FormClosingEventArgs e)
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
