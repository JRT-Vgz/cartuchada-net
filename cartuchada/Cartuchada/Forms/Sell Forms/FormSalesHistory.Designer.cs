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
            panel_upperMenu = new Panel();
            btn_back = new Button();
            dgv_cartdrigeCatalogue = new DataGridView();
            panel_upperMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_cartdrigeCatalogue).BeginInit();
            SuspendLayout();
            // 
            // panel_upperMenu
            // 
            panel_upperMenu.Controls.Add(btn_back);
            panel_upperMenu.Dock = DockStyle.Top;
            panel_upperMenu.Location = new Point(0, 0);
            panel_upperMenu.Name = "panel_upperMenu";
            panel_upperMenu.Size = new Size(800, 58);
            panel_upperMenu.TabIndex = 2;
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
            // dgv_cartdrigeCatalogue
            // 
            dgv_cartdrigeCatalogue.AllowUserToAddRows = false;
            dgv_cartdrigeCatalogue.AllowUserToDeleteRows = false;
            dgv_cartdrigeCatalogue.AllowUserToResizeColumns = false;
            dgv_cartdrigeCatalogue.AllowUserToResizeRows = false;
            dgv_cartdrigeCatalogue.BorderStyle = BorderStyle.Fixed3D;
            dgv_cartdrigeCatalogue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_cartdrigeCatalogue.Dock = DockStyle.Fill;
            dgv_cartdrigeCatalogue.Location = new Point(0, 58);
            dgv_cartdrigeCatalogue.MultiSelect = false;
            dgv_cartdrigeCatalogue.Name = "dgv_cartdrigeCatalogue";
            dgv_cartdrigeCatalogue.ReadOnly = true;
            dgv_cartdrigeCatalogue.RowHeadersVisible = false;
            dgv_cartdrigeCatalogue.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_cartdrigeCatalogue.Size = new Size(800, 392);
            dgv_cartdrigeCatalogue.TabIndex = 3;
            // 
            // FormSalesHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv_cartdrigeCatalogue);
            Controls.Add(panel_upperMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(833, 489);
            MinimumSize = new Size(816, 489);
            Name = "FormSalesHistory";
            StartPosition = FormStartPosition.Manual;
            Text = "Historial de ventas";
            FormClosing += FormSalesHistory_FormClosing;
            Load += FormSalesHistory_Load;
            panel_upperMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_cartdrigeCatalogue).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_upperMenu;
        private Button btn_back;
        private DataGridView dgv_cartdrigeCatalogue;
    }
}