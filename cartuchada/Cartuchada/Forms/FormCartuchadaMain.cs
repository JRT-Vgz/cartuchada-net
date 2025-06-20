using _3_Data;
using Cartuchada.Forms.Miscelanea_Forms;
using Cartuchada.Forms.Purchase_Forms;
using Cartuchada.Forms.Sell_Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Cartuchada.Forms
{
    using Cartuchada.Forms.Constants;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class FormCartuchadaMain : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly AppDbContext _context;

        private bool _dbLoaded = false;

        public FormCartuchadaMain(IServiceProvider serviceProvider,
            AppDbContext context)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _context = context;
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormCartuchadaMain_Shown(object sender, EventArgs e)
        {
            LoadDatabase();
        }

        private async void LoadDatabase()
        {
            var loadingForm = _serviceProvider.GetRequiredService<FormLoadingDb>();

            loadingForm.Location = new Point(
                this.Location.X + (this.Width - loadingForm.Width) / 2,
                this.Location.Y + (this.Height - loadingForm.Height) / 2
            );
            loadingForm.Show();
            loadingForm.Refresh();

            _dbLoaded = await WaitForDatabaseAsync();

            loadingForm.Close();

            if (!_dbLoaded)
            {
                MessageBox.Show("No se pudo conectar a la base de datos.");
                Application.Exit();
            }
        }

        private async Task<bool> WaitForDatabaseAsync()
        {
            for (int i = 0; i < LoadDbConstants.MAX_CONNECTION_RETRIES; i++)
            {
                try
                {
                    _context.ShopStats.Take(0).ToList();
                    return true;
                }
                catch (Exception) { }

                await Task.Delay(LoadDbConstants.TIME_BETWEEN_CONNECTION_TRIES);
            }

            return false;
        }



        // -------------------------------------------------------------------------------------------------------
        // --------------------------------------------- NAVIGATION ----------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_purchase_Click(object sender, EventArgs e)
        {
            if (!_dbLoaded) { return; }

            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormPurchaseMain>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            if (frm.IsClosing) { return; }

            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        }

        private void btn_sell_Click(object sender, EventArgs e)
        {
            if (!_dbLoaded) { return; }

            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormSellMain>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            if (frm.IsClosing) { return; }

            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        }

        private void btn_shopStats_Click(object sender, EventArgs e)
        {
            if (!_dbLoaded) { return; }

            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormStatistics>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            if (frm.IsClosing) { return; }

            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            if (!_dbLoaded) { return; }

            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormLog>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            if (frm.IsClosing) { return; }

            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        }

        private void btn_accounting_Click(object sender, EventArgs e)
        {
            if (!_dbLoaded) { return; }

            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormAccounting>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            if (frm.IsClosing) { return; }

            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        } 
    }
}
