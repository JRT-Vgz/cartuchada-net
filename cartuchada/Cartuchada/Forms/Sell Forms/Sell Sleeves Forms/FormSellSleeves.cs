

using _2_Services.Exceptions;
using _2_Services.Interfaces;
using _2_Services.Services.SaleServices;
using _3_Data.Models.Spare_Parts_Models;
using _3_Mappers.DTOs.Purchase_Dtos;
using _3_Mappers.DTOs.Sale_Dtos;
using _3_Presenters.View_Models;
using _3_Repository.Query_Objects;

namespace Cartuchada.Forms.Sell_Forms.Sell_Sleeves_Forms
{
    public partial class FormSellSleeves : Form
    {
        private readonly GetAllSleevesQuery _getAllSleevesQuery;
        private readonly SellSleeveService<SleeveSaleDto, SleeveSaleViewModel> _sellSleeveService;

        private const int MAX_LENGTH_QUANTITY = 4;
        private const int MAX_LENGTH_PRICE = 6;

        public FormSellSleeves(GetAllSleevesQuery getAllSleevesQuery,
            SellSleeveService<SleeveSaleDto, SleeveSaleViewModel> sellSleeveService)
        {
            InitializeComponent();
            _getAllSleevesQuery = getAllSleevesQuery;
            _sellSleeveService = sellSleeveService;
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormSellSleeves_Load(object sender, EventArgs e)
        {
            await LoadSleeveTypes();
        }

        private async Task LoadSleeveTypes()
        {
            var sleeves = await _getAllSleevesQuery.ExecuteQueryAsync();

            cbo_sleeveType.DataSource = sleeves;
            cbo_sleeveType.DisplayMember = "Name";
            cbo_sleeveType.SelectedIndex = 0;
        }

        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------------ TEXT BOXES -------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        // QUANTITY TEXTBOX:
        private void txt_quantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_sellPrice.Focus();
            }
        }

        private void txt_quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (textBox.Text.Length == MAX_LENGTH_QUANTITY && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        // SELL PRICE TEXTBOX:
        private void txt_sellPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_sell_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void txt_sellPrice_KeyPress(object sender, KeyPressEventArgs e)
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
        // ------------------------------------------ SELL BUTTON ------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void btn_sell_Click(object sender, EventArgs e)
        {
            var sleeveSaleDto = new SleeveSaleDto();

            try
            {
                int quantity = int.Parse(txt_quantity.Text);
                sleeveSaleDto.Quantity = quantity;
            }
            catch (Exception)
            {
                MessageBox.Show("Introduce una cantidad correcta.");
                return;
            }

            try
            {
                decimal salePrice = Decimal.Parse(txt_sellPrice.Text);
                sleeveSaleDto.SalePrice = salePrice;
            }
            catch (Exception)
            {
                MessageBox.Show("Introduce un precio de venta correcto.");
                return;
            }

            SparePartTypeModel sleeveType = (SparePartTypeModel)cbo_sleeveType.SelectedItem;
            sleeveSaleDto.IdSparePartType = sleeveType.Id;
            sleeveSaleDto.Name = sleeveType.Name;

            try
            {
                var viewModel = await _sellSleeveService.ExecuteAsync(sleeveSaleDto);
                MessageBox.Show(
                    $"{viewModel.SparePartType}\n\n" +
                    $"{viewModel.Quantity}\n\n" +
                    $"{viewModel.SalePrice}",
                    "Venta realizada");

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
