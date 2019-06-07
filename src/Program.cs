using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

[assembly: AssemblyVersion("1.1.0.0")]
[assembly: AssemblyFileVersion("1.1.0.0")]

namespace Frog
{
  static class Program
  {
    public static List<GameBoyTile> FontBitmaps;
    public static byte[] Grahpics_TitleScreen;
    public static byte[] Graphics_Font;
    public static int MaxBlockSize = 0x4000;
    public static Color[] Palette;
    public static string ROMFilter => "GameBoy File(*.gb)|*.gb";
    public static string TranslationFilter => "Frog File (*.frog)|*.frog";

    public static string LastROMPath
    {
      get => Settings.Default.LastROMPath;
      set
      {
        Settings.Default.LastROMPath = value;
        Settings.Default.Save();
      }
    }

    public static string LastTranslationPath
    {
      get => Settings.Default.LastTranslationPath;
      set
      {
        Settings.Default.LastTranslationPath = value;
        Settings.Default.Save();
      }
    }

    static string DoFileDialog(FileDialog fd, string title, string filter, Func<string> getDefaultPath, Action<string> setDefaultPath)
    {
      var path = getDefaultPath();
      if (!string.IsNullOrWhiteSpace(path))
      {
        var dir = new FileInfo(path).Directory;
        if (dir.Exists)
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

      setDefaultPath(fd.FileName);

      return fd.FileName;
    }

    public static byte[] LoadROMFromDisk()
    {
      var path = DoFileDialog(new OpenFileDialog(), "Choose a valid Japanese Kaeru no Tame ni Kane Wa Naru ROM", ROMFilter, () => LastROMPath, p => LastROMPath = p);
      if (path == null)
      {
        return null;
      }

      var ret = LoadROMFromDisk(path, out string error);
      if (error != null)
      {
        MessageBox.Show(error);
        return null;
      }
      return ret;
    }

    public static byte[] LoadROMFromDisk(string path, out string error)
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
      var path = DoFileDialog(new OpenFileDialog(), "Load Translation", TranslationFilter, () => LastTranslationPath, p => LastTranslationPath = p);
      if (path == null)
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
        var t = ret.FirstOrDefault(_ => _.Address == line.Address) ?? new Translation(line.Address);
        line.Translation.Notes = t.Notes;
        line.Translation.Skip = t.Skip;
        line.Translation.Text = t.Text;
      }
    }

    public static void SaveROMToDisk(byte[] rom, List<Line> lines)
    {
      var path = DoFileDialog(new SaveFileDialog(), "Save ROM", ROMFilter, () => LastROMPath, p => LastROMPath = p);
      if (path == null)
      {
        return;
      }

      SaveROMToDisk(path, rom, lines, out string error);
      if (error != null)
      {
        MessageBox.Show("Could not save ROM because at least one line has an error:\r\n" + error);
      }
    }

    public static void SaveROMToDisk(string path, byte[] rom, List<Line> lines, out string error)
    {
      var newROM = rom.ToArray();

      void WriteDialog(int blockOffset, int newBlockOffset, int startDATIndex, int stopDATIndex, out string dialogError)
      {
        var romIndex = newBlockOffset;
        var lineIndex = 0;

        // Get to the first line of this block.
        while (lines[lineIndex].DialogAddressTableLocation < startDATIndex)
        {
          lineIndex++;
        }

        // For each line in this block.
        while (lineIndex < lines.Count && lines[lineIndex].DialogAddressTableLocation <= stopDATIndex)
        {
          var l = lines[lineIndex];
          var newAddress = romIndex;

          // Add this line to the Dialog Block
          var bytes = l.Compose(out string e);
          if (!string.IsNullOrWhiteSpace(e))
          {
            dialogError = "0x" + l.Address.ToString("X2") + " -- " + e;
            return;
          }
          foreach (var b in bytes)
          {
            if (romIndex < newROM.Length)
            {
              newROM[romIndex] = b;
            }
            romIndex++;
          }

          // Set references to this line in the DialogAddressTable
          for (int datIndex = l.DialogAddressTableLocation; datIndex < (lineIndex == lines.Count - 1 ? 2333 : lines[lineIndex + 1].DialogAddressTableLocation); datIndex++)
          {
            var offset = (newAddress - newBlockOffset).ToString("x").ToUpper();
            while (offset.Length < 4)
            {
              offset = "0" + offset;
            }
            newROM[(datIndex * 2) + 0x1CB2E] = byte.Parse(offset.Substring(2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            newROM[(datIndex * 2) + 0x1CB2E + 1] = byte.Parse(offset.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
          }
          lineIndex++;
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
      for (int i = 0x4D770; i < 0x4DD10; i++)
      {
        newROM[i] = Grahpics_TitleScreen[i - 0x4D770];
      }

      // Change the font graphics.
      for (int i = 0x50000; i < 0x52000; i++)
      {
        newROM[i] = Graphics_Font[i - 0x50000];
      }

      // Block 1
      WriteDialog(0x70000, 0x70000, 0, 556, out error);
      if (error != null) { return; }

      // Block 2
      WriteDialog(0x74000, 0x74000, 557, 889, out error);
      if (error != null) { return; }

      // Block 3
      WriteDialog(0x78000, 0x78000, 890, 1621, out error);
      if (error != null) { return; }

      // Block 4
      WriteDialog(0x7C000, 0x7C000, 1622, 2332, out error);
      if (error != null) { return; }

      // Title, Naming, Diary
      foreach (var line in lines.Where(l => l.Block == -1))
      {
        var newBytes = line.Compose(out error);
        if (error != null)
        {
          error = "0x" + line.Address.ToString("X2") + " -- " + error;
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
      var path = DoFileDialog(new SaveFileDialog(), "Save Translation", TranslationFilter, () => LastTranslationPath, p => LastTranslationPath = p);
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
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      var rom = (byte[])null;
      var lines = (List<Line>)null;

      if (File.Exists(LastROMPath) && File.Exists(LastTranslationPath) && MessageBox.Show("Reload last open Japanese ROM and translation?", "Reload?", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        rom = LoadROMFromDisk(LastROMPath, out string loadROMError);
        if (loadROMError != null)
        {
          MessageBox.Show(loadROMError);
          return;
        }

        lines = Parser.GetLines(rom);

        LoadTranslationFromDisk(LastTranslationPath, lines);
      }
      else
      {
        rom = LoadROMFromDisk();
        lines = Parser.GetLines(rom);
        if (rom == null)
        {
          return;
        }
      }

      // Parse the lines of the DialogBlock from the ROM image.
      Grahpics_TitleScreen = File.ReadAllBytes("Graphics_TitleScreen.gb");
      Graphics_Font = File.ReadAllBytes("Graphics_Font.gb");
      Palette = new Color[] 
      {
        Color.FromArgb(255, 255, 255),
        Color.FromArgb(168, 168, 168),
        Color.FromArgb(96, 96, 96),
        Color.FromArgb(0, 0, 0),
      };
      FontBitmaps = new List<GameBoyTile>();
      for (int i = 0x0; i < Graphics_Font.Length; i += 0x10)
      {
        FontBitmaps.Add(new GameBoyTile(Graphics_Font, i, Palette, 4));
      }

      // Show the dialog editing screen.
      Application.Run(new DialogEditor(rom, lines));
    }
  }
}
