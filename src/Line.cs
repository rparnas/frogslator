using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frogslator
{
  [Serializable]
  class Line
  {
    // The original location of this line in the ROM.
    public int Location;

    // The first index that points to this line in the DialogAddressTable.
    public int DialogAddressTableLocation
    {
      get { return this.dialogAddressTableLocation; }
      set
      {
        dialogAddressTableLocation = value;

        if (DialogAddressTableLocation < 557)
        {
          BlockNumber = 0;
        }
        else if (DialogAddressTableLocation < 890)
        {
          BlockNumber = 1;
        }
        else if (DialogAddressTableLocation < 1622)
        {
          BlockNumber = 2;
        }
        else
        {
          BlockNumber = 3;
        }
      }
    }
    int dialogAddressTableLocation;

    // The block in which this line located.
    public int BlockNumber;

    // The original bytes that made up this line.
    public List<byte> Bytes;

    // Dialog of the line.
    public string Dialog;

    // The new dialog of the line.
    public string NewDialog;

    public string Notes;
    public string Notes1;
    public string Notes2;
    public string Notes3;
    public bool IgnoreLine;

    // First two bytes of the line.
    public byte HeaderByte1;
    public byte HeaderByte2;
    public List<byte> OtherHeaderBytes;

    // Bytes automatically appended to the end of the line.
    public List<byte> FooterBytes;

    // Special bytes that the user can choose where to place back into the line.
    public List<SpecialChar> UserSpecialChars;

    // The new bytes that will make up the line.
    public List<byte> NewBytes(State start, bool dialogBlock)
    {
      List<byte> newBytes = new List<byte>();

      // Add the line header bytes (For the Dialog Block Only).
      if (dialogBlock)
      {
        newBytes.Add(this.HeaderByte1);
        newBytes.Add(this.HeaderByte2);
        foreach (byte b in OtherHeaderBytes)
          newBytes.Add(b);
      }

      // If the user hasn't written dialog yet.
      if (this.NewDialog.Equals(""))
      {
        if (IgnoreLine)
        {
          return new List<byte>();
        }

        newBytes.Add(0x00);
        newBytes.Add(0x00);
        // Insert all of the user special characters back.
        foreach (SpecialChar usChar in this.UserSpecialChars)
        {
          if (!usChar.Ignore)
          {
            newBytes.Add(usChar.Value);
          }
        }
      }
      else
      {
        State state = start;
        string output = "";
        int usCharIndex = 0;

        // Make sure to select the next non-ignored character.
        while (usCharIndex < this.UserSpecialChars.Count && this.UserSpecialChars[usCharIndex].Ignore)
        {
          usCharIndex++;
        }

        // For every char in the new dialog.
        foreach (char c in this.NewDialog)
        {
          // If the user wants a user special character.
          if (c == '*' && usCharIndex < this.UserSpecialChars.Count)
          {
            // If it is a special character.
            newBytes.Add(this.UserSpecialChars[usCharIndex].Value);
            usCharIndex++;

            // Make sure to select the next non-ignored chracter.
            while (usCharIndex < this.UserSpecialChars.Count && this.UserSpecialChars[usCharIndex].Ignore)
            {
              usCharIndex++;
            }
          }
          else
          {
            // Get the proper output byte for the given character.
            state.Transition(c == '\n' ? "\\n" : c + "", out output, out state);

            byte b = byte.Parse(output.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            newBytes.Add(b);
          }
        }
      }

      // Append the footer bytes
      foreach (byte b in this.FooterBytes)
      {
        newBytes.Add(b);
      }

      // Append a termination byte to the end.
      if (dialogBlock)
      {
        newBytes.Add(0xFF);
      }

      return newBytes;
    }

    // Create a new line at the given original location.
    public Line(int loc)
    {
      Location = loc;
      DialogAddressTableLocation = -1;
      BlockNumber = -1;
      Bytes = new List<byte>();
      Dialog = "";
      NewDialog = "";
      Notes = "";
      HeaderByte1 = 0;
      HeaderByte2 = 0;
      OtherHeaderBytes = new List<byte>();
      FooterBytes = new List<byte>();
      UserSpecialChars = new List<SpecialChar>();
    }

    // Add the byte from the rom and the string to append to the parsed dialog.
    public void AddByte(byte b, string s)
    {
      Bytes.Add(b);
      Dialog += s.Equals("\\n") ? "\n" : s;
    }

    // Add a byte as a user special character.
    public void AddUserSpecialChar(byte b, string s)
    {
      Bytes.Add(b);
      UserSpecialChars.Add(new SpecialChar(b, s));
      Dialog += '*';
    }

    // For displaying this line in the list box.
    public override string ToString()
    {
      return "" + Location.ToString("x").ToUpper();
    }
  }
}
