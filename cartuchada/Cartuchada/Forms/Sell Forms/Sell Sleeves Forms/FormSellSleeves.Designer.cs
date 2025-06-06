namespace Cartuchada.Forms.Sell_Forms.Sell_Sleeves_Forms
{
    partial class FormSellSleeves
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
            txt_quantity = new TextBox();
            lbl_quantity = new Label();
            txt_sellPrice = new TextBox();
            lbl_sellPrice = new Label();
            cbo_sleeveType = new ComboBox();
            lbl_sleeveType = new Label();
            SuspendLayout();
            // 
            // btn_sell
            // 
            btn_sell.Location = new Point(131, 185);
            btn_sell.Name = "btn_sell";
            btn_sell.Size = new Size(75, 23);
            btn_sell.TabIndex = 0;
            btn_sell.Text = "Vender";
            btn_sell.UseVisualStyleBackColor = true;
            btn_sell.Click += btn_sell_Click;
            // 
            // btn_close
            // 
            btn_close.Location = new Point(272, 185);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(75, 23);
            btn_close.TabIndex = 1;
            btn_close.Text = "Cerrar";
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // txt_quantity
            // 
            txt_quantity.Location = new Point(181, 100);
            txt_quantity.Name = "txt_quantity";
            txt_quantity.Size = new Size(47, 23);
            txt_quantity.TabIndex = 19;
            txt_quantity.KeyDown += txt_quantity_KeyDown;
            txt_quantity.KeyPress += txt_quantity_KeyPress;
            // 
            // lbl_quantity
            // 
            lbl_quantity.AutoSize = true;
            lbl_quantity.Location = new Point(113, 103);
            lbl_quantity.Name = "lbl_quantity";
            lbl_quantity.Size = new Size(58, 15);
            lbl_quantity.TabIndex = 18;
            lbl_quantity.Text = "Cantidad:";
            // 
            // txt_sellPrice
            // 
            txt_sellPrice.Location = new Point(181, 135);
            txt_sellPrice.Name = "txt_sellPrice";
            txt_sellPrice.Size = new Size(100, 23);
            txt_sellPrice.TabIndex = 17;
            txt_sellPrice.KeyDown += txt_sellPrice_KeyDown;
            txt_sellPrice.KeyPress += txt_sellPrice_KeyPress;
            // 
            // lbl_sellPrice
            // 
            lbl_sellPrice.AutoSize = true;
            lbl_sellPrice.Location = new Point(75, 138);
            lbl_sellPrice.Name = "lbl_sellPrice";
            lbl_sellPrice.Size = new Size(91, 15);
            lbl_sellPrice.TabIndex = 16;
            lbl_sellPrice.Text = "Precio de venta:";
            // 
            // cbo_sleeveType
            // 
            cbo_sleeveType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_sleeveType.FormattingEnabled = true;
            cbo_sleeveType.Location = new Point(181, 65);
            cbo_sleeveType.Name = "cbo_sleeveType";
            cbo_sleeveType.Size = new Size(200, 23);
            cbo_sleeveType.TabIndex = 15;
            // 
            // lbl_sleeveType
            // 
            lbl_sleeveType.AutoSize = true;
            lbl_sleeveType.Location = new Point(92, 68);
            lbl_sleeveType.Name = "lbl_sleeveType";
            lbl_sleeveType.Size = new Size(83, 15);
            lbl_sleeveType.TabIndex = 14;
            lbl_sleeveType.Text = "Tipo de funda:";
            // 
            // FormSellSleeves
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 315);
            ControlBox = false;
            Controls.Add(txt_quantity);
            Controls.Add(lbl_quantity);
            Controls.Add(txt_sellPrice);
            Controls.Add(lbl_sellPrice);
            Controls.Add(cbo_sleeveType);
            Controls.Add(lbl_sleeveType);
            Controls.Add(btn_close);
            Controls.Add(btn_sell);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(500, 354);
            MinimizeBox = false;
            MinimumSize = new Size(500, 354);
            Name = "FormSellSleeves";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Vender Fundas";
            Load += FormSellSleeves_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_sell;
        private Button btn_close;
        private TextBox txt_quantity;
        private Label lbl_quantity;
        private TextBox txt_sellPrice;
        private Label lbl_sellPrice;
        private ComboBox cbo_sleeveType;
        private Label lbl_sleeveType;
    }
}