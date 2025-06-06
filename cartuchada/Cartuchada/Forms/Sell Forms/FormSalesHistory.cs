

namespace Cartuchada.Forms.Sell_Forms
{
    public partial class FormSalesHistory : Form
    {

        private bool _isClosing = false;

        public bool IsClosing { get { return _isClosing; } }

        public FormSalesHistory()
        {
            InitializeComponent();
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormSalesHistory_Load(object sender, EventArgs e)
        {

        }



        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------- COLUMN BUTTONS ----------------------------------------------
        // -------------------------------------------------------------------------------------------------------




        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- BACK ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormSalesHistory_FormClosing(object sender, FormClosingEventArgs e)
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
