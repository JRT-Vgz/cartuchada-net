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
            panel_upperMenu = new Panel();
            cbo_yearFilter = new ComboBox();
            btn_mainMenu = new Button();
            dgv_statistics = new DataGridView();
            panel_upperMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_statistics).BeginInit();
            SuspendLayout();
            // 
            // panel_upperMenu
            // 
            panel_upperMenu.Controls.Add(cbo_yearFilter);
            panel_upperMenu.Controls.Add(btn_mainMenu);
            panel_upperMenu.Dock = DockStyle.Top;
            panel_upperMenu.Location = new Point(0, 0);
            panel_upperMenu.Name = "panel_upperMenu";
            panel_upperMenu.Size = new Size(800, 58);
            panel_upperMenu.TabIndex = 2;
            // 
            // cbo_yearFilter
            // 
            cbo_yearFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_yearFilter.FormattingEnabled = true;
            cbo_yearFilter.Location = new Point(170, 20);
            cbo_yearFilter.Name = "cbo_yearFilter";
            cbo_yearFilter.Size = new Size(121, 23);
            cbo_yearFilter.TabIndex = 102;
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
            // dgv_statistics
            // 
            dgv_statistics.AllowUserToAddRows = false;
            dgv_statistics.AllowUserToDeleteRows = false;
            dgv_statistics.AllowUserToResizeColumns = false;
            dgv_statistics.AllowUserToResizeRows = false;
            dgv_statistics.BorderStyle = BorderStyle.Fixed3D;
            dgv_statistics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_statistics.Dock = DockStyle.Fill;
            dgv_statistics.Location = new Point(0, 58);
            dgv_statistics.MultiSelect = false;
            dgv_statistics.Name = "dgv_statistics";
            dgv_statistics.ReadOnly = true;
            dgv_statistics.RowHeadersVisible = false;
            dgv_statistics.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_statistics.Size = new Size(800, 392);
            dgv_statistics.TabIndex = 3;
            // 
            // FormAccounting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv_statistics);
            Controls.Add(panel_upperMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(833, 489);
            MinimumSize = new Size(816, 489);
            Name = "FormAccounting";
            StartPosition = FormStartPosition.Manual;
            Text = "Contabilidad";
            FormClosing += FormAccounting_FormClosing;
            Load += FormAccounting_Load;
            panel_upperMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_statistics).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_upperMenu;
        private Button btn_mainMenu;
        private DataGridView dgv_statistics;
        private ComboBox cbo_yearFilter;
    }
}