namespace Cartuchada.Forms.Miscelanea_Forms
{
    partial class FormConfirmRevertInput
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
            lbl_confirmRevert = new Label();
            txt_confirmRevert = new TextBox();
            btn_ok = new Button();
            btn_cancel = new Button();
            SuspendLayout();
            // 
            // lbl_confirmRevert
            // 
            lbl_confirmRevert.AutoSize = true;
            lbl_confirmRevert.Location = new Point(53, 19);
            lbl_confirmRevert.Name = "lbl_confirmRevert";
            lbl_confirmRevert.Size = new Size(174, 15);
            lbl_confirmRevert.TabIndex = 0;
            lbl_confirmRevert.Text = "Escribe 'revertir' para confirmar:";
            // 
            // txt_confirmRevert
            // 
            txt_confirmRevert.Location = new Point(92, 48);
            txt_confirmRevert.Name = "txt_confirmRevert";
            txt_confirmRevert.Size = new Size(100, 23);
            txt_confirmRevert.TabIndex = 1;
            txt_confirmRevert.KeyDown += txt_confirmRevert_KeyDown;
            txt_confirmRevert.KeyPress += txt_confirmRevert_KeyPress;
            // 
            // btn_ok
            // 
            btn_ok.Location = new Point(48, 87);
            btn_ok.Name = "btn_ok";
            btn_ok.Size = new Size(75, 23);
            btn_ok.TabIndex = 2;
            btn_ok.Text = "OK";
            btn_ok.UseVisualStyleBackColor = true;
            btn_ok.Click += btn_ok_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(163, 87);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(75, 23);
            btn_cancel.TabIndex = 3;
            btn_cancel.Text = "Cancelar";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // FormConfirmRevertInput
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(287, 132);
            ControlBox = false;
            Controls.Add(btn_cancel);
            Controls.Add(btn_ok);
            Controls.Add(txt_confirmRevert);
            Controls.Add(lbl_confirmRevert);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(303, 171);
            MinimizeBox = false;
            MinimumSize = new Size(303, 171);
            Name = "FormConfirmRevertInput";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirmar Revertir";
            Load += FormConfirmRevertInput_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_confirmRevert;
        private TextBox txt_confirmRevert;
        private Button btn_ok;
        private Button btn_cancel;
    }
}