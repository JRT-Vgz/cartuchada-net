namespace Cartuchada.Forms.Purchase_Forms
{
    partial class FormPurchaseMain
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
            btn_menuPrincipal = new Button();
            btn_purchaseCartdrige = new Button();
            btn_purchaseVideoconsole = new Button();
            btn_purchaseSpareParts = new Button();
            SuspendLayout();
            // 
            // btn_menuPrincipal
            // 
            btn_menuPrincipal.Location = new Point(12, 12);
            btn_menuPrincipal.Name = "btn_menuPrincipal";
            btn_menuPrincipal.Size = new Size(99, 23);
            btn_menuPrincipal.TabIndex = 0;
            btn_menuPrincipal.Text = "Menú principal";
            btn_menuPrincipal.UseVisualStyleBackColor = true;
            btn_menuPrincipal.Click += btn_menuPrincipal_Click;
            // 
            // btn_purchaseCartdrige
            // 
            btn_purchaseCartdrige.Location = new Point(282, 97);
            btn_purchaseCartdrige.Name = "btn_purchaseCartdrige";
            btn_purchaseCartdrige.Size = new Size(238, 33);
            btn_purchaseCartdrige.TabIndex = 1;
            btn_purchaseCartdrige.Text = "COMPRAR CARTUCHO";
            btn_purchaseCartdrige.UseVisualStyleBackColor = true;
            btn_purchaseCartdrige.Click += btn_purchaseCartdrige_Click;
            // 
            // btn_purchaseVideoconsole
            // 
            btn_purchaseVideoconsole.Location = new Point(282, 163);
            btn_purchaseVideoconsole.Name = "btn_purchaseVideoconsole";
            btn_purchaseVideoconsole.Size = new Size(238, 33);
            btn_purchaseVideoconsole.TabIndex = 2;
            btn_purchaseVideoconsole.Text = "COMPAR VIDEOCONSOLA";
            btn_purchaseVideoconsole.UseVisualStyleBackColor = true;
            btn_purchaseVideoconsole.Click += btn_purchaseVideoconsole_Click;
            // 
            // btn_purchaseSpareParts
            // 
            btn_purchaseSpareParts.Location = new Point(282, 229);
            btn_purchaseSpareParts.Name = "btn_purchaseSpareParts";
            btn_purchaseSpareParts.Size = new Size(238, 33);
            btn_purchaseSpareParts.TabIndex = 3;
            btn_purchaseSpareParts.Text = "COMPRAR RECAMBIOS";
            btn_purchaseSpareParts.UseVisualStyleBackColor = true;
            btn_purchaseSpareParts.Click += btn_purchaseSpareParts_Click;
            // 
            // FormPurchaseMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_purchaseSpareParts);
            Controls.Add(btn_purchaseVideoconsole);
            Controls.Add(btn_purchaseCartdrige);
            Controls.Add(btn_menuPrincipal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "FormPurchaseMain";
            StartPosition = FormStartPosition.Manual;
            Text = "Comprar";
            FormClosing += FormPurchaseMain_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_menuPrincipal;
        private Button btn_purchaseCartdrige;
        private Button btn_purchaseVideoconsole;
        private Button btn_purchaseSpareParts;
    }
}