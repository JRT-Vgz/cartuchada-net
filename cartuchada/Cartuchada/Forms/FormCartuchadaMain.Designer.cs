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
            lbl_title = new Label();
            lbl_version = new Label();
            btn_purchase = new Button();
            btn_catalogue = new Button();
            SuspendLayout();
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_title.Location = new Point(275, 64);
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
            lbl_version.Text = "v1.0";
            // 
            // btn_purchase
            // 
            btn_purchase.Location = new Point(282, 163);
            btn_purchase.Name = "btn_purchase";
            btn_purchase.Size = new Size(238, 33);
            btn_purchase.TabIndex = 2;
            btn_purchase.Text = "COMPRAR";
            btn_purchase.UseVisualStyleBackColor = true;
            btn_purchase.Click += btn_purchase_Click;
            // 
            // btn_catalogue
            // 
            btn_catalogue.Location = new Point(282, 229);
            btn_catalogue.Name = "btn_catalogue";
            btn_catalogue.Size = new Size(238, 33);
            btn_catalogue.TabIndex = 3;
            btn_catalogue.Text = "CATÁLOGO";
            btn_catalogue.UseVisualStyleBackColor = true;
            // 
            // FormCartuchadaMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_catalogue);
            Controls.Add(btn_purchase);
            Controls.Add(lbl_version);
            Controls.Add(lbl_title);
            FormBorderStyle = FormBorderStyle.FixedSingle;
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
        private Button btn_catalogue;
    }
}