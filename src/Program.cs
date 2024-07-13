using System.Text;

namespace Frogslator;

static class Program
{
  public static readonly int MaxBlockSize = 0x4000;
  public static readonly string GBFilter = "GameBoy File(*.gb)|*.gb";
  public static readonly string FrogFilter = "Frog File (*.frog)|*.frog";

  public static List<GameBoyTile> FontBitmaps { get; private set; }
  public static byte[] Graphics_TitleScreen { get; private set; }
  public static byte[] Graphics_Font { get; private set; }

  static string? DoFileDialog(FileDialog fd, string title, string filter, StringSetting lastPath)
  {
    var path = lastPath.Get();
    
    if (!string.IsNullOrWhiteSpace(path))
    {
      var dir = new FileInfo(path).Directory;
      if (dir is not null && dir.Exists)
      {
        fd.InitialDirectory = dir.FullName;
      }
    }

    fd.Title = title;
    
    fd.Filter = filter;

    if (fd.ShowDialog() != DialogResult.OK)
    {
      return null;
    }

    lastPath.Set(fd.FileName);

    return fd.FileName;
  }

  public static void ExtractTitleGraphicsFromROM()
  {
    var block = Constants.Blocks.TitleGraphics;

    var address = block.Start.ToString("X2");
    var loadPath = DoFileDialog(new OpenFileDialog(), $@"Choose any Kaeru no Tame ni Kane Wa Naru ROM, original or modified, where the title is at 0x{address}", GBFilter, LastPaths.LoadAltROM);
    if (loadPath is null)
    {
      return;
    }

    var savePath = DoFileDialog(new SaveFileDialog(), "Save title graphics binary", GBFilter, LastPaths.SaveBIN); 
    if (savePath is null)
    {
      return;
    }

    var rom = File.ReadAllBytes(loadPath);

    var bin = new byte[block.Length];
    for (var i = 0; i < bin.Length; i++)
    {
      bin[i] = rom[i + block.Start];
    }

    File.WriteAllBytes(savePath, bin);
  }

  public static byte[]? LoadROMFromDisk()
  {
    var path = DoFileDialog(new OpenFileDialog(), "Choose a valid Japanese Kaeru no Tame ni Kane Wa Naru ROM", GBFilter, LastPaths.LoadROM);
    if (path is null)
    {
      return null;
    }

    var ret = LoadROMFromDisk(path, out var error);
    if (error is not null)
    {
      MessageBox.Show(error);
      return null;
    }

    return ret;
  }

  public static byte[]? LoadROMFromDisk(string path, out string? error)
  {
    var ret = File.ReadAllBytes(path);
    if (ret.Length != 0x80000)
    {
      error = "The ROM must be 512 KB.";
      return null;
    }

    if (ret.Sum(b => b) != 77074606)
    {
      error = "The Checksum of this ROM was not as expected. You must use the original Japanese version of the game.";
      return null;
    }

    error = null;
    return ret;
  }

  public static void LoadTranslationFromDisk(List<Line> lines)
  {
    var path = DoFileDialog(new OpenFileDialog(), "Load Translation", FrogFilter, LastPaths.Frog);
    if (path is null)
    {
      return;
    }

    LoadTranslationFromDisk(path, lines);
  }

  public static void LoadTranslationFromDisk(string path, List<Line> lines)
  {
    var ret = new List<Translation>();
    var translation = (Translation)null;
    var target = (Action<string>)null;

    foreach (var line in File.ReadAllLines(path))
    {
      if (line.StartsWith("Address: 0x"))
      {
        translation = new Translation(int.Parse(line.Substring("Address: 0x".Length), System.Globalization.NumberStyles.AllowHexSpecifier));
        ret.Add(translation);
        target = null;
      }
      else if (line.StartsWith("Text: "))
      {
        target = s => translation.Text += s;
        target(line.Substring("Text :".Length));
      }
      else if (line.StartsWith("Note: "))
      {
        target = s => translation.Notes += s;
        target(line.Substring("Note: ".Length));
      }
      else if (line.StartsWith("Skip: "))
      {
        translation.Skip = line.Substring("Skip: ".Length) == "TRUE";
        target = null;
      }
      else
      {
        target("\n" + line);
      }
    }

    foreach (var line in lines)
    {
      var t = ret.FirstOrDefault(x => x.Address == line.Address) ?? new Translation(line.Address);
      line.Translation.Notes = t.Notes;
      line.Translation.Skip = t.Skip;
      line.Translation.Text = t.Text;
    }
  }

  public static void SaveROMToDisk(byte[] rom, List<Line> lines)
  {
    var path = DoFileDialog(new SaveFileDialog(), "Save ROM", GBFilter, LastPaths.SaveROM);
    if (path is null)
    {
      return;
    }

    SaveROMToDisk(path, rom, lines, out var error);
    if (error is not null)
    {
      MessageBox.Show("Could not save ROM because at least one line has an error:\r\n" + error);
    }
  }

  public static void SaveROMToDisk(string path, byte[] rom, List<Line> lines, out string? error)
  {
    var newROM = rom.ToArray();

    void WriteDialog(int block, int blockOffset, int newBlockOffset, out string? dialogError)
    {
      var romIndex = newBlockOffset;

      // For each line in this block.
      foreach (var l in lines.Where(line => line.Block == block))
      {
        var newAddress = romIndex;

        // Add this line to the Dialog Block
        var newBytes = l.Compose(out var e);
        if (newBytes is null)
        {
          dialogError = $@"0x{l.Address:X2} -- {(e is null ? "Unknown" : e)}";
          return;
        }
        else
        {
          foreach (var b in newBytes)
          {
            if (romIndex < newROM.Length)
            {
              newROM[romIndex] = b;
            }
            romIndex++;
          }
        }

        // Set references to this line in the DialogAddressTable
        var offset = newAddress - newBlockOffset;
        var offsetBytes = Utils.GetBytes(offset, 2);
        var datStart = Constants.Blocks.DialogAddressTable.Start;
        foreach (var datIndex in l.DialogAddressTableIndicies)
        {
          newROM[datStart + (datIndex * 2)]     = offsetBytes[1];
          newROM[datStart + (datIndex * 2) + 1] = offsetBytes[0];
        }
      }

      dialogError = null;
    }

    // Change the text table for the opening screen.
    for (byte i = 0; i < 71; i++)
    {
      var addr = 0xB62A + 2 * i;
      newROM[addr] = (byte)(0x50 + i);
      newROM[addr + 1] = 0x00;
    }
    newROM[0xB62A] = 0x50;
    newROM[0xB6B4] = 0x44;
    newROM[0xB6B6] = 0x45;

    // Clear the DialogBlock section.
    for (int i = 0x70000; i < newROM.Length; i++)
    {
      newROM[i] = 0xFF;
    }

    // Change the title graphics.
    Array.Copy(Graphics_TitleScreen, 0, newROM, Constants.Blocks.TitleGraphics.Start, Constants.Blocks.TitleGraphics.Stop - Constants.Blocks.TitleGraphics.Start);
    
    // Change the font graphics.
    Array.Copy(Graphics_Font, 0, newROM, Constants.Blocks.FontGraphics.Start, Constants.Blocks.FontGraphics.Stop - Constants.Blocks.FontGraphics.Start); 

    // Dialog
    WriteDialog(0, 0x70000, 0x70000, out error);
    if (error is not null) { return; }

    WriteDialog(1, 0x74000, 0x74000, out error);
    if (error is not null) { return; }

    WriteDialog(2, 0x78000, 0x78000, out error);
    if (error is not null) { return; }

    WriteDialog(3, 0x7C000, 0x7C000, out error);
    if (error is not null) { return; }

    // Title, Naming, Diary
    foreach (var line in lines.Where(l => !l.Block.HasValue))
    {
      var newBytes = line.Compose(out error);
      if (newBytes is null)
      {
        error = $@"0x{line.Address:X2} -- {(error is null ? "Unknown" : error)}";
        return;
      }
      for (int i = 0; i < newBytes.Length; i++)
      {
        newROM[line.Address + i] = newBytes[i];
      }
    }

    File.WriteAllBytes(path, newROM);
  }

  public static void SaveTranslationToDisk(List<Translation> translation)
  {
    var path = DoFileDialog(new SaveFileDialog(), "Save Translation", FrogFilter, LastPaths.Frog);
    if (path == null)
    {
      return;
    }

    SaveTranslationToDisk(path, translation);
  }

  public static void SaveTranslationToDisk(string path, List<Translation> translation)
  {
    var sb = new StringBuilder();

    foreach (var t in translation)
    {
      sb.AppendLine($"Address: 0x{t.Address.ToString("X2")}");
      if (t.Skip)
      {
        sb.AppendLine($"Skip: TRUE");
      }
      if (!string.IsNullOrWhiteSpace(t.Text))
      {
        sb.AppendLine($"Text: {t.Text}");
      }
      if (!string.IsNullOrWhiteSpace(t.Notes))
      {
        sb.AppendLine($"Note: {t.Notes}");
      }
    }

    File.WriteAllText(path, sb.ToString());
  }

  [STAThread]
  static void Main()
  {
    static byte[]? LoadGraphics(string fileName, int requiredLength)
    {
      var filePath = Path.Combine("Graphics", fileName);
      var bin = File.ReadAllBytes(filePath);
      if (bin.Length != requiredLength)
      {
        MessageBox.Show($@"{filePath} must be exactly {requiredLength} bytes.");
        return null;
      }

      return bin;
    }

    static List<GameBoyTile> MakeFontBitmaps(byte[] fontGraphics)
    {
      var palette = new[]
      {
            Color.FromArgb(255, 255, 255),
            Color.FromArgb(168, 168, 168),
            Color.FromArgb(96, 96, 96),
            Color.FromArgb(0, 0, 0),
      };

      var ret = new List<GameBoyTile>();

      for (var i = 0x0; i < Graphics_Font.Length; i += 0x10)
      {
        ret.Add(new GameBoyTile(Graphics_Font, i, palette, 4));
      }

      return ret;
    }

    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);

    var fontGraphics = LoadGraphics("Graphics_Font.gb", Constants.Blocks.FontGraphics.Length);
    var titleGraphics = LoadGraphics("Graphics_TitleScreen.gb", Constants.Blocks.TitleGraphics.Length);
    if (fontGraphics is null || titleGraphics is null)
    {
      return;
    }

    Graphics_Font = fontGraphics;
    Graphics_TitleScreen = titleGraphics;
    FontBitmaps = MakeFontBitmaps(fontGraphics);

    var lastROMPath = LastPaths.LoadROM.Get();
    var lastFrogPath = LastPaths.Frog.Get();

    if (File.Exists(lastROMPath) && File.Exists(lastFrogPath) && MessageBox.Show("Reload last open Japanese ROM and translation?", "Reload?", MessageBoxButtons.YesNo) == DialogResult.Yes)
    {
      var rom = LoadROMFromDisk(lastROMPath, out var loadROMError);
      if (rom is null)
      {
        if (loadROMError is not null)
        {
          MessageBox.Show(loadROMError);
        }
        return;
      }

      var lines = Parser.GetLines(rom);
      var asdf = string.Join("\r\n", lines.Select(x => $@"0x{x.Address:x2}").ToArray());

      LoadTranslationFromDisk(lastFrogPath, lines);

      Application.Run(new DialogEditor(rom, lines));
    }
    else
    {
      var rom = LoadROMFromDisk();
      if (rom is null)
      {
        return;
      }

      var lines = Parser.GetLines(rom);

      Application.Run(new DialogEditor(rom, lines));
    }
  }

  public static class LastPaths
  {
    public static StringSetting SaveBIN    = new StringSetting(Settings.Default, nameof(Settings.LastSaveBINPath));
    public static StringSetting LoadAltROM = new StringSetting(Settings.Default, nameof(Settings.LastLoadAltROM));

    public static StringSetting LoadROM = new StringSetting(Settings.Default, nameof(Settings.LastLoadROMPath));
    public static StringSetting SaveROM = new StringSetting(Settings.Default, nameof(Settings.LastSaveROMPath));
    public static StringSetting Frog    = new StringSetting(Settings.Default, nameof(Settings.LastFrogPath   ));
  }
}
