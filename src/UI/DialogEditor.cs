using System.Text;

namespace Frogslator;

public partial class DialogEditor : Form
{
  public static readonly char[] UsefulGlpyhs = ['▲', '▼', '◄', '►', '♥', '‘', '\'', '“', '"', 'é'];

  readonly int[] BlockSizes;

  Line? SelectedLine => lb_Lines.SelectedItem as Line;

  public DialogEditor(byte[] rom, List<Line> lines)
  {
    // Calculate initial block sizes
    BlockSizes = new int[4];
    RecalculateFreeSpace(lines);

    InitializeComponent();
    Text = Program.LastPaths.Frog.Get();
    tb_UsefulGlyphs.Text = string.Join(' ', UsefulGlpyhs);

    MainMenuStrip = new MenuStrip();
    MainMenuStrip.Items.AddRange(
    [
      new ToolStripMenuItem("&File", null,
      [
        new ToolStripMenuItem("Save Translation to Disk...", null, (s, e) => Program.SaveTranslationToDisk(lines.Select(l => l.Translation).ToList())),
        new ToolStripMenuItem("Load Translation from Disk...", null, (s, e) =>
        {
          Program.LoadTranslationFromDisk(lines);
          RecalculateFreeSpace(lines);
          DisplayLines(lines);
        }),
        new ToolStripSeparator(),
        new ToolStripMenuItem("Export ROM...", null, (s, e) => Program.SaveROMToDisk(rom, lines)),
        new ToolStripSeparator(),
        new ToolStripMenuItem("Extract Title Graphics from ROM...", null, (s, e) => Program.ExtractTitleGraphicsFromROM()),
        new ToolStripSeparator(),
        new ToolStripMenuItem("Exit", null, (s, e) => Close())
      ])
    ]);
    Controls.Add(MainMenuStrip);

    btn_PreviewDown.Click += (s, e) =>
    {
      previewControl.SetPage(previewControl.PageIndex + 1);
      btn_PreviewDown.Enabled = previewControl.PageIndex < previewControl.PageCount - 1;
      btn_PreviewUp.Enabled = previewControl.PageIndex > 0;
    };

    btn_PreviewUp.Click += (s, e) =>
    {
      previewControl.SetPage(previewControl.PageIndex - 1);
      btn_PreviewDown.Enabled = previewControl.PageIndex < previewControl.PageCount - 1;
      btn_PreviewUp.Enabled = previewControl.PageIndex > 0;
    };

    foreach (var cb in new[] { cb_FilterErrors, cb_FilterUntranslated })
      cb.CheckedChanged += (s, e) => DisplayLines(lines);

    cb_SixLetterNames.CheckedChanged += (s, e) => DisplayPreview(false, SelectedLine);

    cb_Skip.CheckedChanged += (s, e) =>
    {
      SelectedLine!.Translation.Skip = cb_Skip.Checked;

      RecalculateFreeSpace(lines);
      DisplayFreeSpace();
    };

    lb_Lines.SelectedIndexChanged += (s, e) => DisplayLine(SelectedLine);

    tb_Notes.TextChanged += (s, e) => SelectedLine!.Translation.Notes = tb_Notes.Text.Replace("\r\n", "\n");

    foreach (var tb in new[] { tb_SearchInNotes, tb_SearchInText, tb_SearchInTranslation })
      tb.TextChanged += (s, e) => DisplayLines(lines);

    tb_Translation.TextChanged += (s, e) =>
    {
      var oldBytes = SelectedLine!.Compose(out var oldBytesError);
      SelectedLine.Translation.Text = tb_Translation.Text.Replace("\r\n", "\n");
      var newBytes = SelectedLine.Compose(out var newBytesError);

      var block = SelectedLine.Block;
      if (block.HasValue)
      {
        BlockSizes[block.Value] -= oldBytes?.Length ?? 0;
        BlockSizes[block.Value] += newBytes?.Length ?? 0;
        DisplayFreeSpace();
      }

      if (!string.IsNullOrEmpty(newBytesError))
      {
        lbl_Translation.Text = $"Translation (Error -- {newBytesError}):";
      }
      else
      {
        lbl_Translation.Text = $"Translation ({newBytes?.Length.ToString() ?? "?"} bytes):";
      }

      DisplayPreview(false, SelectedLine);
    };

    BringToFront();
    DisplayLines(lines);
  }

  void DisplayFreeSpace()
  {
    string FreeSpaceString(int i)
    {
      var bytesFree = Program.MaxBlockSize - BlockSizes[i];
      var pctFree = (100 * ((double)(Program.MaxBlockSize - BlockSizes[i]) / Program.MaxBlockSize)).ToString("N2");
      return $"Block {i}: {bytesFree} bytes free ({pctFree}%)";
    }

    lbl_Block0Bytes.Text = FreeSpaceString(0);
    lbl_Block1Bytes.Text = FreeSpaceString(1);
    lbl_Block2Bytes.Text = FreeSpaceString(2);
    lbl_Block3Bytes.Text = FreeSpaceString(3);
  }

  void DisplayLine(Line? line)
  {
    gb_Line.Visible = line is not null;

    if (line is not null)
    {
      cb_Skip.Checked = line.Translation.Skip;
      cb_Skip.Enabled = line.Block.HasValue;

      if (line.Category == LineCategories.Dialog)
      {
        lb_DAT.Items.Clear();
        foreach (var datIndex in line.DialogAddressTableIndicies)
        {
          lb_DAT.Items.Add(datIndex);
        }

        lb_DAT.Visible = true;
        lbl_DAT.Visible = true;
      }
      else
      {
        lb_DAT.Items.Clear();

        lb_DAT.Visible = false;
        lbl_DAT.Visible = false;
      }

      gb_Line.Text = $@"0x{line.Address:X2}: {line.Category}";

      var bytesText = line.AllBytes.Length > 0 ? $@" ({line.AllBytes.Length} bytes)" : string.Empty;
      lbl_Text.Text = $@"Text{bytesText}";

      tb_Notes.Text = line.Translation.Notes.Replace("\n", "\r\n");

      tb_Text.Text = line.Text.Replace("\n", "\r\n");

      tb_Translation.Text = line.Translation.Text.Replace("\n", "\r\n");
    }

    DisplayPreview(true, line);
  }

  void DisplayLines(List<Line> lines)
  {
    static bool GetHasError(Line line)
    {
      return line.Compose(out var error) is null || error is not null;
    }

    static bool GetIsUntranslated(Line line)
    {
      if (line.Translation.Skip || string.IsNullOrWhiteSpace(line.Text))
        return false;

      return string.IsNullOrWhiteSpace(line.Translation.Text);
    }

    static bool PassContains(string s, string value)
    {
      var sTrimmed = s.Trim();
      var valueTrimmed = value.Trim();

      return string.IsNullOrWhiteSpace(valueTrimmed) || sTrimmed.Contains(valueTrimmed, StringComparison.OrdinalIgnoreCase);
    }

    lb_Lines.Items.Clear();

    // Add lines and filter.
    var asdf = new StringBuilder();
    foreach (var line in lines)
    {
      if (PassContains(line.Translation.Notes, tb_SearchInNotes.Text) &&
          PassContains(line.Text, tb_SearchInText.Text) &&
          PassContains(line.Translation.Text, tb_SearchInTranslation.Text) &&
          (!cb_FilterErrors.Checked || GetHasError(line)) &&
          (!cb_FilterUntranslated.Checked || GetIsUntranslated(line)))
      {
          lb_Lines.Items.Add(line);
      }
    }
    var ret = asdf.ToString();

    // Select the first line and display the line count.
    lb_Lines.SelectedIndex = lb_Lines.Items.Count > 0 ? 0 : -1;
    lbl_Lines.Text = $@"Lines ({lb_Lines.Items.Count} items)";

    DisplayLine(SelectedLine);

    DisplayFreeSpace();
  }

  void DisplayPreview(bool reset, Line? line)
  {
    if (line is null)
    {
      previewControl.Setup(true, 1, 1, string.Empty, false);
      return;
    }

    previewControl.Setup(reset, line.BoxHeight, line.BoxWidth, line.Translation.Text, cb_SixLetterNames.Checked);

    btn_PreviewUp.Enabled = previewControl.PageIndex > 0;
    btn_PreviewDown.Enabled = previewControl.PageIndex < previewControl.PageCount - 1;

    btn_PreviewUp.Location = new Point(previewControl.Location.X + previewControl.Size.Width + 5, btn_PreviewUp.Location.Y);
    btn_PreviewDown.Location = new Point(previewControl.Location.X + previewControl.Size.Width + 5, btn_PreviewDown.Location.Y);
  }

  void RecalculateFreeSpace(List<Line> lines)
  {
    for (int i = 0; i < BlockSizes.Length; i++)
    {
      BlockSizes[i] = 0;
    }

    foreach (var l in lines)
    {
      var block = l.Block;
      if (block.HasValue)
      {
        var bytes = l.Compose(out _)?.Length ?? 0;
        BlockSizes[block.Value] += bytes;
      }
    }
  }
}
