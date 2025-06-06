namespace Cartuchada.Forms.Sell_Forms.Sell_Cartdrige_Forms
{
    partial class FormManageSellCartdrige
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
            btn_sell = new Button();
            btn_close = new Button();
            lbl_sellPrice = new Label();
            txt_sellPrice = new TextBox();
            lbl_showName = new Label();
            lbl_showReference = new Label();
            lbl_showRegion = new Label();
            lbl_showCondition = new Label();
            lbl_showPurchasePrice = new Label();
            SuspendLayout();
            // 
            // btn_sell
            // 
            btn_sell.Location = new Point(141, 230);
            btn_sell.Name = "btn_sell";
            btn_sell.Size = new Size(75, 23);
            btn_sell.TabIndex = 0;
            btn_sell.Text = "Vender";
            btn_sell.UseVisualStyleBackColor = true;
            btn_sell.Click += btn_sell_Click;
            // 
            // btn_close
            // 
            btn_close.Location = new Point(280, 230);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(75, 23);
            btn_close.TabIndex = 1;
            btn_close.Text = "Cerrar";
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // lbl_sellPrice
            // 
            lbl_sellPrice.AutoSize = true;
            lbl_sellPrice.Location = new Point(106, 164);
            lbl_sellPrice.Name = "lbl_sellPrice";
            lbl_sellPrice.Size = new Size(91, 15);
            lbl_sellPrice.TabIndex = 2;
            lbl_sellPrice.Text = "Precio de venta:";
            // 
            // txt_sellPrice
            // 
            txt_sellPrice.Location = new Point(203, 161);
            txt_sellPrice.Name = "txt_sellPrice";
            txt_sellPrice.Size = new Size(100, 23);
            txt_sellPrice.TabIndex = 3;
            txt_sellPrice.KeyDown += txt_sellPrice_KeyDown;
            txt_sellPrice.KeyPress += txt_sellPrice_KeyPress;
            // 
            // lbl_showName
            // 
            lbl_showName.AutoSize = true;
            lbl_showName.Location = new Point(250, 55);
            lbl_showName.Name = "lbl_showName";
            lbl_showName.Size = new Size(49, 15);
            lbl_showName.TabIndex = 4;
            lbl_showName.Text = "nombre";
            // 
            // lbl_showReference
            // 
            lbl_showReference.AutoSize = true;
            lbl_showReference.Location = new Point(250, 35);
            lbl_showReference.Name = "lbl_showReference";
            lbl_showReference.Size = new Size(21, 15);
            lbl_showReference.TabIndex = 5;
            lbl_showReference.Text = "ref";
            // 
            // lbl_showRegion
            // 
            lbl_showRegion.AutoSize = true;
            lbl_showRegion.Location = new Point(250, 90);
            lbl_showRegion.Name = "lbl_showRegion";
            lbl_showRegion.Size = new Size(41, 15);
            lbl_showRegion.TabIndex = 6;
            lbl_showRegion.Text = "region";
            // 
            // lbl_showCondition
            // 
            lbl_showCondition.AutoSize = true;
            lbl_showCondition.Location = new Point(250, 110);
            lbl_showCondition.Name = "lbl_showCondition";
            lbl_showCondition.Size = new Size(60, 15);
            lbl_showCondition.TabIndex = 7;
            lbl_showCondition.Text = "condicion";
            // 
            // lbl_showPurchasePrice
            // 
            lbl_showPurchasePrice.AutoSize = true;
            lbl_showPurchasePrice.Location = new Point(250, 130);
            lbl_showPurchasePrice.Name = "lbl_showPurchasePrice";
            lbl_showPurchasePrice.Size = new Size(55, 15);
            lbl_showPurchasePrice.TabIndex = 8;
            lbl_showPurchasePrice.Text = "pcompra";
            // 
            // FormManageSellCartdrige
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 315);
            ControlBox = false;
            Controls.Add(lbl_showPurchasePrice);
            Controls.Add(lbl_showCondition);
            Controls.Add(lbl_showRegion);
            Controls.Add(lbl_showReference);
            Controls.Add(lbl_showName);
            Controls.Add(txt_sellPrice);
            Controls.Add(lbl_sellPrice);
            Controls.Add(btn_close);
            Controls.Add(btn_sell);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(500, 354);
            MinimizeBox = false;
            MinimumSize = new Size(500, 354);
            Name = "FormManageSellCartdrige";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Vender cartucho";
            Load += FormManageSellCartdrige_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_sell;
        private Button btn_close;
        private Label lbl_sellPrice;
        private TextBox txt_sellPrice;
        private Label lbl_showName;
        private Label lbl_showReference;
        private Label lbl_showRegion;
        private Label lbl_showCondition;
        private Label lbl_showPurchasePrice;
    }
}