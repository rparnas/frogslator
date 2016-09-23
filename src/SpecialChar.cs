using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frog
{
  [Serializable]
  public class SpecialChar
  {
    public static Dictionary<byte, string> JumboValueDictionary = new Dictionary<byte, string>
    {
      { 0x00, "H"       },
      { 0x01, "W"       },
      { 0x02, "(Blank)" },
      { 0x03, "(Blank)" },
      { 0x04, "Z"       },
      { 0x05, "S"       },
      { 0x06, "P"       },
      { 0x07, "G"       },
      { 0x08, "a"       },
      { 0x09, "h"       },
      { 0x0A, "t"       },
      { 0x0B, "o"       },
      { 0x0C, "y"       },
      { 0x0D, "e"       },
      { 0x0E, "(Blank)" },
      { 0x0F, "(Blank)" },
      { 0x10, "(Blank)" },
      { 0x11, "m"       },
      { 0x12, "p"       },
      { 0x13, "(Blank)" },
      { 0x14, "?"       },
      { 0x15, "!"       },
      { 0x16, "Unused"  },
      { 0x17, "Unused"  },
      { 0x18, "..."     },
      { 0x19, "A"       },
      { 0x1A, "(Blank)" },
      { 0x1B, "(Blank)" },
      { 0x1C, "(Blank)" },
      { 0x1D, "(Blank)" },
      { 0x1E, "(Blank)" },
      { 0x1F, "(Blank)" },
      { 0xFE, "(Space)" }
    };

    public static Dictionary<byte, string> JumboOriginalValueDictionary = new Dictionary<byte, string>
    {
      { 0x00, "タ"          },
      { 0x01, "ダ"          },
      { 0x02, "ゲ"          },
      { 0x03, "ッ"          },
      { 0x04, "!"           },
      { 0x05, "?"           },
      { 0x06, "な"          },
      { 0x07, "に"          },
      { 0x08, "ー"          },
      { 0x09, "っ"          },
      { 0x0A, "許"          },
      { 0x0B, "せ"          },
      { 0x0C, "ん"          },
      { 0x0D, "ス"          },
      { 0x0E, "ポ"          },
      { 0x0F, "ア"          },
      { 0x10, "～"          },
      { 0x11, "レ"          },
      { 0x12, "Z"           },
      { 0x13, ".."          },
      { 0x14, "ギ"          },
      { 0x15, "ャ"          },
      { 0x16, "ぐ"          },
      { 0x17, "わ"          },
      { 0x18, "同"          },
      { 0x19, "じ"          },
      { 0x1A, "(Blank)"     },
      { 0x1B, "(Blank)"     },
      { 0x1C, "ハ"          },
      { 0x1D, "(Blank)"     },
      { 0x1E, "(Blank)"     },
      { 0x1F, "ぁ"          },
      { 0xFD, "(End Jumbo)" },
      { 0xFE, "(Space)"     }
    };

    public byte OriginalValue;
    public byte Value;
    public string Text;
    public bool Ignore;

    public SpecialChar(byte b, string t)
    {
      OriginalValue = b;
      Value = b;
      Text = t;
      Ignore = false;
    }

    public override string ToString()
    {
      if (Ignore)
        return "(Disabled)";

      if (Text.Contains("Jumbo"))
        return ResolveJumboValue();

      if (OriginalValue != this.Value)
        return "+" + Text + " (Altered)";

      return Text;
    }

    string ResolveJumboValue()
    {
      if (Value == 0xF9)
        return "SFX";
      if (Value == 0x46)
        return "SFX - Roar";

      if (Value == 0xF7)
        return "Begin Jumbo";
      if (Value == 0xFD)
        return "End Jumbo";

      return "Jumbo - " +
             "(" + string.Format("{0:X}", Value) + ", " + JumboValueDictionary[Value] + ")" +
             "(Original - " + string.Format("{0:X}", OriginalValue) + ", " + JumboOriginalValueDictionary[OriginalValue] + ")";
    }
  }
}
