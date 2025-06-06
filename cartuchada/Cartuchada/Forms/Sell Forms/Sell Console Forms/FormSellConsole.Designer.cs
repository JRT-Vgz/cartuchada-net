namespace Cartuchada.Forms.Sell_Forms.Sell_Console_Forms
{
    partial class FormSellConsole
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
            txt_sumSparePartsPrice = new TextBox();
            txt_searchReference = new TextBox();
            lbl_reference = new Label();
            btn_back = new Button();
            dgv_consoleCatalogue = new DataGridView();
            panel_upperMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_consoleCatalogue).BeginInit();
            SuspendLayout();
            // 
            // panel_upperMenu
            // 
            panel_upperMenu.Controls.Add(txt_sumSparePartsPrice);
            panel_upperMenu.Controls.Add(txt_searchReference);
            panel_upperMenu.Controls.Add(lbl_reference);
            panel_upperMenu.Controls.Add(btn_back);
            panel_upperMenu.Dock = DockStyle.Top;
            panel_upperMenu.Location = new Point(0, 0);
            panel_upperMenu.Name = "panel_upperMenu";
            panel_upperMenu.Size = new Size(800, 58);
            panel_upperMenu.TabIndex = 2;
            // 
            // txt_sumSparePartsPrice
            // 
            txt_sumSparePartsPrice.Location = new Point(574, 30);
            txt_sumSparePartsPrice.Name = "txt_sumSparePartsPrice";
            txt_sumSparePartsPrice.Size = new Size(60, 23);
            txt_sumSparePartsPrice.TabIndex = 7;
            txt_sumSparePartsPrice.TextAlign = HorizontalAlignment.Center;
            txt_sumSparePartsPrice.Enter += txt_sumSparePartsPrice_Enter;
            txt_sumSparePartsPrice.KeyPress += txt_sumSparePartsPrice_KeyPress;
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
            // dgv_consoleCatalogue
            // 
            dgv_consoleCatalogue.AllowUserToAddRows = false;
            dgv_consoleCatalogue.AllowUserToDeleteRows = false;
            dgv_consoleCatalogue.AllowUserToResizeColumns = false;
            dgv_consoleCatalogue.AllowUserToResizeRows = false;
            dgv_consoleCatalogue.BorderStyle = BorderStyle.Fixed3D;
            dgv_consoleCatalogue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_consoleCatalogue.Dock = DockStyle.Fill;
            dgv_consoleCatalogue.Location = new Point(0, 58);
            dgv_consoleCatalogue.MultiSelect = false;
            dgv_consoleCatalogue.Name = "dgv_consoleCatalogue";
            dgv_consoleCatalogue.ReadOnly = true;
            dgv_consoleCatalogue.RowHeadersVisible = false;
            dgv_consoleCatalogue.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_consoleCatalogue.Size = new Size(800, 392);
            dgv_consoleCatalogue.TabIndex = 3;
            dgv_consoleCatalogue.CellContentClick += dgv_consoleCatalogue_CellContentClick;
            // 
            // FormSellConsole
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv_consoleCatalogue);
            Controls.Add(panel_upperMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(833, 489);
            MinimumSize = new Size(816, 489);
            Name = "FormSellConsole";
            StartPosition = FormStartPosition.Manual;
            Text = "Vender consola";
            FormClosing += FormSellConsole_FormClosing;
            Load += FormSellConsole_Load;
            panel_upperMenu.ResumeLayout(false);
            panel_upperMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_consoleCatalogue).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_upperMenu;
        private TextBox txt_searchReference;
        private Label lbl_reference;
        private TextBox txt_searchName;
        private Label lbl_search;
        private Button btn_back;
        private DataGridView dgv_consoleCatalogue;
        private TextBox txt_sumSparePartsPrice;
    }
}