namespace Cartuchada.Forms.Purchase_Forms.Purchase_Cartdrige_Forms
{
    partial class FormGameCatalogue
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
            btn_back = new Button();
            panel_upperMenu = new Panel();
            lbl_search = new Label();
            txt_search = new TextBox();
            dgv_gameCatalogue = new DataGridView();
            panel_upperMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_gameCatalogue).BeginInit();
            SuspendLayout();
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
            // panel_upperMenu
            // 
            panel_upperMenu.Controls.Add(lbl_search);
            panel_upperMenu.Controls.Add(txt_search);
            panel_upperMenu.Controls.Add(btn_back);
            panel_upperMenu.Dock = DockStyle.Top;
            panel_upperMenu.Location = new Point(0, 0);
            panel_upperMenu.Name = "panel_upperMenu";
            panel_upperMenu.Size = new Size(800, 58);
            panel_upperMenu.TabIndex = 0;
            // 
            // lbl_search
            // 
            lbl_search.AutoSize = true;
            lbl_search.Location = new Point(204, 30);
            lbl_search.Name = "lbl_search";
            lbl_search.Size = new Size(42, 15);
            lbl_search.TabIndex = 103;
            lbl_search.Text = "Buscar";
            // 
            // txt_search
            // 
            txt_search.Location = new Point(252, 27);
            txt_search.Name = "txt_search";
            txt_search.Size = new Size(470, 23);
            txt_search.TabIndex = 1;
            txt_search.KeyPress += txt_search_KeyPress;
            // 
            // dgv_gameCatalogue
            // 
            dgv_gameCatalogue.AllowUserToAddRows = false;
            dgv_gameCatalogue.AllowUserToDeleteRows = false;
            dgv_gameCatalogue.AllowUserToResizeColumns = false;
            dgv_gameCatalogue.AllowUserToResizeRows = false;
            dgv_gameCatalogue.BorderStyle = BorderStyle.Fixed3D;
            dgv_gameCatalogue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_gameCatalogue.Dock = DockStyle.Fill;
            dgv_gameCatalogue.Location = new Point(0, 58);
            dgv_gameCatalogue.MultiSelect = false;
            dgv_gameCatalogue.Name = "dgv_gameCatalogue";
            dgv_gameCatalogue.ReadOnly = true;
            dgv_gameCatalogue.RowHeadersVisible = false;
            dgv_gameCatalogue.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_gameCatalogue.Size = new Size(800, 392);
            dgv_gameCatalogue.TabIndex = 1;
            dgv_gameCatalogue.CellContentClick += dgv_gameCatalogue_CellContentClick;
            // 
            // FormGameCatalogue
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv_gameCatalogue);
            Controls.Add(panel_upperMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(833, 489);
            MinimumSize = new Size(816, 489);
            Name = "FormGameCatalogue";
            StartPosition = FormStartPosition.Manual;
            Text = "Catálogo de juegos";
            FormClosing += FormPurchaseCartdrige_FormClosing;
            Load += FormPurchaseCartdrige_Load;
            panel_upperMenu.ResumeLayout(false);
            panel_upperMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_gameCatalogue).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_back;
        private Panel panel_upperMenu;
        private DataGridView dgv_gameCatalogue;
        private TextBox txt_search;
        private Label lbl_search;
    }
}