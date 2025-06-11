

using _2_Services.Exceptions;
using _2_Services.Interfaces;
using _2_Services.Services.Purchase_Services;
using _3_Data.Models.Spare_Parts_Models;
using _3_Mappers.DTOs.Purchase_Dtos;
using _3_Presenters.View_Models;
using _3_Repository.Query_Objects;

namespace Cartuchada.Forms.Purchase_Forms.Purchase_Spare_Parts_Forms
{
    public partial class FormPurchaseSpareParts : Form
    {
        private readonly IGetAllQuery<SparePartTypeModel> _getAllSparePartTypesQuery;
        private readonly PurchaseSparePartsService<SparePartsPurchaseDto, SparePartsPurchaseViewModel> _purchaseSparePartsService;

        private const int MAX_LENGTH_CONCEPT = 125;
        private const int MAX_LENGTH_PRICE = 6;

        public FormPurchaseSpareParts(IGetAllQuery<SparePartTypeModel> getAllSparePartTypesQuery,
            PurchaseSparePartsService<SparePartsPurchaseDto, SparePartsPurchaseViewModel> purchaseSparePartsService)
        {
            InitializeComponent();
            _getAllSparePartTypesQuery = getAllSparePartTypesQuery;
            _purchaseSparePartsService = purchaseSparePartsService;
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormPurchaseSpareParts_Load(object sender, EventArgs e)
        {
            await LoadSparePartTypes();
        }

        private async Task LoadSparePartTypes()
        {
            var sparePartTypes = await _getAllSparePartTypesQuery.ExecuteQueryAsync();

            cbo_spareParts.DataSource = sparePartTypes;
            cbo_spareParts.DisplayMember = "Name";
            cbo_spareParts.SelectedIndex = 0;
        }


        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------------ TEXT BOXES -------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void txt_concept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_purchasePrice.Focus();
            }
        }

        private void txt_concept_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (textBox.Text.Length == MAX_LENGTH_CONCEPT && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

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
            var sparePartsPurchaseDto = new SparePartsPurchaseDto();

            try
            {
                decimal purchasePrice = Decimal.Parse(txt_purchasePrice.Text);
                sparePartsPurchaseDto.PurchasePrice = purchasePrice;
            }
            catch (Exception)
            {
                MessageBox.Show("Introduce un precio de compra correcto.");
                return;
            }

            SparePartTypeModel sparePartType = (SparePartTypeModel)cbo_spareParts.SelectedItem;
            sparePartsPurchaseDto.IdSparePartType = sparePartType.Id;
            sparePartsPurchaseDto.Concept = txt_concept.Text;
            sparePartsPurchaseDto.Name = sparePartType.Name;

            try
            {
                var viewModel = await _purchaseSparePartsService.ExecuteAsync(sparePartsPurchaseDto);
                MessageBox.Show(
                    $"{viewModel.SparePartType}\n\n" +
                    $"{viewModel.Concept}\n\n" +
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
