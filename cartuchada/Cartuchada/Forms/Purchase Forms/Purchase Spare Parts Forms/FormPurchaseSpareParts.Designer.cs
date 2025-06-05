namespace Cartuchada.Forms.Purchase_Forms.Purchase_Spare_Parts_Forms
{
    partial class FormPurchaseSpareParts
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
            btn_close = new Button();
            btn_purchase = new Button();
            txt_purchasePrice = new TextBox();
            lbl_purchasePrice = new Label();
            cbo_spareParts = new ComboBox();
            lbl_spareParts = new Label();
            lbl_concept = new Label();
            txt_concept = new TextBox();
            SuspendLayout();
            // 
            // btn_close
            // 
            btn_close.Location = new Point(265, 203);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(75, 23);
            btn_close.TabIndex = 11;
            btn_close.Text = "Cerrar";
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // btn_purchase
            // 
            btn_purchase.Location = new Point(126, 203);
            btn_purchase.Name = "btn_purchase";
            btn_purchase.Size = new Size(75, 23);
            btn_purchase.TabIndex = 10;
            btn_purchase.Text = "Comprar";
            btn_purchase.UseVisualStyleBackColor = true;
            btn_purchase.Click += btn_purchase_Click;
            // 
            // txt_purchasePrice
            // 
            txt_purchasePrice.Location = new Point(186, 149);
            txt_purchasePrice.Name = "txt_purchasePrice";
            txt_purchasePrice.Size = new Size(100, 23);
            txt_purchasePrice.TabIndex = 9;
            txt_purchasePrice.KeyDown += txt_purchasePrice_KeyDown;
            txt_purchasePrice.KeyPress += txt_purchasePrice_KeyPress;
            // 
            // lbl_purchasePrice
            // 
            lbl_purchasePrice.AutoSize = true;
            lbl_purchasePrice.Location = new Point(80, 152);
            lbl_purchasePrice.Name = "lbl_purchasePrice";
            lbl_purchasePrice.Size = new Size(100, 15);
            lbl_purchasePrice.TabIndex = 8;
            lbl_purchasePrice.Text = "Precio de compra";
            // 
            // cbo_spareParts
            // 
            cbo_spareParts.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_spareParts.FormattingEnabled = true;
            cbo_spareParts.Location = new Point(186, 79);
            cbo_spareParts.Name = "cbo_spareParts";
            cbo_spareParts.Size = new Size(200, 23);
            cbo_spareParts.TabIndex = 7;
            // 
            // lbl_spareParts
            // 
            lbl_spareParts.AutoSize = true;
            lbl_spareParts.Location = new Point(117, 82);
            lbl_spareParts.Name = "lbl_spareParts";
            lbl_spareParts.Size = new Size(63, 15);
            lbl_spareParts.TabIndex = 6;
            lbl_spareParts.Text = "Recambio:";
            // 
            // lbl_concept
            // 
            lbl_concept.AutoSize = true;
            lbl_concept.Location = new Point(118, 117);
            lbl_concept.Name = "lbl_concept";
            lbl_concept.Size = new Size(62, 15);
            lbl_concept.TabIndex = 12;
            lbl_concept.Text = "Concepto:";
            // 
            // txt_concept
            // 
            txt_concept.Location = new Point(186, 114);
            txt_concept.Name = "txt_concept";
            txt_concept.Size = new Size(232, 23);
            txt_concept.TabIndex = 13;
            txt_concept.KeyDown += txt_concept_KeyDown;
            txt_concept.KeyPress += txt_concept_KeyPress;
            // 
            // FormPurchaseSpareParts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 315);
            ControlBox = false;
            Controls.Add(txt_concept);
            Controls.Add(lbl_concept);
            Controls.Add(btn_close);
            Controls.Add(btn_purchase);
            Controls.Add(txt_purchasePrice);
            Controls.Add(lbl_purchasePrice);
            Controls.Add(cbo_spareParts);
            Controls.Add(lbl_spareParts);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(500, 354);
            MinimizeBox = false;
            MinimumSize = new Size(500, 354);
            Name = "FormPurchaseSpareParts";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Comprar recambios";
            Load += FormPurchaseSpareParts_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_close;
        private Button btn_purchase;
        private TextBox txt_purchasePrice;
        private Label lbl_purchasePrice;
        private ComboBox cbo_spareParts;
        private Label lbl_spareParts;
        private Label lbl_concept;
        private TextBox txt_concept;
    }
}