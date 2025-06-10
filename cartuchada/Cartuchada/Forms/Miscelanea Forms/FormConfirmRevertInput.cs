

namespace Cartuchada.Forms.Miscelanea_Forms
{
    public partial class FormConfirmRevertInput : Form
    {
        public bool RevertConfirmed { get; private set; }

        private const string CONFIRMATION_TEXT = "revertir";
        private const int MAX_TEXT_LENGTH = 8;
        public FormConfirmRevertInput()
        {
            InitializeComponent();
        }

        private void FormConfirmRevertInput_Load(object sender, EventArgs e)
        {
            txt_confirmRevert.Focus();
        }

        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------------- TEXTBOX --------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void txt_confirmRevert_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_ok_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void txt_confirmRevert_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (textBox.Text.Length == MAX_TEXT_LENGTH && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------------- OK BUTTON ------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_confirmRevert.Text == CONFIRMATION_TEXT)
            {
                RevertConfirmed = true;
            }

            this.Close();
        }

        // -------------------------------------------------------------------------------------------------------
        // --------------------------------------------- CLOSE ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
