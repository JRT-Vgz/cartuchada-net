

using _1_Domain.Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Services.Cartdrige_Services;
using _2_Services.Services.Console_Services;
using _2_Services.Services.Purchase_Services;
using _3_Repository.Query_Objects;
using Cartuchada.Forms.Sell_Forms.Sell_Cartdrige_Forms;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace Cartuchada.Forms.Sell_Forms.Sell_Console_Forms
{
    public partial class FormSellConsole : Form
    {
        private readonly GetAllConsolesService _getAllConsolesService;
        private readonly FilterConsoleQuery _filterConsoleQuery;
        private readonly IServiceProvider _serviceProvider;
        private readonly RevertPurchaseConsoleService _revertPurchaseConsoleService;
        private readonly SumSparePartsPriceToConsoleById _sumSparePartsPriceToConsoleById;
        private readonly WithdrawSparePartsPriceFromConsoleById _withdrawSparePartsPriceFromConsoleById;

        private IEnumerable<VideoConsole> _filteredVideoConsoles;

        private bool _isClosing = false;

        public bool IsClosing { get { return _isClosing; } }

        private const int MAX_LENGTH_PRICE = 6;

        public FormSellConsole(GetAllConsolesService getAllConsolesService,
            FilterConsoleQuery filterConsoleQuery,
            IServiceProvider serviceProvider,
            RevertPurchaseConsoleService revertPurchaseConsoleService,
            SumSparePartsPriceToConsoleById sumSparePartsPriceToConsoleById,
            WithdrawSparePartsPriceFromConsoleById withdrawSparePartsPriceFromConsoleById)
        {
            InitializeComponent();
            _getAllConsolesService = getAllConsolesService;
            _filterConsoleQuery = filterConsoleQuery;
            _serviceProvider = serviceProvider;
            _revertPurchaseConsoleService = revertPurchaseConsoleService;
            _sumSparePartsPriceToConsoleById = sumSparePartsPriceToConsoleById;
            _withdrawSparePartsPriceFromConsoleById = withdrawSparePartsPriceFromConsoleById;
        }


        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormSellConsole_Load(object sender, EventArgs e)
        {
            CreateColumns();
            await LoadAllData();
            ResetSumSparePartsText();
        }

        private void CreateColumns()
        {
            dgv_consoleCatalogue.AutoGenerateColumns = false;
            dgv_consoleCatalogue.Columns.Clear();
            dgv_consoleCatalogue.DefaultCellStyle.SelectionBackColor = dgv_consoleCatalogue.DefaultCellStyle.BackColor;
            dgv_consoleCatalogue.DefaultCellStyle.SelectionForeColor = dgv_consoleCatalogue.DefaultCellStyle.ForeColor;

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
            dgv_consoleCatalogue.Columns.Add(sellButtonColumn);

            var sumSparePartsButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "colSumSpareParts",
                Text = "+ Piezas",
                UseColumnTextForButtonValue = true,
                Width = 60
            };
            sumSparePartsButtonColumn.DefaultCellStyle.BackColor = Color.Gold;
            sumSparePartsButtonColumn.DefaultCellStyle.SelectionBackColor = Color.Gold;
            dgv_consoleCatalogue.Columns.Add(sumSparePartsButtonColumn);

            var referenceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Ref.",
                DataPropertyName = "Reference",
                Name = "colReference",
                Width = 75
            };
            referenceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            referenceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_consoleCatalogue.Columns.Add(referenceColumn);


            dgv_consoleCatalogue.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Name",
                Name = "colName",
                Width = 385
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
            dgv_consoleCatalogue.Columns.Add(purchasePriceColumn);

            var sparePartsPriceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Piezas",
                DataPropertyName = "SparePartsPrice",
                Name = "colSparePartsPrice",
                Width = 65
            };
            sparePartsPriceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            sparePartsPriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_consoleCatalogue.Columns.Add(sparePartsPriceColumn);

            var totalPriceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Total",
                DataPropertyName = "TotalPrice",
                Name = "colTotalPrice",
                Width = 65
            };
            totalPriceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            totalPriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_consoleCatalogue.Columns.Add(totalPriceColumn);

            //var revertPurchaseButtonColumn = new DataGridViewButtonColumn
            //{
            //    HeaderText = "",
            //    Name = "colRevertPurchase",
            //    Text = "Revertir compra",
            //    UseColumnTextForButtonValue = true,
            //    Width = 95
            //};
            //revertPurchaseButtonColumn.DefaultCellStyle.BackColor = Color.GreenYellow;
            //revertPurchaseButtonColumn.DefaultCellStyle.SelectionBackColor = Color.GreenYellow;
            //dgv_consoleCatalogue.Columns.Add(revertPurchaseButtonColumn);
        }

        private async Task LoadAllData()
        {
            _filteredVideoConsoles = await _getAllConsolesService.ExecuteAsync();
            await RefreshColumns();
        }

        private async Task RefreshColumns()
        {
            int consoleCount = _filteredVideoConsoles.Count();
            AdjustTableSize(consoleCount);

            dgv_consoleCatalogue.DataSource = _filteredVideoConsoles
                .OrderBy(c => c.Reference)
                .ToList();
        }

        private void AdjustTableSize(int consoleCount)
        {
            if (consoleCount > 14) { this.Width = 833; }
            else { this.Width = 816; }
        }

        private void ResetSumSparePartsText()
        {
            txt_sumSparePartsPrice.Text = "0";
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
            _filteredVideoConsoles = await _filterConsoleQuery.ExecuteQueryAsync(c => c.Reference.Name.Contains(searchFilter));
            await RefreshColumns();
        }


        // -------------------------------------------------------------------------------------------------------
        // ----------------------------- SUM / WITHDRAW TO SPARE PARTS TEXTBOX -----------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void txt_sumSparePartsPrice_Enter(object sender, EventArgs e)
        {
            txt_sumSparePartsPrice.Text = "";
        }

        private void txt_sumSparePartsPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == '-' && textBox.SelectionStart == 0) { return; }

                if (e.KeyChar == ',')
                {
                    if (textBox.Text.Contains(',')) { e.Handled = true; }
                }
                else { e.Handled = true; }
            }

            if (textBox.Text.Length == MAX_LENGTH_PRICE && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------- COLUMN BUTTONS ----------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void dgv_consoleCatalogue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            string reference = dgv_consoleCatalogue.Rows[e.RowIndex].Cells["colReference"].Value.ToString();
            var videoConsole = _filteredVideoConsoles.FirstOrDefault(g => g.Reference == reference);

            // SELL CONSOLE BUTTON:
            if (dgv_consoleCatalogue.Columns[e.ColumnIndex].Name == "colSell")
            {
                var frm = _serviceProvider.GetRequiredService<FormManageSellConsole>();
                frm.SetInfo(videoConsole);
                frm.ShowDialog();

                if (frm.VideoConsoleSold)
                {
                    await LoadAllData();
                }

                txt_searchReference.Focus();
            }

            // SUM / WITHDRAW TO SPARE PARTS PRICE BUTTON:
            else if (dgv_consoleCatalogue.Columns[e.ColumnIndex].Name == "colSumSpareParts")
            {
                int videoConsoleId = videoConsole.Id;
                decimal sparePartsPrice;

                try
                {
                    sparePartsPrice = Decimal.Parse(txt_sumSparePartsPrice.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Introduce un precio de recambios correcto.");
                    return;
                }

                try
                {
                    if (sparePartsPrice > 0)
                    {
                        await _sumSparePartsPriceToConsoleById.ExecuteAsync(videoConsoleId, sparePartsPrice);
                    }
                    else if (sparePartsPrice < 0)
                    {
                        await _withdrawSparePartsPriceFromConsoleById.ExecuteAsync(videoConsoleId, sparePartsPrice);
                    }

                    await RefreshColumns();
                    ResetSumSparePartsText();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            // REVERT CONSOLE PURCHASE BUTTON:
            //else if (dgv_consoleCatalogue.Columns[e.ColumnIndex].Name == "colRevertPurchase")
            //{
            //    var confirmRevert = MessageBox.Show($"¿Seguro que quieres revertir la compra de la {videoConsole.Name} con referencia " +
            //        $"{videoConsole.Reference}?",
            //        "Confirmar revertir compra", MessageBoxButtons.YesNo);

            //    if (confirmRevert == DialogResult.Yes) { await RevertConsolePurchase(videoConsole); }
            //}
        }

        private async Task RevertConsolePurchase(VideoConsole videoConsole)
        {
            try
            {
                await _revertPurchaseConsoleService.ExecuteAsync(videoConsole);

                await LoadAllData();
            }
            catch (ProductValidationException ex)
            {
                string message = string.Empty;
                foreach (var error in ex.Errors) { message += $"- {error}\n"; }
                MessageBox.Show(message, ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- BACK ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormSellConsole_FormClosing(object sender, FormClosingEventArgs e)
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
