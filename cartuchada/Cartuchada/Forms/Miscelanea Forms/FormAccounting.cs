
namespace Cartuchada.Forms.Miscelanea_Forms
{
    public partial class FormAccounting : Form
    {

        private bool _isClosing = false;

        public bool IsClosing { get { return _isClosing; } }

        public FormAccounting()
        {
            InitializeComponent();
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormAccounting_Load(object sender, EventArgs e)
        {
            var years = new string[] { "uno" };

            cbo_yearFilter.DataSource = years;
            cbo_yearFilter.SelectedIndex = 0;
        }



        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- BACK ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormAccounting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                _isClosing = true;
                Application.Exit();
            }
        }

        private void btn_mainMenu_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
