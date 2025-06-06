namespace Cartuchada.Forms.Sell_Forms.Sell_Console_Forms
{
    partial class FormManageSellConsole
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
            lbl_showTotalPrice = new Label();
            lbl_showReference = new Label();
            lbl_showName = new Label();
            txt_sellPrice = new TextBox();
            lbl_sellPrice = new Label();
            btn_close = new Button();
            btn_sell = new Button();
            SuspendLayout();
            // 
            // lbl_showTotalPrice
            // 
            lbl_showTotalPrice.AutoSize = true;
            lbl_showTotalPrice.Location = new Point(262, 105);
            lbl_showTotalPrice.Name = "lbl_showTotalPrice";
            lbl_showTotalPrice.Size = new Size(55, 15);
            lbl_showTotalPrice.TabIndex = 17;
            lbl_showTotalPrice.Text = "pcompra";
            // 
            // lbl_showReference
            // 
            lbl_showReference.AutoSize = true;
            lbl_showReference.Location = new Point(262, 48);
            lbl_showReference.Name = "lbl_showReference";
            lbl_showReference.Size = new Size(21, 15);
            lbl_showReference.TabIndex = 14;
            lbl_showReference.Text = "ref";
            // 
            // lbl_showName
            // 
            lbl_showName.AutoSize = true;
            lbl_showName.Location = new Point(262, 68);
            lbl_showName.Name = "lbl_showName";
            lbl_showName.Size = new Size(49, 15);
            lbl_showName.TabIndex = 13;
            lbl_showName.Text = "nombre";
            // 
            // txt_sellPrice
            // 
            txt_sellPrice.Location = new Point(214, 136);
            txt_sellPrice.Name = "txt_sellPrice";
            txt_sellPrice.Size = new Size(100, 23);
            txt_sellPrice.TabIndex = 12;
            txt_sellPrice.KeyDown += txt_sellPrice_KeyDown;
            txt_sellPrice.KeyPress += txt_sellPrice_KeyPress;
            // 
            // lbl_sellPrice
            // 
            lbl_sellPrice.AutoSize = true;
            lbl_sellPrice.Location = new Point(117, 139);
            lbl_sellPrice.Name = "lbl_sellPrice";
            lbl_sellPrice.Size = new Size(91, 15);
            lbl_sellPrice.TabIndex = 11;
            lbl_sellPrice.Text = "Precio de venta:";
            // 
            // btn_close
            // 
            btn_close.Location = new Point(291, 205);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(75, 23);
            btn_close.TabIndex = 10;
            btn_close.Text = "Cerrar";
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // btn_sell
            // 
            btn_sell.Location = new Point(152, 205);
            btn_sell.Name = "btn_sell";
            btn_sell.Size = new Size(75, 23);
            btn_sell.TabIndex = 9;
            btn_sell.Text = "Vender";
            btn_sell.UseVisualStyleBackColor = true;
            btn_sell.Click += btn_sell_Click;
            // 
            // FormManageSellConsole
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 315);
            ControlBox = false;
            Controls.Add(lbl_showTotalPrice);
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
            Name = "FormManageSellConsole";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Vender consola";
            Load += FormManageSellConsole_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_showTotalPrice;
        private Label lbl_showReference;
        private Label lbl_showName;
        private TextBox txt_sellPrice;
        private Label lbl_sellPrice;
        private Button btn_close;
        private Button btn_sell;
    }
}