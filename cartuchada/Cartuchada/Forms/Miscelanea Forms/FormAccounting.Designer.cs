namespace Cartuchada.Forms.Miscelanea_Forms
{
    partial class FormAccounting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccounting));
            panel_upperMenu = new Panel();
            lbl_historicalAccounting = new Label();
            cbo_yearFilter = new ComboBox();
            btn_mainMenu = new Button();
            dgv_accounting = new DataGridView();
            dgv_historicalAccounting = new DataGridView();
            panel_upperMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_accounting).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_historicalAccounting).BeginInit();
            SuspendLayout();
            // 
            // panel_upperMenu
            // 
            panel_upperMenu.Controls.Add(lbl_historicalAccounting);
            panel_upperMenu.Controls.Add(cbo_yearFilter);
            panel_upperMenu.Controls.Add(btn_mainMenu);
            panel_upperMenu.Dock = DockStyle.Top;
            panel_upperMenu.Location = new Point(0, 0);
            panel_upperMenu.Name = "panel_upperMenu";
            panel_upperMenu.Size = new Size(800, 58);
            panel_upperMenu.TabIndex = 2;
            // 
            // lbl_historicalAccounting
            // 
            lbl_historicalAccounting.AutoSize = true;
            lbl_historicalAccounting.Location = new Point(569, 28);
            lbl_historicalAccounting.Name = "lbl_historicalAccounting";
            lbl_historicalAccounting.Size = new Size(69, 15);
            lbl_historicalAccounting.TabIndex = 103;
            lbl_historicalAccounting.Text = "HISTÓRICO:";
            // 
            // cbo_yearFilter
            // 
            cbo_yearFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_yearFilter.FormattingEnabled = true;
            cbo_yearFilter.Location = new Point(170, 20);
            cbo_yearFilter.Name = "cbo_yearFilter";
            cbo_yearFilter.Size = new Size(121, 23);
            cbo_yearFilter.TabIndex = 102;
            cbo_yearFilter.SelectedIndexChanged += cbo_yearFilter_SelectedIndexChanged;
            // 
            // btn_mainMenu
            // 
            btn_mainMenu.Location = new Point(12, 12);
            btn_mainMenu.Name = "btn_mainMenu";
            btn_mainMenu.Size = new Size(99, 23);
            btn_mainMenu.TabIndex = 101;
            btn_mainMenu.Text = "Menú principal";
            btn_mainMenu.UseVisualStyleBackColor = true;
            btn_mainMenu.Click += btn_mainMenu_Click;
            // 
            // dgv_accounting
            // 
            dgv_accounting.AllowUserToAddRows = false;
            dgv_accounting.AllowUserToDeleteRows = false;
            dgv_accounting.AllowUserToResizeColumns = false;
            dgv_accounting.AllowUserToResizeRows = false;
            dgv_accounting.BorderStyle = BorderStyle.Fixed3D;
            dgv_accounting.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_accounting.Location = new Point(35, 58);
            dgv_accounting.MultiSelect = false;
            dgv_accounting.Name = "dgv_accounting";
            dgv_accounting.ReadOnly = true;
            dgv_accounting.RowHeadersVisible = false;
            dgv_accounting.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_accounting.Size = new Size(406, 350);
            dgv_accounting.TabIndex = 3;
            dgv_accounting.CellFormatting += dgv_accounting_CellFormatting;
            // 
            // dgv_historicalAccounting
            // 
            dgv_historicalAccounting.AllowUserToAddRows = false;
            dgv_historicalAccounting.AllowUserToDeleteRows = false;
            dgv_historicalAccounting.AllowUserToResizeColumns = false;
            dgv_historicalAccounting.AllowUserToResizeRows = false;
            dgv_historicalAccounting.BorderStyle = BorderStyle.Fixed3D;
            dgv_historicalAccounting.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_historicalAccounting.Location = new Point(460, 58);
            dgv_historicalAccounting.MultiSelect = false;
            dgv_historicalAccounting.Name = "dgv_historicalAccounting";
            dgv_historicalAccounting.ReadOnly = true;
            dgv_historicalAccounting.RowHeadersVisible = false;
            dgv_historicalAccounting.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_historicalAccounting.Size = new Size(306, 50);
            dgv_historicalAccounting.TabIndex = 4;
            // 
            // FormAccounting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv_historicalAccounting);
            Controls.Add(dgv_accounting);
            Controls.Add(panel_upperMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(833, 489);
            MinimumSize = new Size(816, 489);
            Name = "FormAccounting";
            StartPosition = FormStartPosition.Manual;
            Text = "Contabilidad";
            FormClosing += FormAccounting_FormClosing;
            Load += FormAccounting_Load;
            panel_upperMenu.ResumeLayout(false);
            panel_upperMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_accounting).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_historicalAccounting).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_upperMenu;
        private Button btn_mainMenu;
        private DataGridView dgv_accounting;
        private ComboBox cbo_yearFilter;
        private DataGridView dgv_historicalAccounting;
        private Label lbl_historicalAccounting;
    }
}