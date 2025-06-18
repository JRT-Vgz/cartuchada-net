namespace Cartuchada.Forms
{
    partial class FormCartuchadaMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCartuchadaMain));
            lbl_title = new Label();
            lbl_version = new Label();
            btn_purchase = new Button();
            btn_sell = new Button();
            btn_shopStats = new Button();
            btn_log = new Button();
            btn_accounting = new Button();
            SuspendLayout();
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_title.Location = new Point(271, 42);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(255, 50);
            lbl_title.TabIndex = 0;
            lbl_title.Text = "CARTUCHADA";
            lbl_title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_version
            // 
            lbl_version.AutoSize = true;
            lbl_version.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_version.Location = new Point(749, 420);
            lbl_version.Name = "lbl_version";
            lbl_version.Size = new Size(39, 21);
            lbl_version.TabIndex = 1;
            lbl_version.Text = "v1.1";
            // 
            // btn_purchase
            // 
            btn_purchase.Location = new Point(278, 131);
            btn_purchase.Name = "btn_purchase";
            btn_purchase.Size = new Size(238, 33);
            btn_purchase.TabIndex = 2;
            btn_purchase.Text = "COMPRAR";
            btn_purchase.UseVisualStyleBackColor = true;
            btn_purchase.Click += btn_purchase_Click;
            // 
            // btn_sell
            // 
            btn_sell.Location = new Point(278, 197);
            btn_sell.Name = "btn_sell";
            btn_sell.Size = new Size(238, 33);
            btn_sell.TabIndex = 3;
            btn_sell.Text = "VENDER";
            btn_sell.UseVisualStyleBackColor = true;
            btn_sell.Click += btn_sell_Click;
            // 
            // btn_shopStats
            // 
            btn_shopStats.Location = new Point(278, 263);
            btn_shopStats.Name = "btn_shopStats";
            btn_shopStats.Size = new Size(238, 33);
            btn_shopStats.TabIndex = 4;
            btn_shopStats.Text = "ESTADÍSTICAS";
            btn_shopStats.UseVisualStyleBackColor = true;
            btn_shopStats.Click += btn_shopStats_Click;
            // 
            // btn_log
            // 
            btn_log.Location = new Point(12, 411);
            btn_log.Name = "btn_log";
            btn_log.Size = new Size(80, 27);
            btn_log.TabIndex = 5;
            btn_log.Text = "LOG";
            btn_log.UseVisualStyleBackColor = true;
            btn_log.Click += btn_log_Click;
            // 
            // btn_accounting
            // 
            btn_accounting.Location = new Point(278, 329);
            btn_accounting.Name = "btn_accounting";
            btn_accounting.Size = new Size(238, 33);
            btn_accounting.TabIndex = 6;
            btn_accounting.Text = "CONTABILIDAD";
            btn_accounting.UseVisualStyleBackColor = true;
            btn_accounting.Click += btn_accounting_Click;
            // 
            // FormCartuchadaMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_accounting);
            Controls.Add(btn_log);
            Controls.Add(btn_shopStats);
            Controls.Add(btn_sell);
            Controls.Add(btn_purchase);
            Controls.Add(lbl_version);
            Controls.Add(lbl_title);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "FormCartuchadaMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cartuchada";
            Load += FormCartuchadaMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_title;
        private Label lbl_version;
        private Button btn_purchase;
        private Button btn_sell;
        private Button btn_shopStats;
        private Button btn_log;
        private Button btn_accounting;
    }
}