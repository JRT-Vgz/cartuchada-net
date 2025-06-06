using _1_Domain.Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Services.SaleServices;


namespace Cartuchada.Forms.Sell_Forms.Sell_Console_Forms
{
    public partial class FormManageSellConsole : Form
    {
        private readonly SellConsoleService _sellConsoleService;

        private VideoConsole _videoConsole;
        private bool _videoConsoleSold = false;

        public bool VideoConsoleSold { get { return _videoConsoleSold; } }

        private const int MAX_LENGTH_PRICE = 6;

        public FormManageSellConsole(SellConsoleService sellConsoleService)
        {
            InitializeComponent();
            _sellConsoleService = sellConsoleService;
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormManageSellConsole_Load(object sender, EventArgs e)
        {
            CenterAllInfoLabels();
        }

        private void CenterAllInfoLabels()
        {
            var showInfoLabelsArray = new Label[]
            {
                lbl_showReference,
                lbl_showName,
                lbl_showTotalPrice
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

        public void SetInfo(VideoConsole videoConsole)
        {
            _videoConsole = videoConsole;

            lbl_showReference.Text = _videoConsole.Reference;
            lbl_showName.Text = _videoConsole.Name;
            lbl_showTotalPrice.Text = $"{_videoConsole.TotalPrice.ToString()}€";
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

            var confirmResult = MessageBox.Show($"¿Vender la consola por {sellPrice}€?",
                    "Confirmar venta", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    await _sellConsoleService.ExecuteAsync(_videoConsole, sellPrice);

                    _videoConsoleSold = true;
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
