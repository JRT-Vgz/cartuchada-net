namespace Cartuchada.Forms.Sell_Forms
{
    partial class FormSalesHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSalesHistory));
            panel_upperMenu = new Panel();
            rb_historySleeves = new RadioButton();
            rb_historyCartdriges = new RadioButton();
            rb_historyConsoles = new RadioButton();
            btn_back = new Button();
            dgv_salesHistory = new DataGridView();
            panel_upperMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_salesHistory).BeginInit();
            SuspendLayout();
            // 
            // panel_upperMenu
            // 
            panel_upperMenu.Controls.Add(rb_historySleeves);
            panel_upperMenu.Controls.Add(rb_historyCartdriges);
            panel_upperMenu.Controls.Add(rb_historyConsoles);
            panel_upperMenu.Controls.Add(btn_back);
            panel_upperMenu.Dock = DockStyle.Top;
            panel_upperMenu.Location = new Point(0, 0);
            panel_upperMenu.Name = "panel_upperMenu";
            panel_upperMenu.Size = new Size(800, 58);
            panel_upperMenu.TabIndex = 2;
            // 
            // rb_historySleeves
            // 
            rb_historySleeves.AutoSize = true;
            rb_historySleeves.Location = new Point(484, 20);
            rb_historySleeves.Name = "rb_historySleeves";
            rb_historySleeves.Size = new Size(63, 19);
            rb_historySleeves.TabIndex = 6;
            rb_historySleeves.TabStop = true;
            rb_historySleeves.Text = "Fundas";
            rb_historySleeves.UseVisualStyleBackColor = true;
            rb_historySleeves.CheckedChanged += rb_CheckedChanged;
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
            // dgv_salesHistory
            // 
            dgv_salesHistory.AllowUserToAddRows = false;
            dgv_salesHistory.AllowUserToDeleteRows = false;
            dgv_salesHistory.AllowUserToResizeColumns = false;
            dgv_salesHistory.AllowUserToResizeRows = false;
            dgv_salesHistory.BorderStyle = BorderStyle.Fixed3D;
            dgv_salesHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_salesHistory.Dock = DockStyle.Fill;
            dgv_salesHistory.Location = new Point(0, 58);
            dgv_salesHistory.MultiSelect = false;
            dgv_salesHistory.Name = "dgv_salesHistory";
            dgv_salesHistory.ReadOnly = true;
            dgv_salesHistory.RowHeadersVisible = false;
            dgv_salesHistory.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_salesHistory.Size = new Size(800, 392);
            dgv_salesHistory.TabIndex = 3;
            dgv_salesHistory.CellContentClick += dgv_salesHistory_CellContentClick;
            // 
            // FormSalesHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv_salesHistory);
            Controls.Add(panel_upperMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(833, 489);
            MinimumSize = new Size(816, 489);
            Name = "FormSalesHistory";
            StartPosition = FormStartPosition.Manual;
            Text = "Historial de ventas";
            FormClosing += FormSalesHistory_FormClosing;
            Load += FormSalesHistory_Load;
            panel_upperMenu.ResumeLayout(false);
            panel_upperMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_salesHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_upperMenu;
        private Button btn_back;
        private DataGridView dgv_salesHistory;
        private RadioButton rb_historySleeves;
        private RadioButton rb_historyCartdriges;
        private RadioButton rb_historyConsoles;
    }
}