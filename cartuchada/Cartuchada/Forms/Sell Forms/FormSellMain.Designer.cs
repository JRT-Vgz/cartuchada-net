namespace Cartuchada.Forms.Sell_Forms
{
    partial class FormSellMain
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
            btn_mainMenu = new Button();
            btn_sellCartdrige = new Button();
            btn_sellConsole = new Button();
            btn_sellSleeves = new Button();
            btn_salesHistory = new Button();
            SuspendLayout();
            // 
            // btn_mainMenu
            // 
            btn_mainMenu.Location = new Point(12, 12);
            btn_mainMenu.Name = "btn_mainMenu";
            btn_mainMenu.Size = new Size(99, 23);
            btn_mainMenu.TabIndex = 0;
            btn_mainMenu.Text = "Menú principal";
            btn_mainMenu.UseVisualStyleBackColor = true;
            btn_mainMenu.Click += btn_mainMenu_Click;
            // 
            // btn_sellCartdrige
            // 
            btn_sellCartdrige.Location = new Point(282, 87);
            btn_sellCartdrige.Name = "btn_sellCartdrige";
            btn_sellCartdrige.Size = new Size(238, 33);
            btn_sellCartdrige.TabIndex = 1;
            btn_sellCartdrige.Text = "VENDER CARTUCHO";
            btn_sellCartdrige.UseVisualStyleBackColor = true;
            btn_sellCartdrige.Click += btn_sellCartdrige_Click;
            // 
            // btn_sellConsole
            // 
            btn_sellConsole.Location = new Point(282, 153);
            btn_sellConsole.Name = "btn_sellConsole";
            btn_sellConsole.Size = new Size(238, 33);
            btn_sellConsole.TabIndex = 2;
            btn_sellConsole.Text = "VENDER CONSOLA";
            btn_sellConsole.UseVisualStyleBackColor = true;
            btn_sellConsole.Click += btn_sellConsole_Click;
            // 
            // btn_sellSleeves
            // 
            btn_sellSleeves.Location = new Point(282, 219);
            btn_sellSleeves.Name = "btn_sellSleeves";
            btn_sellSleeves.Size = new Size(238, 33);
            btn_sellSleeves.TabIndex = 3;
            btn_sellSleeves.Text = "VENDER FUNDAS";
            btn_sellSleeves.UseVisualStyleBackColor = true;
            btn_sellSleeves.Click += btn_sellSleeves_Click;
            // 
            // btn_salesHistory
            // 
            btn_salesHistory.Location = new Point(282, 316);
            btn_salesHistory.Name = "btn_salesHistory";
            btn_salesHistory.Size = new Size(238, 33);
            btn_salesHistory.TabIndex = 4;
            btn_salesHistory.Text = "HISTORIAL DE VENTAS";
            btn_salesHistory.UseVisualStyleBackColor = true;
            btn_salesHistory.Click += btn_saleHistory_Click;
            // 
            // FormSellMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_salesHistory);
            Controls.Add(btn_sellSleeves);
            Controls.Add(btn_sellConsole);
            Controls.Add(btn_sellCartdrige);
            Controls.Add(btn_mainMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "FormSellMain";
            StartPosition = FormStartPosition.Manual;
            Text = "Vender";
            FormClosing += FormSellMain_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_mainMenu;
        private Button btn_sellCartdrige;
        private Button btn_sellConsole;
        private Button btn_sellSleeves;
        private Button btn_salesHistory;
    }
}