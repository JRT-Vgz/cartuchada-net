namespace Cartuchada.Forms.Purchase_Forms.Purchase_Console_Forms
{
    partial class FormPurchaseConsole
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
            lbl_console = new Label();
            cbo_console = new ComboBox();
            lbl_purchasePrice = new Label();
            txt_purchasePrice = new TextBox();
            btn_purchase = new Button();
            btn_close = new Button();
            SuspendLayout();
            // 
            // lbl_console
            // 
            lbl_console.AutoSize = true;
            lbl_console.Location = new Point(154, 90);
            lbl_console.Name = "lbl_console";
            lbl_console.Size = new Size(53, 15);
            lbl_console.TabIndex = 0;
            lbl_console.Text = "Consola:";
            // 
            // cbo_console
            // 
            cbo_console.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_console.FormattingEnabled = true;
            cbo_console.Location = new Point(213, 87);
            cbo_console.Name = "cbo_console";
            cbo_console.Size = new Size(200, 23);
            cbo_console.TabIndex = 1;
            // 
            // lbl_purchasePrice
            // 
            lbl_purchasePrice.AutoSize = true;
            lbl_purchasePrice.Location = new Point(107, 124);
            lbl_purchasePrice.Name = "lbl_purchasePrice";
            lbl_purchasePrice.Size = new Size(100, 15);
            lbl_purchasePrice.TabIndex = 2;
            lbl_purchasePrice.Text = "Precio de compra";
            // 
            // txt_purchasePrice
            // 
            txt_purchasePrice.Location = new Point(213, 121);
            txt_purchasePrice.Name = "txt_purchasePrice";
            txt_purchasePrice.Size = new Size(100, 23);
            txt_purchasePrice.TabIndex = 3;
            txt_purchasePrice.KeyDown += txt_purchasePrice_KeyDown;
            txt_purchasePrice.KeyPress += txt_purchasePrice_KeyPress;
            // 
            // btn_purchase
            // 
            btn_purchase.Location = new Point(142, 190);
            btn_purchase.Name = "btn_purchase";
            btn_purchase.Size = new Size(75, 23);
            btn_purchase.TabIndex = 4;
            btn_purchase.Text = "Comprar";
            btn_purchase.UseVisualStyleBackColor = true;
            btn_purchase.Click += btn_purchase_Click;
            // 
            // btn_close
            // 
            btn_close.Location = new Point(281, 190);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(75, 23);
            btn_close.TabIndex = 5;
            btn_close.Text = "Cerrar";
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // FormPurchaseConsole
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 315);
            ControlBox = false;
            Controls.Add(btn_close);
            Controls.Add(btn_purchase);
            Controls.Add(txt_purchasePrice);
            Controls.Add(lbl_purchasePrice);
            Controls.Add(cbo_console);
            Controls.Add(lbl_console);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(500, 354);
            MinimizeBox = false;
            MinimumSize = new Size(500, 354);
            Name = "FormPurchaseConsole";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Comprar consola";
            Load += FormPurchaseConsole_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_console;
        private ComboBox cbo_console;
        private Label lbl_purchasePrice;
        private TextBox txt_purchasePrice;
        private Button btn_purchase;
        private Button btn_close;
    }
}