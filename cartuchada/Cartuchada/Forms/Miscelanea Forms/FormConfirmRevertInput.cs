

using Cartuchada.Forms.Constants;

namespace Cartuchada.Forms.Miscelanea_Forms
{
    public partial class FormConfirmRevertInput : Form
    {
        public bool RevertConfirmed { get; private set; }
        public FormConfirmRevertInput()
        {
            InitializeComponent();
        }

        private void FormConfirmRevertInput_Load(object sender, EventArgs e)
        {
            lbl_confirmRevert.Text = $"Escribe '{UIConstants.REVERT_TEXTBOX_CHECKWORD}' para confirmar:";
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
            if (textBox.Text.Length == UIConstants.REVERT_TEXTBOX_MAX_LENGTH && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------------- OK BUTTON ------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_confirmRevert.Text == UIConstants.REVERT_TEXTBOX_CHECKWORD)
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
