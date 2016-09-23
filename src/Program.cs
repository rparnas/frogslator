using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frog
{
  static class Program
  {
    // The original ROM image.
    public static byte[] ROM;

    #region Lines

    // The parsed lines of the DialogBlock.
    public static List<Line> Lines = new List<Line>();
    public static List<Line> Lines_Other = new List<Line>();
    public static List<Line> Lines_Diary = new List<Line>();

    #endregion

    #region Line Quick References

    // Quick References to some of the lines.
    public static Line Line0_Open1 { get { return Program.Lines_Other[0]; } }
    public static Line Line1_Open2 { get { return Program.Lines_Other[1]; } }
    public static Line Line2_Open3 { get { return Program.Lines_Other[2]; } }
    public static Line Line3_Open4 { get { return Program.Lines_Other[3]; } }
    public static Line Line4_Open5 { get { return Program.Lines_Other[4]; } }
    public static Line Line5_Start { get { return Program.Lines_Other[5]; } }
    public static Line Line6_Continue { get { return Program.Lines_Other[6]; } }
    public static Line Line7_Naming { get { return Program.Lines_Other[7]; } }

    #endregion

    // For keeping track of the amount of space left for each block.
    public static int[] BlockBlankLines = new int[4];
    public static int[] BlockSize = new int[4];
    public const int BlockMaxSize = 0x4000;

    // The directory of the executable.
    public static string ExecutableDirectory
    {
      get
      {
        return new FileInfo(Application.ExecutablePath).Directory.FullName;
      }
    }

    public static string ResourcesDirectory
    {
      get
      {
        return new DirectoryInfo(ExecutableDirectory + "..\\..\\..\\resources\\").FullName;
      }
    }

    // FSMs for writing new bytes back to the rom.
    public static State ReverseDialogBlock_Latin;
    public static State ReverseOpening_Latin;
    public static State ReverseNaming_Latin;

    // Graphics Patches
    public static byte[] Grahpics_TitleScreen;
    public static byte[] Graphics_Font;

    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      // Load the rom from the disk.
      Program.ROM = Program.ReadROM();

      // Return if no ROM was loaded.
      if (Program.ROM == null) { return; }

      // Parse the lines of the DialogBlock from the ROM image.
      Program.ReadReverseStatesAndGraphics();

      // Read in text data from the ROM.
      Program.ReadLinesFromROM();

      // Show the dialog editing screen.
      Application.Run(new DialogEditor());
    }

    #region ROM

    // Reads the rom into a byte array.
    public static byte[] ReadROM()
    {
      // Pick the file.
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Title = "Open a valid ROM of Kaeru no Tame ni Kane Wa Naru";
      openFileDialog.Filter = "Gameboy Rom(*.gb)|*.gb";

      // If the user canceled.
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return null;

      // Open a new filestream to the file.
      byte[] rom = File.ReadAllBytes(openFileDialog.FileName);

      // If the size of the file not correct (512 KB).
      if (rom.Length != 0x80000)
      {
        MessageBox.Show("The ROM must be 512 KB.");
        return null;
      }

      // Compute a checksum of the rom dialog block.
      int chksum = 0;
      for (int i = 0; i < rom.Length; i++)
      {
        chksum += rom[i];
      }

      // If the sum is not correct (This is the checksum of the japanese rom I used).
      if (chksum != 77074606)
      {
        MessageBox.Show("The Checksum of this ROM was not expected.  Make sure to load the original Japanese version of the game.");
        return null;
      }

      return rom;
    }

    // Saves a ROM image to the disk.
    public static void ExportROM()
    {
      // Pick the file.
      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Title = "Save a ROM image";
      sfd.Filter = "Gameboy Rom(*.gb)|*.gb";

      // If the user clicked OK.
      if (sfd.ShowDialog() == DialogResult.OK)
      {
        File.WriteAllBytes(sfd.FileName, Program.MakeROM());
      }
    }

    // Makes a new rom image that can either be used to make an IPS or simply written back to the disk.
    public static byte[] MakeROM()
    {
      byte[] newROM = new byte[0x80000];

      // Copy the entire old ROM into the new ROM.
      Program.ROM.CopyTo(newROM, 0);

      // Change the text table for the opening screen.
      for (byte i = 0; i < 71; i++)
      {
        int addr = 0xB62A + 2 * i;

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

      // Change the title graphic.
      for (int i = 0x4D770; i < 0x4DD10; i++)
      {
        newROM[i] = Program.Grahpics_TitleScreen[i - 0x4D770];
      }

      // Change the font graphic.
      for (int i = 0x50000; i < 0x52000; i++)
      {
        newROM[i] = Program.Graphics_Font[i - 0x50000];
      }

      // Block 1;
      Program.WriteDialog(newROM, 0x70000, 0x70000, 0, 556);

      // Block 2;
      Program.WriteDialog(newROM, 0x74000, 0x74000, 557, 889);

      // Block 3;
      Program.WriteDialog(newROM, 0x78000, 0x78000, 890, 1621);

      // Block 4;
      Program.WriteDialog(newROM, 0x7C000, 0x7C000, 1622, 2332);

      // The Opening Screen lines.
      for (int i = 0; i < 7; i++)
      {
        List<byte> newBytes = Program.Lines_Other[i].NewBytes(Program.ReverseOpening_Latin, false);
        for (int j = 0; j < newBytes.Count; j++)
        {
          newROM[Program.Lines_Other[i].Location + j] = newBytes[j];
        }
      }

      // Name Screen.
      for (int i = 7; i < 8; i++)
      {
        List<byte> newBytes = Program.Lines_Other[i].NewBytes(Program.ReverseNaming_Latin, false);
        for (int j = 0; j < newBytes.Count; j++)
        {
          newROM[Program.Lines_Other[i].Location + j] = newBytes[j];
        }
      }

      // Dialog screen.
      foreach (Line l in Program.Lines_Diary)
      {
        if (l.NewDialog == "")
          continue;

        List<byte> newBytes = l.NewBytes(Program.ReverseDialogBlock_Latin, false);
        for (int j = 0; j < newBytes.Count; j++)
        {
          // The latin dialog block uses no lines in the lower portion of the graphics.
          // Thus the first byte may always be zero.
          newROM[l.Location + j * 2] = 0x00;
          newROM[l.Location + j * 2 + 1] = newBytes[j];
        }
      }

      return newROM;
    }

    // Export a ROM image to the disk, using the new dialog.
    private static void WriteDialog(byte[] newROM, int blockOffset, int newBlockOffset, int startDATIndex, int stopDATIndex)
    {
      int romIndex = newBlockOffset;
      int lineIndex = 0;

      // Get to the first line of this block offset
      while (Program.Lines[lineIndex].DialogAddressTableLocation < startDATIndex)
      {
        lineIndex++;
      }

      while (lineIndex < Program.Lines.Count && Program.Lines[lineIndex].DialogAddressTableLocation <= stopDATIndex)
      {
        Line l = Program.Lines[lineIndex];

        int newLocation = romIndex;

        // Add this line to the Dialog Block
        foreach (byte b in l.NewBytes(Program.ReverseDialogBlock_Latin, true))
        {
          if (romIndex < newROM.Length)
          {
            newROM[romIndex] = b;
          }
          romIndex++;
        }

        // Set references to this line in the DialogAddressTable
        for (int datIndex = l.DialogAddressTableLocation;
            datIndex < (lineIndex == Program.Lines.Count - 1 ? 2333 : Program.Lines[lineIndex + 1].DialogAddressTableLocation); datIndex++)
        {
          string offset = (newLocation - newBlockOffset).ToString("x").ToUpper();
          while (offset.Length < 4)
          {
            offset = "0" + offset;
          }

          newROM[(datIndex * 2) + 0x1CB2E] = byte.Parse(offset.Substring(2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
          newROM[(datIndex * 2) + 0x1CB2E + 1] = byte.Parse(offset.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
        }
        lineIndex++;
      }
    }


    /* Export a ROM image to the disk, using the new dialog.
    private static void WriteDialog(byte[] newROM, int blockOffset, int startDATIndex, int stopDATIndex)
    {
        int romIndex = blockOffset;
        int lineIndex = 0;

        // Get to the first line of this block offset
        while (Program.Lines[lineIndex].DialogAddressTableLocation < startDATIndex)
        {
            lineIndex++;
        }

        while (lineIndex < Program.Lines.Count && Program.Lines[lineIndex].DialogAddressTableLocation <= stopDATIndex)
        {
            Line l = Program.Lines[lineIndex];

            // Set references to this line in the DialogAddressTable
            for (int datIndex = l.DialogAddressTableLocation;
                datIndex < (lineIndex == Program.Lines.Count - 1 ? 2332 : Program.Lines[lineIndex + 1].DialogAddressTableLocation); datIndex++)
            {
                string offset = (romIndex).ToString("x").ToUpper();
                while (offset.Length < 4)
                {
                    offset = "0" + offset;
                }

                newROM[(datIndex * 2) + 0x1CB2E] = byte.Parse(offset.Substring(2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                newROM[(datIndex * 2) + 0x1CB2E + 1] = byte.Parse(offset.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }

            // Add this line to the Dialog Block
            foreach (byte b in l.NewBytes(Program.ReverseDialogBlock_Latin, true))
            {
                if (romIndex < newROM.Length)
                {
                    newROM[romIndex] = b;
                }
                romIndex++;
            }

            lineIndex++;
        }
    }
    */
    #endregion

    #region Dialog Block

    // Loads in states so the user can write new dialog back into the dialog block.
    public static void ReadReverseStatesAndGraphics()
    {
      // Latin.
      State[] RDB_Latin = new State[1];
      Program.ReverseDialogBlock_Latin = new State(ResourcesDirectory + "States\\ReverseDialogBlock_Latin\\0.txt", RDB_Latin);
      RDB_Latin[0] = Program.ReverseDialogBlock_Latin;

      State[] RO_Latin = new State[1];
      Program.ReverseOpening_Latin = new State(ResourcesDirectory + "States\\ReverseOpening_Latin\\0.txt", RO_Latin);
      RO_Latin[0] = Program.ReverseOpening_Latin;

      State[] RN_Latin = new State[1];
      Program.ReverseNaming_Latin = new State(ResourcesDirectory + "States\\ReverseNaming_Latin\\0.txt", RN_Latin);
      RN_Latin[0] = Program.ReverseNaming_Latin;

      // Read in the Graphics BIN file.
      Grahpics_TitleScreen = File.ReadAllBytes(ResourcesDirectory + "Graphics_TitleScreen.gb");
      Graphics_Font = File.ReadAllBytes(ResourcesDirectory + "Graphics_Font.gb");
    }

    // Parses the dialog block from the ROM file.
    private static void ReadLinesFromROM()
    {
      // Load in the finite state machine for parsing the DialogBlock.
      State[] fsm = new State[14];
      for (int i = 0; i < 14; i++)
      {
        fsm[i] = new State(ResourcesDirectory + "States\\DialogBlock\\" + i + ".txt", fsm);
      }

      // The first line is found at 0x70000.
      Line currLine = new Line(0x70000);

      // Start on state 0;
      State currState = fsm[0];

      // For every byte of the dialog block (0x70000 to 0x7F6C5, everything past here is empty).
      for (int i = 0x70000; i < 0x7F6C5; i++)
      {
        // A string for storing the output of the fsm transition.
        string output = "";

        // Transition based on the input (current byte in the DialogBlock).
        currState.Transition(ROM[i], out output, out currState);

        // 0xFF represents the end of a line only if the current state is back to the default state.
        // Alternatively, a 0xFF byte can be ignored if it is just filler space (currLine is "").
        if (ROM[i] == 0xFF && (currState == fsm[0] || currLine.Dialog.Equals("")))
        {
          // If the line actually has content (as opposed to the possible blank space between lines).
          if (!currLine.Dialog.Equals(""))
          {
            Program.Lines.Add(currLine);

            // Resolve the first index in the DialogAddressTable that points to this line.
            int datIndex = Program.Lines.IndexOf(currLine);
            datIndex += (datIndex > 163 ? 1 : 0); // 163  - 164  are repeats.
            datIndex += (datIndex > 165 ? 11 : 0); // 165  - 176  are repeats.
            datIndex += (datIndex > 206 ? 2 : 0); // 206  - 208  are repeats.
            datIndex += (datIndex > 214 ? 10 : 0); // 214  - 224  are repeats.
            datIndex += (datIndex > 234 ? 2 : 0); // 234  - 236  are repeats.
            datIndex += (datIndex > 237 ? 1 : 0); // 237  - 238  are repeats.
            datIndex += (datIndex > 252 ? 2 : 0); // 252  - 254  are repeats.
            datIndex += (datIndex > 313 ? 199 : 0); // 313  - 512  are repeats.
            datIndex += (datIndex > 897 ? 127 : 0); // 897  - 1024 are repeats.
            datIndex += (datIndex > 1188 ? 92 : 0); // 1188 - 1280 are repeats.
            datIndex += (datIndex > 1372 ? 164 : 0); // 1372 - 1536 are repeats.
            datIndex += (datIndex > 1682 ? 110 : 0); // 1682 - 1792 are repeats.
            datIndex += (datIndex > 1959 ? 89 : 0); // 1959 - 2048 are repeats.
            datIndex += (datIndex > 2129 ? 175 : 0); // 2129 - 2304 are repeats.

            // Save the DialogAddressTableIndex.
            currLine.DialogAddressTableLocation = datIndex;
          }

          // Create a line starting at the next byte.
          currLine = new Line(i + 1);
        }
        else if (output.Equals("h[1]")) // First header byte. 
        {
          currLine.HeaderByte1 = ROM[i];
        }
        else if (output.Equals("h[2]")) // Second header byte.
        {
          currLine.HeaderByte2 = ROM[i];
        }
        else if (output.StartsWith("h[")) // Other header bytes.
        {
          // Currently, this is only used for FC bytes.
          // FC is follwed by a single byte and is important for changing
          // event variables.  If this is screwed up, it can make the game
          // uncompletable, so, as it is always found at the begining of a line,
          // it is treated as a header.
          currLine.OtherHeaderBytes.Add(ROM[i]);
        }
        else if (output.StartsWith("f[")) // Bytes to be instered at the end of the line, regardless.
        {
          currLine.FooterBytes.Add(ROM[i]);
        }
        else if (output.StartsWith("us[Jumbo")) // Jumbo Letters translation is currently hard coded.
        {
          currLine.AddUserSpecialChar(ROM[i], "Jumbo");
        }
        else if (output.StartsWith("us[") && output.EndsWith("]")) // Bytes to be inserted back unchanged in value.
        {
          currLine.AddUserSpecialChar(ROM[i], output.Substring(3, output.Length - 4));
        }
        else // Other bytes (Japanese text).
        {
          currLine.AddByte(ROM[i], output);
        }
      }

      Program.CalculateDialogBlockLengths();

      Program.SetupOtherLines();
    }

    // Creates lines suitable for the special text.
    private static void SetupOtherLines()
    {
      // Opening - 1 to 5
      for (int i = 0xB6B9; i < 0xB6B9 + (0x30 * 5); i += 0x30)
      {
        Program.Lines_Other.Add(new Line(i));
      }

      // Start
      Program.Lines_Other.Add(new Line(0xB7A9));

      // Continue
      Program.Lines_Other.Add(new Line(0xB7AE));

      // Name Screen
      Program.Lines_Other.Add(new Line(0x4F534));

      // Diary
      Program.Lines_Diary.Add(new Line(0xE210));
      Program.Lines_Diary.Add(new Line(0xE22E));
      Program.Lines_Diary.Add(new Line(0xE234));
      Program.Lines_Diary.Add(new Line(0xE242));
      Program.Lines_Diary.Add(new Line(0xE24E));
      Program.Lines_Diary.Add(new Line(0xE27A));
      Program.Lines_Diary.Add(new Line(0xE288));
      Program.Lines_Diary.Add(new Line(0xE2B0));
      Program.Lines_Diary.Add(new Line(0xE304));
      Program.Lines_Diary.Add(new Line(0xE33E));
      Program.Lines_Diary.Add(new Line(0xE34C));
      Program.Lines_Diary.Add(new Line(0xE374));
      Program.Lines_Diary.Add(new Line(0xE390));
      Program.Lines_Diary.Add(new Line(0xE39E));
      Program.Lines_Diary.Add(new Line(0xE3AE));
      Program.Lines_Diary.Add(new Line(0xE3BC));
      Program.Lines_Diary.Add(new Line(0xE3CA));
      Program.Lines_Diary.Add(new Line(0xE3E6));
      Program.Lines_Diary.Add(new Line(0xE402));
      Program.Lines_Diary.Add(new Line(0xE41E));
      Program.Lines_Diary.Add(new Line(0xE43A));
      Program.Lines_Diary.Add(new Line(0xE456));
      Program.Lines_Diary.Add(new Line(0xE478));
    }

    // Reads in an in-progress translation from the disk.
    public static void ReadLinesFromDisk()
    {
      var ofd = new OpenFileDialog();
      ofd.Title = "Load Translation from Disk";
      ofd.Filter = "For the Frog Translation(*.frog)|*.frog";

      // If the user didn't pick a file successfully.
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      // Open a new filestream to the file.
      var filestream = File.Open(ofd.FileName, FileMode.Open);
      var bf = new BinaryFormatter();

      var lines = (List<Line>)bf.Deserialize(filestream);
      var lines_other = (List<Line>)bf.Deserialize(filestream);
      var lines_diary = (List<Line>)bf.Deserialize(filestream);

      /*var weird = new List<Line>();
      var original = new HashSet<string>();
      foreach (var line in lines)
      {
        original.Add(line.ToString());
      }
      foreach (var line in Program.Lines)
      {
        if (!original.Contains(line.ToString()))
        {
          weird.Add(line);
        }
      }*/

      UpdateLines(Program.Lines, lines);
      UpdateLines(Program.Lines_Other, lines_other);
      UpdateLines(Program.Lines_Diary, lines_diary);

      // Close the filestream.
      filestream.Close();

      Program.CalculateDialogBlockLengths();
    }

    private static void UpdateLines(List<Line> parseLines, List<Line> loadLines)
    {
      for (int i = 0; i < parseLines.Count; i++)
      {
        Line ll = loadLines[i];
        Line pl = parseLines[i];

        pl.NewDialog = ll.NewDialog;

        if (pl.NewDialog.Contains("*"))
        {
          pl.UserSpecialChars = ll.UserSpecialChars;
        }

        pl.Notes = ll.Notes;
        pl.Notes1 = ll.Notes1;
        pl.Notes2 = ll.Notes2;
        pl.Notes3 = ll.Notes3;
      }
    }

    // Saves an in-progress translation to the disk.
    public static void SaveLinesToDisk()
    {
      // Pick the file.
      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Title = "Save Translation to Disk";
      sfd.Filter = "For the Frog Translation(*.frog)|*.frog";

      // If the user didn't pick a file successfully.
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      FileStream fileStream = File.Open(sfd.FileName, FileMode.Create);
      BinaryFormatter bf = new BinaryFormatter();
      bf.Serialize(fileStream, Program.Lines);
      bf.Serialize(fileStream, Program.Lines_Other);
      bf.Serialize(fileStream, Program.Lines_Diary);
      fileStream.Close();
    }

    // Calculate the remaining bytes for all four dialog blocks.
    public static void CalculateDialogBlockLengths()
    {
      Program.BlockSize = new int[4];
      Program.BlockBlankLines = new int[4];

      foreach (Line l in Program.Lines)
      {
        Program.BlockBlankLines[l.BlockNumber] += l.NewDialog.Equals("") ? 1 : 0;
        Program.BlockSize[l.BlockNumber] += l.NewBytes(Program.ReverseDialogBlock_Latin, true).Count;
      }
    }

    #endregion
  }
}
