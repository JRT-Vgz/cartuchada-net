namespace Cartuchada.Forms.Purchase_Forms.Purchase_Cartdrige_Forms
{
    partial class FormRecommendedCartdrigePrice
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
            label2 = new Label();
            label1 = new Label();
            btn_search = new Button();
            rb_filter = new RadioButton();
            rb_all = new RadioButton();
            btn_back = new Button();
            dgv_cartdrigeSales = new DataGridView();
            dgv_cartdrigeSpots = new DataGridView();
            panel_upperMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_cartdrigeSales).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_cartdrigeSpots).BeginInit();
            SuspendLayout();
            // 
            // panel_upperMenu
            // 
            panel_upperMenu.Controls.Add(label2);
            panel_upperMenu.Controls.Add(label1);
            panel_upperMenu.Controls.Add(btn_search);
            panel_upperMenu.Controls.Add(rb_filter);
            panel_upperMenu.Controls.Add(rb_all);
            panel_upperMenu.Controls.Add(btn_back);
            panel_upperMenu.Dock = DockStyle.Top;
            panel_upperMenu.Location = new Point(0, 0);
            panel_upperMenu.Name = "panel_upperMenu";
            panel_upperMenu.Size = new Size(800, 58);
            panel_upperMenu.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(584, 35);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 106;
            label2.Text = "Condición";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(584, 11);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 105;
            label1.Text = "Región";
            // 
            // btn_search
            // 
            btn_search.Location = new Point(362, 17);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(75, 23);
            btn_search.TabIndex = 104;
            btn_search.Text = "Buscar";
            btn_search.UseVisualStyleBackColor = true;
            btn_search.Click += btn_search_Click;
            // 
            // rb_filter
            // 
            rb_filter.AutoSize = true;
            rb_filter.Location = new Point(502, 19);
            rb_filter.Name = "rb_filter";
            rb_filter.Size = new Size(55, 19);
            rb_filter.TabIndex = 103;
            rb_filter.TabStop = true;
            rb_filter.Text = "Filtrar";
            rb_filter.UseVisualStyleBackColor = true;
            // 
            // rb_all
            // 
            rb_all.AutoSize = true;
            rb_all.Location = new Point(253, 19);
            rb_all.Name = "rb_all";
            rb_all.Size = new Size(56, 19);
            rb_all.TabIndex = 102;
            rb_all.TabStop = true;
            rb_all.Text = "Todos";
            rb_all.UseVisualStyleBackColor = true;
            // 
            // btn_back
            // 
            btn_back.Location = new Point(12, 12);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(99, 23);
            btn_back.TabIndex = 101;
            btn_back.Text = "Volver";
            btn_back.UseVisualStyleBackColor = true;
            btn_back.Click += btn_back_Click;
            // 
            // dgv_cartdrigeSales
            // 
            dgv_cartdrigeSales.AllowUserToAddRows = false;
            dgv_cartdrigeSales.AllowUserToDeleteRows = false;
            dgv_cartdrigeSales.AllowUserToResizeColumns = false;
            dgv_cartdrigeSales.AllowUserToResizeRows = false;
            dgv_cartdrigeSales.BorderStyle = BorderStyle.Fixed3D;
            dgv_cartdrigeSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_cartdrigeSales.Dock = DockStyle.Left;
            dgv_cartdrigeSales.Location = new Point(0, 58);
            dgv_cartdrigeSales.MultiSelect = false;
            dgv_cartdrigeSales.Name = "dgv_cartdrigeSales";
            dgv_cartdrigeSales.ReadOnly = true;
            dgv_cartdrigeSales.RowHeadersVisible = false;
            dgv_cartdrigeSales.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_cartdrigeSales.Size = new Size(384, 392);
            dgv_cartdrigeSales.TabIndex = 4;
            // 
            // dgv_cartdrigeSpots
            // 
            dgv_cartdrigeSpots.AllowUserToAddRows = false;
            dgv_cartdrigeSpots.AllowUserToDeleteRows = false;
            dgv_cartdrigeSpots.AllowUserToResizeColumns = false;
            dgv_cartdrigeSpots.AllowUserToResizeRows = false;
            dgv_cartdrigeSpots.BorderStyle = BorderStyle.Fixed3D;
            dgv_cartdrigeSpots.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_cartdrigeSpots.Dock = DockStyle.Right;
            dgv_cartdrigeSpots.Location = new Point(416, 58);
            dgv_cartdrigeSpots.MultiSelect = false;
            dgv_cartdrigeSpots.Name = "dgv_cartdrigeSpots";
            dgv_cartdrigeSpots.ReadOnly = true;
            dgv_cartdrigeSpots.RowHeadersVisible = false;
            dgv_cartdrigeSpots.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_cartdrigeSpots.Size = new Size(384, 392);
            dgv_cartdrigeSpots.TabIndex = 5;
            // 
            // FormRecommendedCartdrigePrice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv_cartdrigeSpots);
            Controls.Add(dgv_cartdrigeSales);
            Controls.Add(panel_upperMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(833, 489);
            MinimumSize = new Size(816, 489);
            Name = "FormRecommendedCartdrigePrice";
            StartPosition = FormStartPosition.Manual;
            Text = "Orientaprecios";
            FormClosing += FormRecommendedCartdrigePrice_FormClosing;
            Load += FormRecommendedCartdrigePrice_Load;
            panel_upperMenu.ResumeLayout(false);
            panel_upperMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_cartdrigeSales).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_cartdrigeSpots).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_upperMenu;
        private Button btn_back;
        private DataGridView dgv_cartdrigeSales;
        private DataGridView dgv_cartdrigeSpots;
        private Label label2;
        private Label label1;
        private Button btn_search;
        private RadioButton rb_filter;
        private RadioButton rb_all;
    }
}