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
    Text = Program.LastTranslationPath;
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

    cb_FilterErrors.CheckedChanged += (s, e) => DisplayLines(lines);

    cb_FilterUntranslated.CheckedChanged += (s, e) => DisplayLines(lines);

    cb_SixLetterNames.CheckedChanged += (s, e) => DisplayPreview(false, SelectedLine);

    cb_Skip.CheckedChanged += (s, e) =>
    {
      SelectedLine!.Translation.Skip = cb_Skip.Checked;

      RecalculateFreeSpace(lines);
      DisplayFreeSpace();
    };

    lb_Lines.SelectedIndexChanged += (s, e) => DisplayLine(SelectedLine);

    tb_Notes.TextChanged += (s, e) => SelectedLine!.Translation.Notes = tb_Notes.Text.Replace("\r\n", "\n");

    tb_SearchInText.TextChanged += (s, e) => DisplayLines(lines);

    tb_SearchInTranslation.TextChanged += (s, e) => DisplayLines(lines);

    tb_Translation.TextChanged += (s, e) =>
    {
      var oldBytes = SelectedLine!.Compose(out var oldBytesError);
      SelectedLine.Translation.Text = tb_Translation.Text.Replace("\r\n", "\n");
      var newBytes = SelectedLine.Compose(out var newBytesError);

      if (SelectedLine.Block >= 0)
      {
        BlockSizes[SelectedLine.Block] -= oldBytes?.Length ?? 0;
        BlockSizes[SelectedLine.Block] += newBytes?.Length ?? 0;
        DisplayFreeSpace();
      }

      if (!string.IsNullOrEmpty(newBytesError))
      {
        lbl_Translation.Text = $"Translation -- Error: {newBytesError}";
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
      cb_Skip.Enabled = line.Block >= 0;
      gb_Line.Text = "0x" + line.Address.ToString("X2") + (line.Block < 0 ? " (Special Text)" : $" (Dialog Block {line.Block})");
      lbl_Text.Text = $"Text ({line.AllBytes.Length} bytes):";
      tb_Notes.Text = line.Translation.Notes.Replace("\n", "\r\n");
      tb_Text.Text = line.Text.Replace("\n", "\r\n");
      tb_Translation.Text = line.Translation.Text.Replace("\n", "\r\n");
    }

    DisplayPreview(true, line);
  }

  void DisplayLines(List<Line> lines)
  {
    lb_Lines.Items.Clear();

    // Add lines and filter.
    foreach (var line in lines)
    {
      if (!string.IsNullOrEmpty(tb_SearchInText.Text) && !line.Text.Contains(tb_SearchInText.Text))
      {
        continue;
      }
      if (!string.IsNullOrEmpty(tb_SearchInTranslation.Text) && !line.Translation.Text.Contains(tb_SearchInTranslation.Text))
      {
        continue;
      }
      if (cb_FilterErrors.Checked && (line.Compose(out var error) != null || error == null))
      {
        continue;
      }
      if (cb_FilterUntranslated.Checked && !string.IsNullOrEmpty(line.Translation.Text) && !line.Translation.Skip)
      {
        continue;
      }

      lb_Lines.Items.Add(line);
    }

    // Select the first line and display the line count.
    lb_Lines.SelectedIndex = lb_Lines.Items.Count > 0 ? 0 : -1;
    lbl_Lines.Text = "Lines (" + lb_Lines.Items.Count + " items)";

    DisplayLine(SelectedLine);

    DisplayFreeSpace();
  }

  void DisplayPreview(bool reset, Line? line)
  {
    if (line is null)
    {
      previewControl.Setup(true, 1, 1, "");
      return;
    }

    var displayLines = line.Translation.Text
      .Split('\n')
      .ToList();
    for (var i = 0; i < displayLines.Count; i++)
    {
      var displayLine = displayLines[i];

      displayLine = displayLine.Replace("[Text Name]", cb_SixLetterNames.Checked ? "~NAME~" : "NAME");

      while (displayLine.Contains('['))
      {
        var openIndex = displayLine.IndexOf('[');
        var closeIndex = displayLine.IndexOf(']');
        if (closeIndex == -1)
        {
          break;
        }

        var term = displayLine.Substring(openIndex, closeIndex - openIndex + 1);
        if (term == "[Jumbo]")
          displayLines.Insert(i + 1, string.Empty);

        displayLine = displayLine.Remove(openIndex, closeIndex - openIndex + 1);
      }

      displayLines[i] = displayLine;
    }

    previewControl.Setup(reset, line.BoxHeight, line.BoxWidth, string.Join('\n', displayLines.ToArray()));

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

    foreach (var l in lines.Where(l => l.Block >= 0))
    {
      var bytes = l.Compose(out _)?.Length ?? 0;
      BlockSizes[l.Block] += bytes;
    }
  }
}
