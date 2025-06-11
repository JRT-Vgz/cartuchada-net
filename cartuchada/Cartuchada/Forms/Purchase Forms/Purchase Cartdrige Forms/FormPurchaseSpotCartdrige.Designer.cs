namespace Cartuchada.Forms.Purchase_Forms.Purchase_Cartdrige_Forms
{
    partial class FormPurchaseSpotCartdrige
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
            lbl_showTitle = new Label();
            lbl_region = new Label();
            cbo_region = new ComboBox();
            lbl_condition = new Label();
            cbo_condition = new ComboBox();
            lbl_purchasePrice = new Label();
            txt_purchasePrice = new TextBox();
            btn_purchase = new Button();
            btn_close = new Button();
            SuspendLayout();
            // 
            // lbl_showTitle
            // 
            lbl_showTitle.AutoSize = true;
            lbl_showTitle.Location = new Point(250, 53);
            lbl_showTitle.Name = "lbl_showTitle";
            lbl_showTitle.Size = new Size(0, 15);
            lbl_showTitle.TabIndex = 1;
            // 
            // lbl_region
            // 
            lbl_region.AutoSize = true;
            lbl_region.Location = new Point(154, 90);
            lbl_region.Name = "lbl_region";
            lbl_region.Size = new Size(47, 15);
            lbl_region.TabIndex = 2;
            lbl_region.Text = "Región:";
            // 
            // cbo_region
            // 
            cbo_region.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_region.FormattingEnabled = true;
            cbo_region.Location = new Point(207, 87);
            cbo_region.Name = "cbo_region";
            cbo_region.Size = new Size(121, 23);
            cbo_region.TabIndex = 3;
            // 
            // lbl_condition
            // 
            lbl_condition.AutoSize = true;
            lbl_condition.Location = new Point(136, 124);
            lbl_condition.Name = "lbl_condition";
            lbl_condition.Size = new Size(65, 15);
            lbl_condition.TabIndex = 4;
            lbl_condition.Text = "Condición:";
            // 
            // cbo_condition
            // 
            cbo_condition.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_condition.FormattingEnabled = true;
            cbo_condition.Location = new Point(207, 121);
            cbo_condition.Name = "cbo_condition";
            cbo_condition.Size = new Size(121, 23);
            cbo_condition.TabIndex = 5;
            // 
            // lbl_purchasePrice
            // 
            lbl_purchasePrice.AutoSize = true;
            lbl_purchasePrice.Location = new Point(98, 158);
            lbl_purchasePrice.Name = "lbl_purchasePrice";
            lbl_purchasePrice.Size = new Size(103, 15);
            lbl_purchasePrice.TabIndex = 6;
            lbl_purchasePrice.Text = "Precio de compra:";
            // 
            // txt_purchasePrice
            // 
            txt_purchasePrice.Location = new Point(207, 155);
            txt_purchasePrice.Name = "txt_purchasePrice";
            txt_purchasePrice.Size = new Size(100, 23);
            txt_purchasePrice.TabIndex = 7;
            txt_purchasePrice.KeyDown += txt_purchasePrice_KeyDown;
            txt_purchasePrice.KeyPress += txt_purchasePrice_KeyPress;
            // 
            // btn_purchase
            // 
            btn_purchase.Location = new Point(130, 221);
            btn_purchase.Name = "btn_purchase";
            btn_purchase.Size = new Size(75, 23);
            btn_purchase.TabIndex = 8;
            btn_purchase.Text = "Comprar";
            btn_purchase.UseVisualStyleBackColor = true;
            btn_purchase.Click += btn_purchase_Click;
            // 
            // btn_close
            // 
            btn_close.Location = new Point(278, 222);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(75, 23);
            btn_close.TabIndex = 9;
            btn_close.Text = "Cerrar";
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // FormPurchaseCartdrige
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 315);
            ControlBox = false;
            Controls.Add(btn_close);
            Controls.Add(btn_purchase);
            Controls.Add(txt_purchasePrice);
            Controls.Add(lbl_purchasePrice);
            Controls.Add(cbo_condition);
            Controls.Add(lbl_condition);
            Controls.Add(cbo_region);
            Controls.Add(lbl_region);
            Controls.Add(lbl_showTitle);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(500, 354);
            MinimizeBox = false;
            MinimumSize = new Size(500, 354);
            Name = "FormPurchaseCartdrige";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Comprar cartucho";
            Load += FormPurchaseCartdrige_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbl_showTitle;
        private Label lbl_region;
        private ComboBox cbo_region;
        private Label lbl_condition;
        private ComboBox cbo_condition;
        private Label lbl_purchasePrice;
        private TextBox txt_purchasePrice;
        private Button btn_purchase;
        private Button btn_close;
    }
}