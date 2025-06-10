
using _1_Domain.Product_Entities;
using _1_Domain.Purchase_Entities;
using _2_Services.Exceptions;
using _2_Services.Services.Cartdrige_Services;
using _2_Services.Services.Console_Services;
using _2_Services.Services.Purchase_Services;
using _2_Services.Services.Spare_Parts_Services;
using Cartuchada.Forms.Miscelanea_Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Cartuchada.Forms.Purchase_Forms
{
    public partial class FormPurchasesHistory : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly GetAllCartdrigesService _getAllCartdrigesService;
        private readonly GetAllConsolesService _getAllConsolesService;
        private readonly GetAllSparePartsPurchasesService _getAllSparePartsPurchasesService;
        private readonly RevertPurchaseCartdrigeService _revertPurchaseCartdrigeService;
        private readonly RevertPurchaseConsoleService _revertPurchaseConsoleService;
        private readonly RevertPurchaseSparePartsService _revertPurchaseSparePartsService;

        private IEnumerable<object> _purchasesHistoryCurrentData;
        private bool _isClosing = false;

        public bool IsClosing { get { return _isClosing; } }

        public FormPurchasesHistory(IServiceProvider serviceProvider,
            GetAllCartdrigesService getAllCartdrigesService,
            GetAllConsolesService getAllConsolesService,
            GetAllSparePartsPurchasesService getAllSparePartsPurchasesService,
            RevertPurchaseCartdrigeService revertPurchaseCartdrigeService,
            RevertPurchaseConsoleService revertPurchaseConsoleService, 
            RevertPurchaseSparePartsService revertPurchaseSparePartsService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _getAllCartdrigesService = getAllCartdrigesService;
            _getAllConsolesService = getAllConsolesService;
            _getAllSparePartsPurchasesService = getAllSparePartsPurchasesService;
            _revertPurchaseCartdrigeService = revertPurchaseCartdrigeService;
            _revertPurchaseConsoleService = revertPurchaseConsoleService;
            _revertPurchaseSparePartsService = revertPurchaseSparePartsService;
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        #region LOAD DATA
        private void FormPurchasesHistory_Load(object sender, EventArgs e)
        {
            LoadDefaultCheckButton();
        }

        private void LoadDefaultCheckButton()
            => rb_historyCartdriges.Checked = true;

        // --------------------------------------- SHOW CARTDRIGE DATA --------------------------------------------
        private async Task ShowCartdrigePurchasesHistoryData()
        {
            CreateCartdrigePurchasesHistoryColumns();
            await LoadCartdrigePurchasesHistoryData();
        }

        private void CreateCartdrigePurchasesHistoryColumns()
        {
            dgv_purchasesHistory.AutoGenerateColumns = false;
            dgv_purchasesHistory.Columns.Clear();
            dgv_purchasesHistory.DefaultCellStyle.SelectionBackColor = dgv_purchasesHistory.DefaultCellStyle.BackColor;
            dgv_purchasesHistory.DefaultCellStyle.SelectionForeColor = dgv_purchasesHistory.DefaultCellStyle.ForeColor;

            var purchaseDateColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                DataPropertyName = "PurchaseDate",
                Name = "colPurchaseDate",
                Width = 70
            };
            purchaseDateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_purchasesHistory.Columns.Add(purchaseDateColumn);

            var referenceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Ref.",
                DataPropertyName = "Reference",
                Name = "colReference",
                Width = 45
            };
            referenceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_purchasesHistory.Columns.Add(referenceColumn);

            dgv_purchasesHistory.Columns.Add(new DataGridViewTextBoxColumn
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
                Width = 55
            };
            regionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_purchasesHistory.Columns.Add(regionColumn);

            var conditionColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Cond.",
                DataPropertyName = "Condition",
                Name = "coldCondition",
                Width = 50
            };
            conditionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_purchasesHistory.Columns.Add(conditionColumn);

            var purchasePriceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Compra",
                DataPropertyName = "PurchasePrice",
                Name = "colPurchasePrice",
                Width = 50
            };
            purchasePriceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            purchasePriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_purchasesHistory.Columns.Add(purchasePriceColumn);

            var revertPurchaseButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "colRevertPurchase",
                Text = "Revertir compra",
                UseColumnTextForButtonValue = true,
                Width = 95
            };
            revertPurchaseButtonColumn.DefaultCellStyle.BackColor = Color.GreenYellow;
            revertPurchaseButtonColumn.DefaultCellStyle.SelectionBackColor = Color.GreenYellow;
            dgv_purchasesHistory.Columns.Add(revertPurchaseButtonColumn);
        }

        private async Task LoadCartdrigePurchasesHistoryData()
        {
            _purchasesHistoryCurrentData = await _getAllCartdrigesService.ExecuteAsync();
            await RefreshColumns();
        }


        // ---------------------------------------- SHOW CONSOLE DATA ---------------------------------------------
        private async Task ShowConsolePurchasesHistoryData()
        {
            CreateConsolePurchasesHistoryColumns();
            await LoadConsolePurchasesHistoryData();
        }

        private void CreateConsolePurchasesHistoryColumns()
        {
            dgv_purchasesHistory.AutoGenerateColumns = false;
            dgv_purchasesHistory.Columns.Clear();
            dgv_purchasesHistory.DefaultCellStyle.SelectionBackColor = dgv_purchasesHistory.DefaultCellStyle.BackColor;
            dgv_purchasesHistory.DefaultCellStyle.SelectionForeColor = dgv_purchasesHistory.DefaultCellStyle.ForeColor;

            var purchaseDateColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                DataPropertyName = "PurchaseDate",
                Name = "colPurchaseDate",
                Width = 70
            };
            purchaseDateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_purchasesHistory.Columns.Add(purchaseDateColumn);

            var referenceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Ref.",
                DataPropertyName = "Reference",
                Name = "colReference",
                Width = 75
            };
            referenceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            referenceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_purchasesHistory.Columns.Add(referenceColumn);

            dgv_purchasesHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Name",
                Name = "colName",
                Width = 360
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
            dgv_purchasesHistory.Columns.Add(purchasePriceColumn);

            var sparePartsPriceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Piezas",
                DataPropertyName = "SparePartsPrice",
                Name = "colSparePartsPrice",
                Width = 65
            };
            sparePartsPriceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            sparePartsPriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_purchasesHistory.Columns.Add(sparePartsPriceColumn);

            var totalPriceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Total",
                DataPropertyName = "TotalPrice",
                Name = "colTotalPrice",
                Width = 65
            };
            totalPriceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            totalPriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_purchasesHistory.Columns.Add(totalPriceColumn);

            var revertPurchaseButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "colRevertPurchase",
                Text = "Revertir compra",
                UseColumnTextForButtonValue = true,
                Width = 95
            };
            revertPurchaseButtonColumn.DefaultCellStyle.BackColor = Color.GreenYellow;
            revertPurchaseButtonColumn.DefaultCellStyle.SelectionBackColor = Color.GreenYellow;
            dgv_purchasesHistory.Columns.Add(revertPurchaseButtonColumn);
        }

        private async Task LoadConsolePurchasesHistoryData()
        {
            _purchasesHistoryCurrentData = await _getAllConsolesService.ExecuteAsync();
            RefreshColumns();
        }

        // -------------------------------------- SHOW SPARE PARTS DATA -------------------------------------------
        private async Task ShowSparePartsPurchasesHistoryData()
        {
            CreateSparePartsPurchasesHistoryColumns();
            await LoadSparePartsPurchasesHistoryData();
        }

        private void CreateSparePartsPurchasesHistoryColumns()
        {
            dgv_purchasesHistory.AutoGenerateColumns = false;
            dgv_purchasesHistory.Columns.Clear();
            dgv_purchasesHistory.DefaultCellStyle.SelectionBackColor = dgv_purchasesHistory.DefaultCellStyle.BackColor;
            dgv_purchasesHistory.DefaultCellStyle.SelectionForeColor = dgv_purchasesHistory.DefaultCellStyle.ForeColor;

            var purchaseDateColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                DataPropertyName = "PurchaseDate",
                Name = "colPurchaseDate",
                Width = 70
            };
            purchaseDateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_purchasesHistory.Columns.Add(purchaseDateColumn);

            var nameColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Name",
                Name = "colName",
                Width = 180
            };
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_purchasesHistory.Columns.Add(nameColumn);

            var conceptColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Concepto",
                DataPropertyName = "Concept",
                Name = "colConcept",
                Width = 385
            };
            conceptColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            conceptColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_purchasesHistory.Columns.Add(conceptColumn);

            var purchasePriceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Compra",
                DataPropertyName = "PurchasePrice",
                Name = "colPurchasePrice",
                Width = 65
            };
            purchasePriceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            purchasePriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_purchasesHistory.Columns.Add(purchasePriceColumn);

            var revertPurchaseButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "colRevertPurchase",
                Text = "Revertir compra",
                UseColumnTextForButtonValue = true,
                Width = 95
            };
            revertPurchaseButtonColumn.DefaultCellStyle.BackColor = Color.GreenYellow;
            revertPurchaseButtonColumn.DefaultCellStyle.SelectionBackColor = Color.GreenYellow;
            dgv_purchasesHistory.Columns.Add(revertPurchaseButtonColumn);
        }

        private async Task LoadSparePartsPurchasesHistoryData()
        {
            _purchasesHistoryCurrentData = await _getAllSparePartsPurchasesService.ExecuteAsync();
            RefreshColumns();
        }

        // --------------------------------------------------------------------------------------------------------
        private async Task RefreshColumns()
        {
            int gamesCount = _purchasesHistoryCurrentData.Count();
            AdjustTableSize(gamesCount);

            dgv_purchasesHistory.DataSource = _purchasesHistoryCurrentData
                .OrderByDescending(item =>
                {
                    var type = item.GetType();
                    var prop = type.GetProperty("PurchaseDate");
                    return prop != null ? prop.GetValue(item) : null;
                })
                .ThenByDescending(item =>
                {
                    var type = item.GetType();
                    var prop = type.GetProperty("Id");
                    return prop != null ? prop.GetValue(item) : null;
                })
                .ToList();
        }

        private void AdjustTableSize(int gamesCount)
        {
            if (gamesCount > 14) { this.Width = 833; }
            else { this.Width = 816; }
        }
        #endregion


        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------- RADIO BUTTONS -----------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked) { return; }

            if (sender == rb_historyCartdriges) { await ShowCartdrigePurchasesHistoryData(); }
            else if (sender == rb_historyConsoles) { await ShowConsolePurchasesHistoryData(); }
            else if (sender == rb_historySpareParts) { await ShowSparePartsPurchasesHistoryData(); }
        }


        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------- COLUMN BUTTONS ----------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void dgv_salesHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            if (dgv_purchasesHistory.Columns[e.ColumnIndex].Name != "colRevertPurchase") { return; }

            object product = dgv_purchasesHistory.Rows[e.RowIndex].DataBoundItem;

            if (rb_historyCartdriges.Checked) { await RevertPurchaseCartdrige((Cartdrige)product); }
            else if (rb_historyConsoles.Checked) { await RevertPurchaseConsole((VideoConsole)product); }
            else if (rb_historySpareParts.Checked) { await RevertPurchaseSpareParts((SparePartsPurchase)product); }
        }

        private async Task RevertPurchaseCartdrige(Cartdrige cartdrige)
        {
            try
            {
                var confirmRevert = MessageBox.Show($"¿Seguro que quieres revertir la COMPRA del siguiente juego?\n\n" +
                    $"{cartdrige.Name.ToUpper()}\n" +
                    $"Fecha de compra: {cartdrige.PurchaseDate.ToString("dd/MM/yyyy")}\n" +
                    $"Región: {cartdrige.Region}\n" +
                    $"Condición: {cartdrige.Condition}\n" +
                    $"Precio de compra: {cartdrige.PurchasePrice}€\n",
                "Confirmar revertir compra", MessageBoxButtons.YesNo);

                if (confirmRevert == DialogResult.No) { return; }
                if (!RevertActionConfirmed()) { return; }

                MessageBox.Show("Confirmado");

                await _revertPurchaseCartdrigeService.ExecuteAsync(cartdrige);

                await LoadCartdrigePurchasesHistoryData();
            }
            catch (ProductValidationException ex)
            {
                Console.WriteLine(ex.Message);
                foreach (var error in ex.Errors) { Console.WriteLine(error); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private async Task RevertPurchaseConsole(VideoConsole videoConsole)
        {
            try
            {
                var confirmRevert = MessageBox.Show($"¿Seguro que quieres revertir la COMPRA de la siguiente consola?\n\n" +
                    $"{videoConsole.Name.ToUpper()}\n" +
                    $"Fecha de compra: {videoConsole.PurchaseDate.ToString("dd/MM/yyyy")}\n" +
                    $"Precio de compra: {videoConsole.PurchasePrice}€\n" +
                    $"Precio de piezas: {videoConsole.SparePartsPrice}€\n" +
                    $"Precio total: {videoConsole.TotalPrice}€\n",
                "Confirmar revertir compra", MessageBoxButtons.YesNo);

                if (confirmRevert == DialogResult.No) { return; }
                if (!RevertActionConfirmed()) { return; }

                MessageBox.Show("Confirmado");

                await _revertPurchaseConsoleService.ExecuteAsync(videoConsole);

                await LoadConsolePurchasesHistoryData();
            }
            catch (ProductValidationException ex)
            {
                Console.WriteLine(ex.Message);
                foreach (var error in ex.Errors) { Console.WriteLine(error); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private async Task RevertPurchaseSpareParts(SparePartsPurchase sparePartsPurchase)
        {
            try
            {
                var confirmRevert = MessageBox.Show($"¿Seguro que quieres revertir la COMPRA de los siguientes recambios?\n\n" +
                    $"{sparePartsPurchase.Name.ToUpper()}\n" +
                    $"Fecha de compra: {sparePartsPurchase.PurchaseDate.ToString("dd/MM/yyyy")}\n" +
                    $"Concepto: {sparePartsPurchase.Concept}\n" +
                    $"Precio de compra: {sparePartsPurchase.PurchasePrice}€\n",
                "Confirmar revertir compra", MessageBoxButtons.YesNo);

                if (confirmRevert == DialogResult.No) { return; }
                if (!RevertActionConfirmed()) { return; }

                MessageBox.Show("Confirmado");

                await _revertPurchaseSparePartsService.ExecuteAsync(sparePartsPurchase);

                await LoadSparePartsPurchasesHistoryData();
            }
            catch (ProductValidationException ex)
            {
                Console.WriteLine(ex.Message);
                foreach (var error in ex.Errors) { Console.WriteLine(error); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private bool RevertActionConfirmed()
        {
            var frm = _serviceProvider.GetRequiredService<FormConfirmRevertInput>();
            frm.ShowDialog();

            if (frm.RevertConfirmed) { return true; }
            return false;
        }


        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- BACK ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormPurchasesHistory_FormClosing(object sender, FormClosingEventArgs e)
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
