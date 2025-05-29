using Cartuchada.Forms.Purchase_Forms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cartuchada.Forms
{
    public partial class FormCartuchadaMain : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public FormCartuchadaMain(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        // -------------------------------------------------------------------------------------------------------
        // --------------------------------------------- NAVIGATION ----------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_purchase_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormPurchaseMain>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            if (frm.IsClosing) { return; }

            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        }

    }
}
