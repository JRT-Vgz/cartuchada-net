namespace Cartuchada.Forms.Purchase_Forms
{
    partial class FormPurchasesHistory
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
            panel_upperMenu = new Panel();
            rb_historySpot = new RadioButton();
            rb_historySpareParts = new RadioButton();
            rb_historyCartdriges = new RadioButton();
            rb_historyConsoles = new RadioButton();
            btn_back = new Button();
            dgv_purchasesHistory = new DataGridView();
            panel_upperMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_purchasesHistory).BeginInit();
            SuspendLayout();
            // 
            // panel_upperMenu
            // 
            panel_upperMenu.Controls.Add(rb_historySpot);
            panel_upperMenu.Controls.Add(rb_historySpareParts);
            panel_upperMenu.Controls.Add(rb_historyCartdriges);
            panel_upperMenu.Controls.Add(rb_historyConsoles);
            panel_upperMenu.Controls.Add(btn_back);
            panel_upperMenu.Dock = DockStyle.Top;
            panel_upperMenu.Location = new Point(0, 0);
            panel_upperMenu.Name = "panel_upperMenu";
            panel_upperMenu.Size = new Size(800, 58);
            panel_upperMenu.TabIndex = 3;
            // 
            // rb_historySpot
            // 
            rb_historySpot.AutoSize = true;
            rb_historySpot.Location = new Point(619, 20);
            rb_historySpot.Name = "rb_historySpot";
            rb_historySpot.Size = new Size(49, 19);
            rb_historySpot.TabIndex = 7;
            rb_historySpot.TabStop = true;
            rb_historySpot.Text = "Spot";
            rb_historySpot.UseVisualStyleBackColor = true;
            rb_historySpot.CheckedChanged += rb_CheckedChanged;
            // 
            // rb_historySpareParts
            // 
            rb_historySpareParts.AutoSize = true;
            rb_historySpareParts.Location = new Point(484, 20);
            rb_historySpareParts.Name = "rb_historySpareParts";
            rb_historySpareParts.Size = new Size(83, 19);
            rb_historySpareParts.TabIndex = 6;
            rb_historySpareParts.TabStop = true;
            rb_historySpareParts.Text = "Recambios";
            rb_historySpareParts.UseVisualStyleBackColor = true;
            rb_historySpareParts.CheckedChanged += rb_CheckedChanged;
            // 
            // rb_historyCartdriges
            // 
            rb_historyCartdriges.AutoSize = true;
            rb_historyCartdriges.Location = new Point(218, 20);
            rb_historyCartdriges.Name = "rb_historyCartdriges";
            rb_historyCartdriges.Size = new Size(79, 19);
            rb_historyCartdriges.TabIndex = 5;
            rb_historyCartdriges.TabStop = true;
            rb_historyCartdriges.Text = "Cartuchos";
            rb_historyCartdriges.UseVisualStyleBackColor = true;
            rb_historyCartdriges.CheckedChanged += rb_CheckedChanged;
            // 
            // rb_historyConsoles
            // 
            rb_historyConsoles.AutoSize = true;
            rb_historyConsoles.Location = new Point(353, 20);
            rb_historyConsoles.Name = "rb_historyConsoles";
            rb_historyConsoles.Size = new Size(73, 19);
            rb_historyConsoles.TabIndex = 4;
            rb_historyConsoles.TabStop = true;
            rb_historyConsoles.Text = "Consolas";
            rb_historyConsoles.UseVisualStyleBackColor = true;
            rb_historyConsoles.CheckedChanged += rb_CheckedChanged;
            // 
            // btn_back
            // 
            btn_back.Location = new Point(12, 12);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(99, 23);
            btn_back.TabIndex = 2;
            btn_back.Text = "Volver";
            btn_back.UseVisualStyleBackColor = true;
            btn_back.Click += btn_back_Click;
            // 
            // dgv_purchasesHistory
            // 
            dgv_purchasesHistory.AllowUserToAddRows = false;
            dgv_purchasesHistory.AllowUserToDeleteRows = false;
            dgv_purchasesHistory.AllowUserToResizeColumns = false;
            dgv_purchasesHistory.AllowUserToResizeRows = false;
            dgv_purchasesHistory.BorderStyle = BorderStyle.Fixed3D;
            dgv_purchasesHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_purchasesHistory.Dock = DockStyle.Fill;
            dgv_purchasesHistory.Location = new Point(0, 58);
            dgv_purchasesHistory.MultiSelect = false;
            dgv_purchasesHistory.Name = "dgv_purchasesHistory";
            dgv_purchasesHistory.ReadOnly = true;
            dgv_purchasesHistory.RowHeadersVisible = false;
            dgv_purchasesHistory.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_purchasesHistory.Size = new Size(800, 392);
            dgv_purchasesHistory.TabIndex = 4;
            dgv_purchasesHistory.CellContentClick += dgv_salesHistory_CellContentClick;
            // 
            // FormPurchasesHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv_purchasesHistory);
            Controls.Add(panel_upperMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(833, 489);
            MinimumSize = new Size(816, 489);
            Name = "FormPurchasesHistory";
            StartPosition = FormStartPosition.Manual;
            Text = "Historial de compras";
            FormClosing += FormPurchasesHistory_FormClosing;
            Load += FormPurchasesHistory_Load;
            panel_upperMenu.ResumeLayout(false);
            panel_upperMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_purchasesHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_upperMenu;
        private RadioButton rb_historySpareParts;
        private RadioButton rb_historyCartdriges;
        private RadioButton rb_historyConsoles;
        private Button btn_back;
        private DataGridView dgv_purchasesHistory;
        private RadioButton rb_historySpot;
    }
}