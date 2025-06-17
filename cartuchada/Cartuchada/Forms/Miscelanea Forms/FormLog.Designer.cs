namespace Cartuchada.Forms.Miscelanea_Forms
{
    partial class FormLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLog));
            panel_upperMenu = new Panel();
            btn_mainMenu = new Button();
            dgv_log = new DataGridView();
            panel_upperMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_log).BeginInit();
            SuspendLayout();
            // 
            // panel_upperMenu
            // 
            panel_upperMenu.Controls.Add(btn_mainMenu);
            panel_upperMenu.Dock = DockStyle.Top;
            panel_upperMenu.Location = new Point(0, 0);
            panel_upperMenu.Name = "panel_upperMenu";
            panel_upperMenu.Size = new Size(800, 58);
            panel_upperMenu.TabIndex = 2;
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
            // dgv_log
            // 
            dgv_log.AllowUserToAddRows = false;
            dgv_log.AllowUserToDeleteRows = false;
            dgv_log.AllowUserToResizeColumns = false;
            dgv_log.AllowUserToResizeRows = false;
            dgv_log.BorderStyle = BorderStyle.Fixed3D;
            dgv_log.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_log.Dock = DockStyle.Fill;
            dgv_log.Location = new Point(0, 58);
            dgv_log.MultiSelect = false;
            dgv_log.Name = "dgv_log";
            dgv_log.ReadOnly = true;
            dgv_log.RowHeadersVisible = false;
            dgv_log.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_log.Size = new Size(800, 392);
            dgv_log.TabIndex = 3;
            dgv_log.CellFormatting += dgv_log_CellFormatting;
            // 
            // FormLog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv_log);
            Controls.Add(panel_upperMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(833, 489);
            MinimumSize = new Size(816, 489);
            Name = "FormLog";
            StartPosition = FormStartPosition.Manual;
            Text = "Log";
            FormClosing += FormLog_FormClosing;
            Load += FormLog_Load;
            panel_upperMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_log).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_upperMenu;
        private Button btn_mainMenu;
        private DataGridView dgv_log;
    }
}