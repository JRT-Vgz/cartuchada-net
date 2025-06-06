namespace Cartuchada.Forms.Sell_Forms.Sell_Cartdrige_Forms
{
    partial class FormSellCartdrige
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
            txt_searchReference = new TextBox();
            lbl_reference = new Label();
            txt_searchName = new TextBox();
            lbl_search = new Label();
            btn_back = new Button();
            dgv_cartdrigeCatalogue = new DataGridView();
            panel_upperMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_cartdrigeCatalogue).BeginInit();
            SuspendLayout();
            // 
            // panel_upperMenu
            // 
            panel_upperMenu.Controls.Add(txt_searchReference);
            panel_upperMenu.Controls.Add(lbl_reference);
            panel_upperMenu.Controls.Add(txt_searchName);
            panel_upperMenu.Controls.Add(lbl_search);
            panel_upperMenu.Controls.Add(btn_back);
            panel_upperMenu.Dock = DockStyle.Top;
            panel_upperMenu.Location = new Point(0, 0);
            panel_upperMenu.Name = "panel_upperMenu";
            panel_upperMenu.Size = new Size(800, 58);
            panel_upperMenu.TabIndex = 1;
            // 
            // txt_searchReference
            // 
            txt_searchReference.Location = new Point(174, 27);
            txt_searchReference.Name = "txt_searchReference";
            txt_searchReference.Size = new Size(100, 23);
            txt_searchReference.TabIndex = 6;
            txt_searchReference.KeyPress += txt_searchReference_KeyPress;
            // 
            // lbl_reference
            // 
            lbl_reference.AutoSize = true;
            lbl_reference.Location = new Point(141, 30);
            lbl_reference.Name = "lbl_reference";
            lbl_reference.Size = new Size(27, 15);
            lbl_reference.TabIndex = 5;
            lbl_reference.Text = "Ref.";
            // 
            // txt_searchName
            // 
            txt_searchName.Location = new Point(362, 27);
            txt_searchName.Name = "txt_searchName";
            txt_searchName.Size = new Size(386, 23);
            txt_searchName.TabIndex = 4;
            txt_searchName.KeyPress += txt_searchName_KeyPress;
            // 
            // lbl_search
            // 
            lbl_search.AutoSize = true;
            lbl_search.Location = new Point(314, 30);
            lbl_search.Name = "lbl_search";
            lbl_search.Size = new Size(42, 15);
            lbl_search.TabIndex = 3;
            lbl_search.Text = "Buscar";
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
            dgv_cartdrigeCatalogue.TabIndex = 2;
            dgv_cartdrigeCatalogue.CellContentClick += dgv_cartdrigeCatalogue_CellContentClick;
            // 
            // FormSellCartdrige
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
            Name = "FormSellCartdrige";
            StartPosition = FormStartPosition.Manual;
            Text = "Vender Cartucho";
            FormClosing += FormSellCartdrige_FormClosing;
            Load += FormSellCartdrige_Load;
            panel_upperMenu.ResumeLayout(false);
            panel_upperMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_cartdrigeCatalogue).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel_upperMenu;
        private Button btn_back;
        private DataGridView dgv_cartdrigeCatalogue;
        private Label lbl_search;
        private TextBox txt_searchName;
        private TextBox txt_searchReference;
        private Label lbl_reference;
    }
}