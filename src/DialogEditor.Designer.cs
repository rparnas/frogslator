namespace Frog
{
  partial class DialogEditor
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
      this.label7 = new System.Windows.Forms.Label();
      this.lbl_UsefulGlyphs = new System.Windows.Forms.Label();
      this.tb_UsefulGlyphs = new System.Windows.Forms.TextBox();
      this.lbl_Block3Bytes = new System.Windows.Forms.Label();
      this.lbl_Block2Bytes = new System.Windows.Forms.Label();
      this.lbl_Block1Bytes = new System.Windows.Forms.Label();
      this.lbl_Block0Bytes = new System.Windows.Forms.Label();
      this.lbl_SearchInText = new System.Windows.Forms.Label();
      this.tb_SearchInText = new System.Windows.Forms.TextBox();
      this.lb_Lines = new System.Windows.Forms.ListBox();
      this.lbl_Lines = new System.Windows.Forms.Label();
      this.gb_Line = new System.Windows.Forms.GroupBox();
      this.tb_Notes = new System.Windows.Forms.TextBox();
      this.lbl_Text = new System.Windows.Forms.Label();
      this.lbl_Notes = new System.Windows.Forms.Label();
      this.tb_Text = new System.Windows.Forms.TextBox();
      this.tb_Translation = new System.Windows.Forms.TextBox();
      this.lbl_Translation = new System.Windows.Forms.Label();
      this.cb_Skip = new System.Windows.Forms.CheckBox();
      this.btn_PreviewUp = new System.Windows.Forms.Button();
      this.btn_PreviewDown = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.tb_SearchInTranslation = new System.Windows.Forms.TextBox();
      this.gb_Footer = new System.Windows.Forms.GroupBox();
      this.previewControl = new Frog.GraphicsControl();
      this.cb_SixLetterNames = new System.Windows.Forms.CheckBox();
      this.gb_Line.SuspendLayout();
      this.gb_Footer.SuspendLayout();
      this.SuspendLayout();
      // 
      // label7
      // 
      this.label7.Location = new System.Drawing.Point(0, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(100, 23);
      this.label7.TabIndex = 0;
      // 
      // lbl_UsefulGlyphs
      // 
      this.lbl_UsefulGlyphs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lbl_UsefulGlyphs.AutoSize = true;
      this.lbl_UsefulGlyphs.Location = new System.Drawing.Point(5, 14);
      this.lbl_UsefulGlyphs.Name = "lbl_UsefulGlyphs";
      this.lbl_UsefulGlyphs.Size = new System.Drawing.Size(227, 13);
      this.lbl_UsefulGlyphs.TabIndex = 7;
      this.lbl_UsefulGlyphs.Text = "Useful Glyphs (copy-paste to Translation Text):";
      // 
      // tb_UsefulGlyphs
      // 
      this.tb_UsefulGlyphs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.tb_UsefulGlyphs.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tb_UsefulGlyphs.Location = new System.Drawing.Point(8, 30);
      this.tb_UsefulGlyphs.Name = "tb_UsefulGlyphs";
      this.tb_UsefulGlyphs.ReadOnly = true;
      this.tb_UsefulGlyphs.Size = new System.Drawing.Size(224, 29);
      this.tb_UsefulGlyphs.TabIndex = 8;
      this.tb_UsefulGlyphs.Text = "▲ ▼ ◄ ► ♥ ‥ …";
      // 
      // lbl_Block3Bytes
      // 
      this.lbl_Block3Bytes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lbl_Block3Bytes.AutoSize = true;
      this.lbl_Block3Bytes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_Block3Bytes.Location = new System.Drawing.Point(12, 640);
      this.lbl_Block3Bytes.Name = "lbl_Block3Bytes";
      this.lbl_Block3Bytes.Size = new System.Drawing.Size(224, 14);
      this.lbl_Block3Bytes.TabIndex = 5;
      this.lbl_Block3Bytes.Text = "Block 3: 28672 Bytes Free (XX%)";
      // 
      // lbl_Block2Bytes
      // 
      this.lbl_Block2Bytes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lbl_Block2Bytes.AutoSize = true;
      this.lbl_Block2Bytes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_Block2Bytes.Location = new System.Drawing.Point(12, 624);
      this.lbl_Block2Bytes.Name = "lbl_Block2Bytes";
      this.lbl_Block2Bytes.Size = new System.Drawing.Size(224, 14);
      this.lbl_Block2Bytes.TabIndex = 4;
      this.lbl_Block2Bytes.Text = "Block 2: 28672 Bytes Free (XX%)";
      // 
      // lbl_Block1Bytes
      // 
      this.lbl_Block1Bytes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lbl_Block1Bytes.AutoSize = true;
      this.lbl_Block1Bytes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_Block1Bytes.Location = new System.Drawing.Point(12, 609);
      this.lbl_Block1Bytes.Name = "lbl_Block1Bytes";
      this.lbl_Block1Bytes.Size = new System.Drawing.Size(224, 14);
      this.lbl_Block1Bytes.TabIndex = 3;
      this.lbl_Block1Bytes.Text = "Block 1: 28672 Bytes Free (XX%)";
      // 
      // lbl_Block0Bytes
      // 
      this.lbl_Block0Bytes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lbl_Block0Bytes.AutoSize = true;
      this.lbl_Block0Bytes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_Block0Bytes.Location = new System.Drawing.Point(12, 594);
      this.lbl_Block0Bytes.Name = "lbl_Block0Bytes";
      this.lbl_Block0Bytes.Size = new System.Drawing.Size(224, 14);
      this.lbl_Block0Bytes.TabIndex = 2;
      this.lbl_Block0Bytes.Text = "Block 0: 28672 Bytes Free (XX%)";
      // 
      // lbl_SearchInText
      // 
      this.lbl_SearchInText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lbl_SearchInText.AutoSize = true;
      this.lbl_SearchInText.Location = new System.Drawing.Point(244, 14);
      this.lbl_SearchInText.Name = "lbl_SearchInText";
      this.lbl_SearchInText.Size = new System.Drawing.Size(79, 13);
      this.lbl_SearchInText.TabIndex = 9;
      this.lbl_SearchInText.Text = "Search in Text:";
      // 
      // tb_SearchInText
      // 
      this.tb_SearchInText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.tb_SearchInText.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tb_SearchInText.Location = new System.Drawing.Point(247, 30);
      this.tb_SearchInText.Name = "tb_SearchInText";
      this.tb_SearchInText.Size = new System.Drawing.Size(250, 26);
      this.tb_SearchInText.TabIndex = 10;
      // 
      // lb_Lines
      // 
      this.lb_Lines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.lb_Lines.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
      this.lb_Lines.FormattingEnabled = true;
      this.lb_Lines.ItemHeight = 14;
      this.lb_Lines.Items.AddRange(new object[] {
            "0x70000"});
      this.lb_Lines.Location = new System.Drawing.Point(14, 26);
      this.lb_Lines.Name = "lb_Lines";
      this.lb_Lines.Size = new System.Drawing.Size(230, 564);
      this.lb_Lines.TabIndex = 1;
      // 
      // lbl_Lines
      // 
      this.lbl_Lines.AutoSize = true;
      this.lbl_Lines.Location = new System.Drawing.Point(12, 9);
      this.lbl_Lines.Name = "lbl_Lines";
      this.lbl_Lines.Size = new System.Drawing.Size(35, 13);
      this.lbl_Lines.TabIndex = 0;
      this.lbl_Lines.Text = "Lines:";
      // 
      // gb_Line
      // 
      this.gb_Line.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gb_Line.Controls.Add(this.tb_Notes);
      this.gb_Line.Controls.Add(this.previewControl);
      this.gb_Line.Controls.Add(this.lbl_Text);
      this.gb_Line.Controls.Add(this.lbl_Notes);
      this.gb_Line.Controls.Add(this.tb_Text);
      this.gb_Line.Controls.Add(this.tb_Translation);
      this.gb_Line.Controls.Add(this.lbl_Translation);
      this.gb_Line.Controls.Add(this.cb_Skip);
      this.gb_Line.Controls.Add(this.btn_PreviewUp);
      this.gb_Line.Controls.Add(this.btn_PreviewDown);
      this.gb_Line.Location = new System.Drawing.Point(274, 12);
      this.gb_Line.Name = "gb_Line";
      this.gb_Line.Size = new System.Drawing.Size(633, 638);
      this.gb_Line.TabIndex = 6;
      this.gb_Line.TabStop = false;
      this.gb_Line.Text = "0x70000 (Part of Block 0)";
      // 
      // tb_Notes
      // 
      this.tb_Notes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.tb_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tb_Notes.Location = new System.Drawing.Point(9, 416);
      this.tb_Notes.Multiline = true;
      this.tb_Notes.Name = "tb_Notes";
      this.tb_Notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.tb_Notes.Size = new System.Drawing.Size(614, 193);
      this.tb_Notes.TabIndex = 8;
      // 
      // lbl_Text
      // 
      this.lbl_Text.AutoSize = true;
      this.lbl_Text.Location = new System.Drawing.Point(6, 20);
      this.lbl_Text.Name = "lbl_Text";
      this.lbl_Text.Size = new System.Drawing.Size(31, 13);
      this.lbl_Text.TabIndex = 0;
      this.lbl_Text.Text = "Text:";
      // 
      // lbl_Notes
      // 
      this.lbl_Notes.AutoSize = true;
      this.lbl_Notes.Location = new System.Drawing.Point(6, 399);
      this.lbl_Notes.Name = "lbl_Notes";
      this.lbl_Notes.Size = new System.Drawing.Size(38, 13);
      this.lbl_Notes.TabIndex = 7;
      this.lbl_Notes.Text = "Notes:";
      // 
      // tb_Text
      // 
      this.tb_Text.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tb_Text.Location = new System.Drawing.Point(6, 36);
      this.tb_Text.Multiline = true;
      this.tb_Text.Name = "tb_Text";
      this.tb_Text.ReadOnly = true;
      this.tb_Text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.tb_Text.Size = new System.Drawing.Size(613, 104);
      this.tb_Text.TabIndex = 1;
      this.tb_Text.Text = "Line 0\r\nLine 1\r\nLine 2\r\nLine 3\r\nLine 4";
      // 
      // tb_Translation
      // 
      this.tb_Translation.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tb_Translation.Location = new System.Drawing.Point(9, 165);
      this.tb_Translation.Multiline = true;
      this.tb_Translation.Name = "tb_Translation";
      this.tb_Translation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.tb_Translation.Size = new System.Drawing.Size(613, 128);
      this.tb_Translation.TabIndex = 3;
      // 
      // lbl_Translation
      // 
      this.lbl_Translation.AutoSize = true;
      this.lbl_Translation.Location = new System.Drawing.Point(6, 147);
      this.lbl_Translation.Name = "lbl_Translation";
      this.lbl_Translation.Size = new System.Drawing.Size(62, 13);
      this.lbl_Translation.TabIndex = 2;
      this.lbl_Translation.Text = "Translation:";
      // 
      // cb_Skip
      // 
      this.cb_Skip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cb_Skip.AutoSize = true;
      this.cb_Skip.Location = new System.Drawing.Point(6, 615);
      this.cb_Skip.Name = "cb_Skip";
      this.cb_Skip.Size = new System.Drawing.Size(330, 17);
      this.cb_Skip.TabIndex = 9;
      this.cb_Skip.Text = "Skip (Line is changed to empty string as it is unused in the game)";
      this.cb_Skip.UseVisualStyleBackColor = true;
      // 
      // btn_PreviewUp
      // 
      this.btn_PreviewUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn_PreviewUp.Location = new System.Drawing.Point(591, 300);
      this.btn_PreviewUp.Name = "btn_PreviewUp";
      this.btn_PreviewUp.Size = new System.Drawing.Size(32, 23);
      this.btn_PreviewUp.TabIndex = 5;
      this.btn_PreviewUp.Text = "˄";
      this.btn_PreviewUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.btn_PreviewUp.UseVisualStyleBackColor = true;
      // 
      // btn_PreviewDown
      // 
      this.btn_PreviewDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn_PreviewDown.Location = new System.Drawing.Point(591, 329);
      this.btn_PreviewDown.Name = "btn_PreviewDown";
      this.btn_PreviewDown.Size = new System.Drawing.Size(32, 23);
      this.btn_PreviewDown.TabIndex = 6;
      this.btn_PreviewDown.Text = "˅";
      this.btn_PreviewDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.btn_PreviewDown.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(500, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(110, 13);
      this.label1.TabIndex = 11;
      this.label1.Text = "Search in Translation:";
      // 
      // tb_SearchInTranslation
      // 
      this.tb_SearchInTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.tb_SearchInTranslation.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tb_SearchInTranslation.Location = new System.Drawing.Point(503, 30);
      this.tb_SearchInTranslation.Name = "tb_SearchInTranslation";
      this.tb_SearchInTranslation.Size = new System.Drawing.Size(250, 26);
      this.tb_SearchInTranslation.TabIndex = 12;
      // 
      // gb_Footer
      // 
      this.gb_Footer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gb_Footer.Controls.Add(this.cb_SixLetterNames);
      this.gb_Footer.Controls.Add(this.lbl_UsefulGlyphs);
      this.gb_Footer.Controls.Add(this.label1);
      this.gb_Footer.Controls.Add(this.tb_SearchInText);
      this.gb_Footer.Controls.Add(this.tb_SearchInTranslation);
      this.gb_Footer.Controls.Add(this.lbl_SearchInText);
      this.gb_Footer.Controls.Add(this.tb_UsefulGlyphs);
      this.gb_Footer.Location = new System.Drawing.Point(12, 656);
      this.gb_Footer.Name = "gb_Footer";
      this.gb_Footer.Size = new System.Drawing.Size(895, 61);
      this.gb_Footer.TabIndex = 13;
      this.gb_Footer.TabStop = false;
      // 
      // previewControl
      // 
      this.previewControl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.previewControl.Location = new System.Drawing.Point(9, 299);
      this.previewControl.Name = "previewControl";
      this.previewControl.Size = new System.Drawing.Size(576, 96);
      this.previewControl.TabIndex = 4;
      // 
      // cb_SixLetterNames
      // 
      this.cb_SixLetterNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cb_SixLetterNames.AutoSize = true;
      this.cb_SixLetterNames.Location = new System.Drawing.Point(759, 35);
      this.cb_SixLetterNames.Name = "cb_SixLetterNames";
      this.cb_SixLetterNames.Size = new System.Drawing.Size(133, 17);
      this.cb_SixLetterNames.TabIndex = 10;
      this.cb_SixLetterNames.Text = "Assume 6-Letter Name";
      this.cb_SixLetterNames.UseVisualStyleBackColor = true;
      // 
      // DialogEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(919, 729);
      this.Controls.Add(this.gb_Footer);
      this.Controls.Add(this.gb_Line);
      this.Controls.Add(this.lbl_Block3Bytes);
      this.Controls.Add(this.lbl_Block2Bytes);
      this.Controls.Add(this.lbl_Block1Bytes);
      this.Controls.Add(this.lbl_Block0Bytes);
      this.Controls.Add(this.lb_Lines);
      this.Controls.Add(this.lbl_Lines);
      this.MaximizeBox = false;
      this.Name = "DialogEditor";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Text = "For the Frog the Bell Tolls - Dialog Editor";
      this.gb_Line.ResumeLayout(false);
      this.gb_Line.PerformLayout();
      this.gb_Footer.ResumeLayout(false);
      this.gb_Footer.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label lbl_UsefulGlyphs;
    private System.Windows.Forms.TextBox tb_UsefulGlyphs;
    private System.Windows.Forms.Label lbl_Block3Bytes;
    private System.Windows.Forms.Label lbl_Block2Bytes;
    private System.Windows.Forms.Label lbl_Block1Bytes;
    private System.Windows.Forms.Label lbl_Block0Bytes;
    private System.Windows.Forms.Label lbl_SearchInText;
    private System.Windows.Forms.TextBox tb_SearchInText;
    private System.Windows.Forms.ListBox lb_Lines;
    private System.Windows.Forms.Label lbl_Lines;
    private System.Windows.Forms.GroupBox gb_Line;
    private GraphicsControl previewControl;
    private System.Windows.Forms.Label lbl_Text;
    private System.Windows.Forms.Label lbl_Notes;
    private System.Windows.Forms.TextBox tb_Text;
    private System.Windows.Forms.TextBox tb_Translation;
    private System.Windows.Forms.Label lbl_Translation;
    private System.Windows.Forms.CheckBox cb_Skip;
    private System.Windows.Forms.Button btn_PreviewUp;
    private System.Windows.Forms.Button btn_PreviewDown;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tb_SearchInTranslation;
    private System.Windows.Forms.TextBox tb_Notes;
    private System.Windows.Forms.GroupBox gb_Footer;
    private System.Windows.Forms.CheckBox cb_SixLetterNames;
  }
}
