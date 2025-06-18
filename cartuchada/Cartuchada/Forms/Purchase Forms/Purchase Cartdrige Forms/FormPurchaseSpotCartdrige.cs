using _2_Services.Exceptions;
using _2_Services.Interfaces;
using _2_Services.Services.Cartdrige_Services;
using _2_Services.Services.Purchase_Services;
using _3_Data.Models;
using _3_Mappers.DTOs.Purchase_Dtos;
using _3_Presenters.View_Models;
using Cartuchada.Forms.Constants;


namespace Cartuchada.Forms.Purchase_Forms.Purchase_Cartdrige_Forms
{
    public partial class FormPurchaseSpotCartdrige : Form
    {
        private readonly PurchaseCartdrigeService<CartdrigePurchaseDto, CartdrigePurchaseViewModel> _purchaseCartdrigeService;
        private readonly SpotCartdrigePurchaseService<CartdrigePurchaseDto, SpotCartdrigeViewModel> _spotCartdrigePurchaseService;
        private readonly IGetAllQuery<RegionModel> _getAllRegionsQuery;
        private readonly IGetAllQuery<ConditionModel> _getAllConditionsQuery;

        private bool _isSpotting = false;
        public bool IsSpotting { get => _isSpotting; set => _isSpotting = value; }

        private CartdrigePurchaseDto _cartdrigePurchaseDto;

        public FormPurchaseSpotCartdrige(
            PurchaseCartdrigeService<CartdrigePurchaseDto, CartdrigePurchaseViewModel> purchaseCartdrigeService,
            SpotCartdrigePurchaseService<CartdrigePurchaseDto, SpotCartdrigeViewModel> spotCartdrigePurchaseService,
            IGetAllQuery<RegionModel> getAllRegionsQuery,
            IGetAllQuery<ConditionModel> getAllConditionsQuery)
        {
            InitializeComponent();
            _purchaseCartdrigeService = purchaseCartdrigeService;
            _spotCartdrigePurchaseService = spotCartdrigePurchaseService;
            _getAllRegionsQuery = getAllRegionsQuery;
            _getAllConditionsQuery = getAllConditionsQuery;
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        public void SetInfo(CartdrigePurchaseDto cartdrigePurchaseDto)
        {
            _cartdrigePurchaseDto = cartdrigePurchaseDto;

            lbl_showTitle.Text = _cartdrigePurchaseDto.Name;
            lbl_purchasePrice.Text = "Precio de spot:";

            if (IsSpotting)
            {
                this.Text = "Spotear cartucho";
                btn_purchase.Text = "Spotear";
            }
        }

        private async void FormPurchaseCartdrige_Load(object sender, EventArgs e)
        {
            CenterNameLabel(lbl_showTitle);
            await LoadRegions();
            await LoadConditions();
        }

        private void CenterNameLabel(Label label)
        {
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.AutoSize = false;

            if (label.Parent != null)
            {
                label.Left = 0;
                label.Width = label.Parent.ClientSize.Width;
            }
        }

        private async Task LoadRegions()
        {
            var regions = (await _getAllRegionsQuery.ExecuteQueryAsync()).ToList();

            RemoveCartdrigeUnreleasedRegions(regions);

            cbo_region.DataSource = regions;
            cbo_region.DisplayMember = "Name";

            int palIndex = regions.FindIndex(r => r.Name.Contains("PAL"));
            cbo_region.SelectedIndex = palIndex >= 0 ? palIndex : 0;
        }

        private void RemoveCartdrigeUnreleasedRegions(List<RegionModel> regions)
        {
            if (!_cartdrigePurchaseDto.JAP) { regions.Remove(regions.FirstOrDefault(r => r.Name.Contains("JAP"))); }
            if (!_cartdrigePurchaseDto.NA) { regions.Remove(regions.FirstOrDefault(r => r.Name.Contains("NA"))); }
            if (!_cartdrigePurchaseDto.PAL) { regions.RemoveAll(r => r.Name.Contains("PAL")); }
        }

        private async Task LoadConditions()
        {
            var conditions = await _getAllConditionsQuery.ExecuteQueryAsync();

            cbo_condition.DataSource = conditions;
            cbo_condition.DisplayMember = "Name";
            cbo_condition.SelectedIndex = 4;
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

            if (textBox.Text.Length == UIConstants.PRICE_TEXTBOX_MAX_LENGTH && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------- PURCHASE BUTTON ----------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void btn_purchase_Click(object sender, EventArgs e)
        {
            try
            {
                decimal purchasePrice = Decimal.Parse(txt_purchasePrice.Text);
                _cartdrigePurchaseDto.PurchasePrice = purchasePrice;
            }
            catch (Exception)
            {
                MessageBox.Show("Introduce un precio de compra correcto.");
                return;
            }

            RegionModel region = (RegionModel)cbo_region.SelectedItem;
            ConditionModel condition = (ConditionModel)cbo_condition.SelectedItem;
            _cartdrigePurchaseDto.IdRegion = region.Id;
            _cartdrigePurchaseDto.IdCondition = condition.Id;
            _cartdrigePurchaseDto.Region = region.Name;
            _cartdrigePurchaseDto.Condition = condition.Name;

            if (IsSpotting) { await SpotCartdrige(); }
            else { PurchaseCartdrige(); }

            btn_close_Click(sender, e);
        }

        private async Task PurchaseCartdrige()
        {
            try
            {
                var viewModel = await _purchaseCartdrigeService.ExecuteAsync(_cartdrigePurchaseDto);
                MessageBox.Show(
                    $"{viewModel.Reference}\n\n" +
                    $"{viewModel.Name}\n" +
                    $"{viewModel.ProductType}\n" +
                    $"{viewModel.Region}\n" +
                    $"{viewModel.Condition}\n" +
                    $"{viewModel.PurchasePrice}",
                    "Compra realizada");
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
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private async Task SpotCartdrige()
        {
            try
            {
                var viewModel = await _spotCartdrigePurchaseService.ExecuteAsync(_cartdrigePurchaseDto);
                MessageBox.Show(
                    $"{viewModel.SpotAction}\n\n" +
                    $"{viewModel.Name}\n" +
                    $"{viewModel.ProductType}\n" +
                    $"{viewModel.Region}\n" +
                    $"{viewModel.Condition}\n" +
                    $"{viewModel.SpotPrice}",
                    "Cartucho spoteado");
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
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
