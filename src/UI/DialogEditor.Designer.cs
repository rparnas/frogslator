namespace Frogslator
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
      label7 = new Label();
      lbl_UsefulGlyphs = new Label();
      tb_UsefulGlyphs = new TextBox();
      lbl_Block3Bytes = new Label();
      lbl_Block2Bytes = new Label();
      lbl_Block1Bytes = new Label();
      lbl_Block0Bytes = new Label();
      lbl_SearchInText = new Label();
      tb_SearchInText = new TextBox();
      lb_Lines = new ListBox();
      lbl_Lines = new Label();
      gb_Line = new GroupBox();
      lb_DAT = new ListBox();
      lbl_DAT = new Label();
      tb_Notes = new TextBox();
      previewControl = new GraphicsControl();
      lbl_Text = new Label();
      lbl_Notes = new Label();
      tb_Text = new TextBox();
      tb_Translation = new TextBox();
      lbl_Translation = new Label();
      cb_Skip = new CheckBox();
      btn_PreviewUp = new Button();
      btn_PreviewDown = new Button();
      label1 = new Label();
      tb_SearchInTranslation = new TextBox();
      gb_Footer = new GroupBox();
      label2 = new Label();
      tb_SearchInNotes = new TextBox();
      cb_FilterUntranslated = new CheckBox();
      cb_FilterErrors = new CheckBox();
      cb_SixLetterNames = new CheckBox();
      gb_Line.SuspendLayout();
      gb_Footer.SuspendLayout();
      SuspendLayout();
      // 
      // label7
      // 
      label7.Location = new Point(0, 0);
      label7.Name = "label7";
      label7.Size = new Size(100, 23);
      label7.TabIndex = 0;
      // 
      // lbl_UsefulGlyphs
      // 
      lbl_UsefulGlyphs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      lbl_UsefulGlyphs.AutoSize = true;
      lbl_UsefulGlyphs.Font = new Font("Segoe UI", 9F);
      lbl_UsefulGlyphs.Location = new Point(6, 21);
      lbl_UsefulGlyphs.Margin = new Padding(4, 0, 4, 0);
      lbl_UsefulGlyphs.Name = "lbl_UsefulGlyphs";
      lbl_UsefulGlyphs.Size = new Size(187, 15);
      lbl_UsefulGlyphs.TabIndex = 7;
      lbl_UsefulGlyphs.Text = "Glyphs (copy-paste to Translation)";
      // 
      // tb_UsefulGlyphs
      // 
      tb_UsefulGlyphs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      tb_UsefulGlyphs.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
      tb_UsefulGlyphs.Location = new Point(9, 39);
      tb_UsefulGlyphs.Margin = new Padding(4, 3, 4, 3);
      tb_UsefulGlyphs.Name = "tb_UsefulGlyphs";
      tb_UsefulGlyphs.ReadOnly = true;
      tb_UsefulGlyphs.Size = new Size(205, 26);
      tb_UsefulGlyphs.TabIndex = 8;
      tb_UsefulGlyphs.Text = "▲ ▼ ◄ ► ♥ ‘ ' “ \" é";
      // 
      // lbl_Block3Bytes
      // 
      lbl_Block3Bytes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      lbl_Block3Bytes.AutoSize = true;
      lbl_Block3Bytes.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
      lbl_Block3Bytes.Location = new Point(14, 626);
      lbl_Block3Bytes.Margin = new Padding(4, 0, 4, 0);
      lbl_Block3Bytes.Name = "lbl_Block3Bytes";
      lbl_Block3Bytes.Size = new Size(224, 14);
      lbl_Block3Bytes.TabIndex = 5;
      lbl_Block3Bytes.Text = "Block 3: 28672 Bytes Free (XX%)";
      // 
      // lbl_Block2Bytes
      // 
      lbl_Block2Bytes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      lbl_Block2Bytes.AutoSize = true;
      lbl_Block2Bytes.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
      lbl_Block2Bytes.Location = new Point(14, 608);
      lbl_Block2Bytes.Margin = new Padding(4, 0, 4, 0);
      lbl_Block2Bytes.Name = "lbl_Block2Bytes";
      lbl_Block2Bytes.Size = new Size(224, 14);
      lbl_Block2Bytes.TabIndex = 4;
      lbl_Block2Bytes.Text = "Block 2: 28672 Bytes Free (XX%)";
      // 
      // lbl_Block1Bytes
      // 
      lbl_Block1Bytes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      lbl_Block1Bytes.AutoSize = true;
      lbl_Block1Bytes.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
      lbl_Block1Bytes.Location = new Point(14, 591);
      lbl_Block1Bytes.Margin = new Padding(4, 0, 4, 0);
      lbl_Block1Bytes.Name = "lbl_Block1Bytes";
      lbl_Block1Bytes.Size = new Size(224, 14);
      lbl_Block1Bytes.TabIndex = 3;
      lbl_Block1Bytes.Text = "Block 1: 28672 Bytes Free (XX%)";
      // 
      // lbl_Block0Bytes
      // 
      lbl_Block0Bytes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      lbl_Block0Bytes.AutoSize = true;
      lbl_Block0Bytes.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
      lbl_Block0Bytes.Location = new Point(14, 573);
      lbl_Block0Bytes.Margin = new Padding(4, 0, 4, 0);
      lbl_Block0Bytes.Name = "lbl_Block0Bytes";
      lbl_Block0Bytes.Size = new Size(224, 14);
      lbl_Block0Bytes.TabIndex = 2;
      lbl_Block0Bytes.Text = "Block 0: 28672 Bytes Free (XX%)";
      // 
      // lbl_SearchInText
      // 
      lbl_SearchInText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      lbl_SearchInText.AutoSize = true;
      lbl_SearchInText.Font = new Font("Segoe UI", 9F);
      lbl_SearchInText.Location = new Point(223, 21);
      lbl_SearchInText.Margin = new Padding(4, 0, 4, 0);
      lbl_SearchInText.Name = "lbl_SearchInText";
      lbl_SearchInText.Size = new Size(66, 15);
      lbl_SearchInText.TabIndex = 9;
      lbl_SearchInText.Text = "Search Text";
      // 
      // tb_SearchInText
      // 
      tb_SearchInText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      tb_SearchInText.Font = new Font("MS Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
      tb_SearchInText.Location = new Point(223, 42);
      tb_SearchInText.Margin = new Padding(4, 3, 4, 3);
      tb_SearchInText.Name = "tb_SearchInText";
      tb_SearchInText.Size = new Size(180, 26);
      tb_SearchInText.TabIndex = 10;
      // 
      // lb_Lines
      // 
      lb_Lines.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      lb_Lines.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 177);
      lb_Lines.FormattingEnabled = true;
      lb_Lines.ItemHeight = 14;
      lb_Lines.Items.AddRange(new object[] { "0x70000" });
      lb_Lines.Location = new Point(16, 44);
      lb_Lines.Margin = new Padding(4, 3, 4, 3);
      lb_Lines.Name = "lb_Lines";
      lb_Lines.Size = new Size(268, 522);
      lb_Lines.TabIndex = 1;
      // 
      // lbl_Lines
      // 
      lbl_Lines.AutoSize = true;
      lbl_Lines.Location = new Point(14, 26);
      lbl_Lines.Margin = new Padding(4, 0, 4, 0);
      lbl_Lines.Name = "lbl_Lines";
      lbl_Lines.Size = new Size(34, 15);
      lbl_Lines.TabIndex = 0;
      lbl_Lines.Text = "Lines";
      // 
      // gb_Line
      // 
      gb_Line.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      gb_Line.Controls.Add(lb_DAT);
      gb_Line.Controls.Add(lbl_DAT);
      gb_Line.Controls.Add(tb_Notes);
      gb_Line.Controls.Add(previewControl);
      gb_Line.Controls.Add(lbl_Text);
      gb_Line.Controls.Add(lbl_Notes);
      gb_Line.Controls.Add(tb_Text);
      gb_Line.Controls.Add(tb_Translation);
      gb_Line.Controls.Add(lbl_Translation);
      gb_Line.Controls.Add(cb_Skip);
      gb_Line.Controls.Add(btn_PreviewUp);
      gb_Line.Controls.Add(btn_PreviewDown);
      gb_Line.Location = new Point(293, 15);
      gb_Line.Margin = new Padding(4, 3, 4, 3);
      gb_Line.Name = "gb_Line";
      gb_Line.Padding = new Padding(4, 3, 4, 3);
      gb_Line.Size = new Size(701, 624);
      gb_Line.TabIndex = 6;
      gb_Line.TabStop = false;
      gb_Line.Text = "0x70000 (Part of Block 0)";
      // 
      // lb_DAT
      // 
      lb_DAT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      lb_DAT.FormattingEnabled = true;
      lb_DAT.ItemHeight = 15;
      lb_DAT.Location = new Point(525, 192);
      lb_DAT.Name = "lb_DAT";
      lb_DAT.Size = new Size(154, 139);
      lb_DAT.TabIndex = 11;
      // 
      // lbl_DAT
      // 
      lbl_DAT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      lbl_DAT.AutoSize = true;
      lbl_DAT.Font = new Font("Segoe UI", 9F);
      lbl_DAT.Location = new Point(520, 170);
      lbl_DAT.Margin = new Padding(4, 0, 4, 0);
      lbl_DAT.Name = "lbl_DAT";
      lbl_DAT.Size = new Size(159, 15);
      lbl_DAT.TabIndex = 10;
      lbl_DAT.Text = "Dialog Address Table Indicies";
      // 
      // tb_Notes
      // 
      tb_Notes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tb_Notes.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
      tb_Notes.Location = new Point(10, 480);
      tb_Notes.Margin = new Padding(4, 3, 4, 3);
      tb_Notes.Multiline = true;
      tb_Notes.Name = "tb_Notes";
      tb_Notes.ScrollBars = ScrollBars.Vertical;
      tb_Notes.Size = new Size(683, 110);
      tb_Notes.TabIndex = 8;
      // 
      // previewControl
      // 
      previewControl.BackColor = SystemColors.ActiveCaptionText;
      previewControl.Location = new Point(10, 345);
      previewControl.Margin = new Padding(5, 3, 5, 3);
      previewControl.Name = "previewControl";
      previewControl.Size = new Size(656, 111);
      previewControl.TabIndex = 4;
      // 
      // lbl_Text
      // 
      lbl_Text.AutoSize = true;
      lbl_Text.Font = new Font("Segoe UI", 9F);
      lbl_Text.Location = new Point(7, 23);
      lbl_Text.Margin = new Padding(4, 0, 4, 0);
      lbl_Text.Name = "lbl_Text";
      lbl_Text.Size = new Size(28, 15);
      lbl_Text.TabIndex = 0;
      lbl_Text.Text = "Text";
      // 
      // lbl_Notes
      // 
      lbl_Notes.AutoSize = true;
      lbl_Notes.Font = new Font("Segoe UI", 9F);
      lbl_Notes.Location = new Point(7, 460);
      lbl_Notes.Margin = new Padding(4, 0, 4, 0);
      lbl_Notes.Name = "lbl_Notes";
      lbl_Notes.Size = new Size(38, 15);
      lbl_Notes.TabIndex = 7;
      lbl_Notes.Text = "Notes";
      // 
      // tb_Text
      // 
      tb_Text.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      tb_Text.Font = new Font("MS Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
      tb_Text.Location = new Point(7, 42);
      tb_Text.Margin = new Padding(4, 3, 4, 3);
      tb_Text.Multiline = true;
      tb_Text.Name = "tb_Text";
      tb_Text.ReadOnly = true;
      tb_Text.ScrollBars = ScrollBars.Vertical;
      tb_Text.Size = new Size(686, 119);
      tb_Text.TabIndex = 1;
      tb_Text.Text = "Line 0\r\nLine 1\r\nLine 2\r\nLine 3\r\nLine 4";
      // 
      // tb_Translation
      // 
      tb_Translation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      tb_Translation.Font = new Font("MS Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
      tb_Translation.Location = new Point(10, 190);
      tb_Translation.Margin = new Padding(4, 3, 4, 3);
      tb_Translation.Multiline = true;
      tb_Translation.Name = "tb_Translation";
      tb_Translation.ScrollBars = ScrollBars.Vertical;
      tb_Translation.Size = new Size(500, 147);
      tb_Translation.TabIndex = 3;
      tb_Translation.Text = "124566789012345678124566789012345678";
      // 
      // lbl_Translation
      // 
      lbl_Translation.AutoSize = true;
      lbl_Translation.Font = new Font("Segoe UI", 9F);
      lbl_Translation.Location = new Point(7, 170);
      lbl_Translation.Margin = new Padding(4, 0, 4, 0);
      lbl_Translation.Name = "lbl_Translation";
      lbl_Translation.Size = new Size(64, 15);
      lbl_Translation.TabIndex = 2;
      lbl_Translation.Text = "Translation";
      // 
      // cb_Skip
      // 
      cb_Skip.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      cb_Skip.AutoSize = true;
      cb_Skip.Location = new Point(7, 598);
      cb_Skip.Margin = new Padding(4, 3, 4, 3);
      cb_Skip.Name = "cb_Skip";
      cb_Skip.Size = new Size(208, 19);
      cb_Skip.TabIndex = 9;
      cb_Skip.Text = "Skip (Mark line to not be included)";
      cb_Skip.UseVisualStyleBackColor = true;
      // 
      // btn_PreviewUp
      // 
      btn_PreviewUp.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
      btn_PreviewUp.Location = new Point(690, 346);
      btn_PreviewUp.Margin = new Padding(4, 3, 4, 3);
      btn_PreviewUp.Name = "btn_PreviewUp";
      btn_PreviewUp.Size = new Size(37, 27);
      btn_PreviewUp.TabIndex = 5;
      btn_PreviewUp.Text = "˄";
      btn_PreviewUp.TextAlign = ContentAlignment.BottomCenter;
      btn_PreviewUp.UseVisualStyleBackColor = true;
      // 
      // btn_PreviewDown
      // 
      btn_PreviewDown.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
      btn_PreviewDown.Location = new Point(690, 380);
      btn_PreviewDown.Margin = new Padding(4, 3, 4, 3);
      btn_PreviewDown.Name = "btn_PreviewDown";
      btn_PreviewDown.Size = new Size(37, 27);
      btn_PreviewDown.TabIndex = 6;
      btn_PreviewDown.Text = "˅";
      btn_PreviewDown.TextAlign = ContentAlignment.BottomCenter;
      btn_PreviewDown.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 9F);
      label1.Location = new Point(411, 21);
      label1.Margin = new Padding(4, 0, 4, 0);
      label1.Name = "label1";
      label1.Size = new Size(102, 15);
      label1.TabIndex = 11;
      label1.Text = "Search Translation";
      // 
      // tb_SearchInTranslation
      // 
      tb_SearchInTranslation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      tb_SearchInTranslation.Font = new Font("MS Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
      tb_SearchInTranslation.Location = new Point(411, 41);
      tb_SearchInTranslation.Margin = new Padding(4, 3, 4, 3);
      tb_SearchInTranslation.Name = "tb_SearchInTranslation";
      tb_SearchInTranslation.Size = new Size(180, 26);
      tb_SearchInTranslation.TabIndex = 12;
      // 
      // gb_Footer
      // 
      gb_Footer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      gb_Footer.Controls.Add(label2);
      gb_Footer.Controls.Add(tb_SearchInNotes);
      gb_Footer.Controls.Add(cb_FilterUntranslated);
      gb_Footer.Controls.Add(cb_FilterErrors);
      gb_Footer.Controls.Add(cb_SixLetterNames);
      gb_Footer.Controls.Add(lbl_UsefulGlyphs);
      gb_Footer.Controls.Add(label1);
      gb_Footer.Controls.Add(tb_SearchInText);
      gb_Footer.Controls.Add(tb_SearchInTranslation);
      gb_Footer.Controls.Add(lbl_SearchInText);
      gb_Footer.Controls.Add(tb_UsefulGlyphs);
      gb_Footer.Location = new Point(14, 645);
      gb_Footer.Margin = new Padding(4, 3, 4, 3);
      gb_Footer.Name = "gb_Footer";
      gb_Footer.Padding = new Padding(4, 3, 4, 3);
      gb_Footer.Size = new Size(980, 81);
      gb_Footer.TabIndex = 13;
      gb_Footer.TabStop = false;
      // 
      // label2
      // 
      label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      label2.AutoSize = true;
      label2.Font = new Font("Segoe UI", 9F);
      label2.Location = new Point(599, 23);
      label2.Margin = new Padding(4, 0, 4, 0);
      label2.Name = "label2";
      label2.Size = new Size(76, 15);
      label2.TabIndex = 16;
      label2.Text = "Search Notes";
      // 
      // tb_SearchInNotes
      // 
      tb_SearchInNotes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      tb_SearchInNotes.Font = new Font("MS Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
      tb_SearchInNotes.Location = new Point(599, 41);
      tb_SearchInNotes.Margin = new Padding(4, 3, 4, 3);
      tb_SearchInNotes.Name = "tb_SearchInNotes";
      tb_SearchInNotes.Size = new Size(180, 26);
      tb_SearchInNotes.TabIndex = 15;
      // 
      // cb_FilterUntranslated
      // 
      cb_FilterUntranslated.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      cb_FilterUntranslated.AutoSize = true;
      cb_FilterUntranslated.Location = new Point(786, 39);
      cb_FilterUntranslated.Margin = new Padding(4, 3, 4, 3);
      cb_FilterUntranslated.Name = "cb_FilterUntranslated";
      cb_FilterUntranslated.Size = new Size(119, 19);
      cb_FilterUntranslated.TabIndex = 14;
      cb_FilterUntranslated.Text = "Find Untranslated";
      cb_FilterUntranslated.UseVisualStyleBackColor = true;
      // 
      // cb_FilterErrors
      // 
      cb_FilterErrors.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      cb_FilterErrors.AutoSize = true;
      cb_FilterErrors.Location = new Point(786, 19);
      cb_FilterErrors.Margin = new Padding(4, 3, 4, 3);
      cb_FilterErrors.Name = "cb_FilterErrors";
      cb_FilterErrors.Size = new Size(82, 19);
      cb_FilterErrors.TabIndex = 13;
      cb_FilterErrors.Text = "Find Errors";
      cb_FilterErrors.UseVisualStyleBackColor = true;
      // 
      // cb_SixLetterNames
      // 
      cb_SixLetterNames.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      cb_SixLetterNames.AutoSize = true;
      cb_SixLetterNames.Location = new Point(876, 19);
      cb_SixLetterNames.Margin = new Padding(4, 3, 4, 3);
      cb_SixLetterNames.Name = "cb_SixLetterNames";
      cb_SixLetterNames.Size = new Size(97, 19);
      cb_SixLetterNames.TabIndex = 10;
      cb_SixLetterNames.Text = "6-Char Name";
      cb_SixLetterNames.UseVisualStyleBackColor = true;
      // 
      // DialogEditor
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1008, 729);
      Controls.Add(gb_Footer);
      Controls.Add(gb_Line);
      Controls.Add(lbl_Block3Bytes);
      Controls.Add(lbl_Block2Bytes);
      Controls.Add(lbl_Block1Bytes);
      Controls.Add(lbl_Block0Bytes);
      Controls.Add(lb_Lines);
      Controls.Add(lbl_Lines);
      Margin = new Padding(4, 3, 4, 3);
      MaximizeBox = false;
      MinimumSize = new Size(1024, 768);
      Name = "DialogEditor";
      SizeGripStyle = SizeGripStyle.Hide;
      Text = "For the Frog the Bell Tolls - Dialog Editor";
      gb_Line.ResumeLayout(false);
      gb_Line.PerformLayout();
      gb_Footer.ResumeLayout(false);
      gb_Footer.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
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
    private System.Windows.Forms.CheckBox cb_FilterUntranslated;
    private System.Windows.Forms.CheckBox cb_FilterErrors;
    private Label label2;
    private TextBox tb_SearchInNotes;
    private Label lbl_DAT;
    private ListBox lb_DAT;
  }
}
