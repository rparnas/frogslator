namespace Frogslator
{
    partial class EditJumboForm
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
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_OriginalValue = new System.Windows.Forms.Label();
            this.lbl_NewValue = new System.Windows.Forms.Label();
            this.cb_NewValues = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(12, 221);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(109, 23);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(127, 221);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(109, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_OriginalValue
            // 
            this.lbl_OriginalValue.AutoSize = true;
            this.lbl_OriginalValue.Location = new System.Drawing.Point(12, 9);
            this.lbl_OriginalValue.Name = "lbl_OriginalValue";
            this.lbl_OriginalValue.Size = new System.Drawing.Size(78, 13);
            this.lbl_OriginalValue.TabIndex = 2;
            this.lbl_OriginalValue.Text = "Original Value: ";
            // 
            // lbl_NewValue
            // 
            this.lbl_NewValue.AutoSize = true;
            this.lbl_NewValue.Location = new System.Drawing.Point(12, 86);
            this.lbl_NewValue.Name = "lbl_NewValue";
            this.lbl_NewValue.Size = new System.Drawing.Size(65, 13);
            this.lbl_NewValue.TabIndex = 3;
            this.lbl_NewValue.Text = "New Value: ";
            // 
            // cb_NewValues
            // 
            this.cb_NewValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_NewValues.FormattingEnabled = true;
            this.cb_NewValues.Location = new System.Drawing.Point(15, 103);
            this.cb_NewValues.Name = "cb_NewValues";
            this.cb_NewValues.Size = new System.Drawing.Size(216, 21);
            this.cb_NewValues.TabIndex = 4;
            // 
            // EditJumboForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 262);
            this.Controls.Add(this.cb_NewValues);
            this.Controls.Add(this.lbl_NewValue);
            this.Controls.Add(this.lbl_OriginalValue);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditJumboForm";
            this.Text = "Edit Jumbo Char...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_OriginalValue;
        private System.Windows.Forms.Label lbl_NewValue;
        private System.Windows.Forms.ComboBox cb_NewValues;
    }
}