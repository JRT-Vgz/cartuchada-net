using _1_Domain.Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Services.SaleServices;
using Cartuchada.Forms.Constants;


namespace Cartuchada.Forms.Sell_Forms.Sell_Cartdrige_Forms
{
    public partial class FormManageSellCartdrige : Form
    {
        private readonly SellCartdrigeService _sellCartdrigeService;

        private Cartdrige _cartdrige;
        private bool _cartdrigeSold = false;

        public bool CartdrigeSold { get { return _cartdrigeSold; } }

        public FormManageSellCartdrige(SellCartdrigeService sellCartdrigeService)
        {
            InitializeComponent();
            _sellCartdrigeService = sellCartdrigeService;
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormManageSellCartdrige_Load(object sender, EventArgs e)
        {
            CenterAllInfoLabels();
        }

        private void CenterAllInfoLabels()
        {
            var showInfoLabelsArray = new Label[]
            {
                lbl_showReference,
                lbl_showName,
                lbl_showRegion,
                lbl_showCondition,
                lbl_showPurchasePrice
            };

            foreach (var label in showInfoLabelsArray) { CenterLabel(label); }
        }

        private void CenterLabel(Label label)
        {
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.AutoSize = false;

            if (label.Parent != null)
            {
                label.Left = 0;
                label.Width = label.Parent.ClientSize.Width;
            }
        }

        public void SetInfo(Cartdrige cartdrige)
        {
            _cartdrige = cartdrige;

            lbl_showReference.Text = _cartdrige.Reference;
            lbl_showName.Text = _cartdrige.Name;
            lbl_showRegion.Text = _cartdrige.Region;
            lbl_showCondition.Text = _cartdrige.Condition;
            lbl_showPurchasePrice.Text = $"{_cartdrige.PurchasePrice.ToString()}€";
        }


        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------------- TEXT BOX --------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
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

            if (textBox.Text.Length == UIConstants.PRICE_TEXTBOX_MAX_LENGTH && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------------ SELL BUTTON ------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void btn_sell_Click(object sender, EventArgs e)
        {
            decimal sellPrice;

            try
            {
                sellPrice = Decimal.Parse(txt_sellPrice.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Introduce un precio de venta correcto.");
                return;
            }

            var confirmResult = MessageBox.Show($"¿Vender el cartucho por {sellPrice}€?",
                    "Confirmar venta", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    await _sellCartdrigeService.ExecuteAsync(_cartdrige, sellPrice);

                    _cartdrigeSold = true;
                    btn_close_Click(sender, e);
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
