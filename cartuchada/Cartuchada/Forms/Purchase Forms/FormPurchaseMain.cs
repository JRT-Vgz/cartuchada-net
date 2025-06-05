using Cartuchada.Forms.Purchase_Forms.Purchase_Cartdrige_Forms;
using Cartuchada.Forms.Purchase_Forms.Purchase_Console_Forms;
using Cartuchada.Forms.Purchase_Forms.Purchase_Spare_Parts_Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Cartuchada.Forms.Purchase_Forms
{
    public partial class FormPurchaseMain : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private bool _isClosing = false;

        public bool IsClosing { get { return _isClosing; } }

        public FormPurchaseMain(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }




        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------------- NAVEGACIÓN ------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_purchaseCartdrige_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormGameCatalogue>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            if (frm.IsClosing) { return; }

            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        }

        private void btn_purchaseVideoconsole_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<FormPurchaseConsole>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();
        }

        private void btn_purchaseSpareParts_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<FormPurchaseSpareParts>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();
        }

        // -------------------------------------------------------------------------------------------------------
        // --------------------------------------------- VOLVER --------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormPurchaseMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                _isClosing = true;
                Application.Exit();
            }
        }

        private void btn_menuPrincipal_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
