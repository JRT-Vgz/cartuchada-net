using _2_Services.Exceptions;
using _2_Services.Services.Purchase_Services;
using _3_Data.Models;
using _3_Mappers.DTOs.Purchase_Dtos;
using _3_Presenters.View_Models;
using _3_Repository.Query_Objects;

namespace Cartuchada.Forms.Purchase_Forms.Purchase_Console_Forms
{
    public partial class FormPurchaseConsole : Form
    {
        private readonly GetAllConsoleProductTypesQuery _getAllConsoleProductTypesQuery;
        private readonly PurchaseConsoleService<ConsolePurchaseDto, ConsolePurchaseViewModel> _purchaseConsoleService;

        private const int MAX_LENGTH_PRICE = 6;

        public FormPurchaseConsole(GetAllConsoleProductTypesQuery getAllConsoleProductTypesQuery,
            PurchaseConsoleService<ConsolePurchaseDto, ConsolePurchaseViewModel> purchaseConsoleService)
        {
            InitializeComponent();
            _getAllConsoleProductTypesQuery = getAllConsoleProductTypesQuery;
            _purchaseConsoleService = purchaseConsoleService;
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormPurchaseConsole_Load(object sender, EventArgs e)
        {
            await LoadConsoleProducts();
        }

        private async Task LoadConsoleProducts()
        {
            var consoles = await _getAllConsoleProductTypesQuery.ExecuteQueryAsync();

            cbo_console.DataSource = consoles;
            cbo_console.DisplayMember = "Name";
            cbo_console.SelectedIndex = 0;
        }




        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------------ TEXT BOXES -------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void txt_purchasePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_purchase_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void txt_purchasePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
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
        // ---------------------------------------- PURCHASE BUTTON ----------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void btn_purchase_Click(object sender, EventArgs e)
        {
            var consolePurchaseDto = new ConsolePurchaseDto();

            try
            {
                decimal purchasePrice = Decimal.Parse(txt_purchasePrice.Text);
                consolePurchaseDto.PurchasePrice = purchasePrice;
            }
            catch (Exception)
            {
                MessageBox.Show("Introduce un precio de compra correcto.");
                return;
            }

            ProductTypeModel productType = (ProductTypeModel)cbo_console.SelectedItem;
            consolePurchaseDto.IdProductType = productType.Id;
            consolePurchaseDto.Name = productType.Name;

            try
            {
                var viewModel = await _purchaseConsoleService.ExecuteAsync(consolePurchaseDto);
                MessageBox.Show(
                    $"{viewModel.Reference}\n\n" +
                    $"{viewModel.Name}\n" +
                    $"{viewModel.PurchasePrice}",
                    "Compra realizada");

                btn_close_Click(sender, e);
            }
            catch (DataValidationException ex)
            {
                string message = string.Empty;
                foreach (var error in ex.Errors) { message += $"- {error}\n"; }
                MessageBox.Show(message, ex.Message);
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
        // ---------------------------------------------- CLOSE --------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
