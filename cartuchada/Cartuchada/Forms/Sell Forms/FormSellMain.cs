using Cartuchada.Forms.Purchase_Forms.Purchase_Spare_Parts_Forms;
using Cartuchada.Forms.Sell_Forms.Sell_Cartdrige_Forms;
using Cartuchada.Forms.Sell_Forms.Sell_Console_Forms;
using Cartuchada.Forms.Sell_Forms.Sell_Sleeves_Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Cartuchada.Forms.Sell_Forms
{
    public partial class FormSellMain : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private bool _isClosing = false;

        public bool IsClosing { get { return _isClosing; } }

        public FormSellMain(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }


        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------------- NAVEGACIÓN ------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_sellCartdrige_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormSellCartdrige>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            if (frm.IsClosing) { return; }

            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        }

        private void btn_sellConsole_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormSellConsole>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            if (frm.IsClosing) { return; }

            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        }

        private void btn_sellSleeves_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<FormSellSleeves>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();
        }

        private void btn_saleHistory_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormSalesHistory>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            if (frm.IsClosing) { return; }

            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        }


        // -------------------------------------------------------------------------------------------------------
        // --------------------------------------------- VOLVER --------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormSellMain_FormClosing(object sender, FormClosingEventArgs e)
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
