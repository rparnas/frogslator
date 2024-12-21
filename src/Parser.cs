using System.Globalization;
using System.Text;

namespace Frogslator;

public static class Parser
{
  public static readonly Dictionary<byte?[], string> ControlCodes = new Dictionary<byte?[], string>
  {
    { [0xF1, null], "[Text Speed {0}]"        },
    { [0xF2      ], "[Animation]"             },
    { [0xF3      ], "[Kana]"                  },
    { [0xF4      ], "[Kanji]"                 },

    { [0xF5, 0x00], "[Choice Yes/No]"         },
    { [0xF5, 0x01], "[Choice Number]"         },
    { [0xF5, 0x02], "[Choice Item]"           },

    { [0xF6, 0x00], "[Icon Wooden Shield]"    },
    { [0xF6, 0x01], "[Icon Leather Shield]"   },
    { [0xF6, 0x02], "[Icon Iron Shield]"      },
    { [0xF6, 0x03], "[Icon Mirror Shield]"    },
    { [0xF6, 0x04], "[Icon Money]"            },
    { [0xF6, 0x05], "[Icon Bracelets]"        },
    { [0xF6, 0x06], "[Icon Glove]"            },
    { [0xF6, 0x07], "[Icon Frog]"             },
    { [0xF6, 0x08], "[Icon Scroll]"           },
    { [0xF6, 0x09], "[Icon Book]"             },
    { [0xF6, 0x0A], "[Icon Controller]"       },
    { [0xF6, 0x0B], "[Icon Flute]"            },
    { [0xF6, 0x0C], "[Icon Frog Bottle]"      },
    { [0xF6, 0x0D], "[Icon Human Bottle]"     },
    { [0xF6, 0x0E], "[Icon Heart Bottle]"     },
    { [0xF6, 0x0F], "[Icon Big Heart Bottle]" },
    { [0xF6, 0x11], "[Icon Fruit]"            },
    { [0xF6, 0x12], "[Icon Egg]"              },
    { [0xF6, 0x13], "[Icon Saw]"              },
    { [0xF6, 0x14], "[Icon Axe]"              },
    { [0xF6, 0x15], "[Icon Wasabi]"           },
    { [0xF6, 0x16], "[Icon Door]"             },
    { [0xF6, 0x17], "[Icon Tablet]"           },
    { [0xF6, 0x19], "[Icon Bronze Sword]"     },
    { [0xF6, 0x1A], "[Icon Silver Sword]"     },
    { [0xF6, 0x1B], "[Icon Golden Sword]"     },
    { [0xF6, 0x1C], "[Icon Heart]"            },
    { [0xF6, 0x1D], "[Icon Star]"             },
    { [0xF6, 0x1E], "[Icon Moon]"             },
    { [0xF6, 0x24], "[Icon Heart Key]"        },
    { [0xF6, 0x25], "[Icon Spade Key]"        },
    { [0xF6, 0x26], "[Icon Diamond Key]"      },
    { [0xF6, 0x27], "[Icon Club Key]"         },

    { [0xF7      ], "[Jumbo]"                 },

    { [0xF8, 0x01], "[BGM Fade]"              },
    { [0xF8, 0x06], "[BGM Defeat]"            },
    { [0xF8, 0x08], "[BGM Panic+Intro]"       },
    { [0xF8, 0x0C], "[BGM Furing]"            },
    { [0xF8, 0x0E], "[BGM A La Mode]"         },
    { [0xF8, 0x11], "[BGM Seamizu]"           },
    { [0xF8, 0x13], "[BGM Underground]"       },
    { [0xF8, 0x1A], "[BGM Assault]"           },
    { [0xF8, 0x1D], "[BGM Reunion]"           },
    { [0xF8, 0x1E], "[BGM Last Duel]"         },
    { [0xF8, 0x21], "[BGM Flute]"             },
    { [0xF8, 0xFA], "[BGM Speech Off]"        },
    { [0xF8, 0xFF], "[BGM Off]"               },

    { [0xF9, 0x23], "[SFX Error]"             },
    { [0xF9, 0x24], "[SFX Pickup]"            },
    { [0xF9, 0x29], "[SFX Jump]"              },
    { [0xF9, 0x2A], "[SFX Suprise]"           },
    { [0xF9, 0x2E], "[SFX Upgrade]"           },
    { [0xF9, 0x2F], "[SFX Mystery]"           },
    { [0xF9, 0x36], "[SFX Flute]"             },
    { [0xF9, 0x37], "[SFX Victory]"           },
    { [0xF9, 0x46], "[SFX Roar]"              },
    { [0xF9, 0x65], "[SFX Punch]"             },
    { [0xF9, 0x66], "[SFX Kick]"              },
    { [0xF9, 0x67], "[SFX Stab]"              },
    { [0xF9, 0x6A], "[SFX Snore]"             },
    { [0xF9, 0x72], "[SFX Off]"               },

    { [0xFA, 0x01], "[Text Space For Icon]"   },
    { [0xFA, 0x02], "[Text Item Get]"         },
    { [0xFA, 0x04], "[Text Yes/No]"           },
    { [0xFA, 0x05], "[Text News]"             },
    { [0xFA, 0x80], "[Text Name]"             },
    { [0xFA, 0x81], "[Text Nuts]"             },
    { [0xFA, 0x82], "[Text Spent]"            },

    { [0xFC, null], "[Flag {0}]"              },
    { [0xFD      ], "\n"                      },
    { [0xFE      ], " "                       },
  };

  public static readonly CharacterMap LatinDialog = new CharacterMap(
  [
    /*          0    1    2    3    4    5    6    7    8    9    A    B    C    D    E    F */
    /* 0x0_ */ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
    /* 0x1_ */ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
    /* 0x2_ */ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
    /* 0x3_ */ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '…', '*',
    /* 0x4_ */ '~', '!', '?', '-', '.', ',', '\'','"', '▲', '▼', '◄', '►', ':', '‘', '“', ' ',
    /* 0x5_ */ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
    /* 0x6_ */ 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'ß', 'Ä', 'Ö', 'Ü', 'a', 'b',
    /* 0x7_ */ 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
    /* 0x8_ */ 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'à', 'â', 'ä', 'è', 'é', 'ê', 'ù', 'û',
    /* 0x9_ */ 'ü', 'ô', 'ö', 'ç', 'î', ' ', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
    /* 0xA_ */ ' ', ' ', ' ', ' ', ' ', ' ', '♥', '&', ' ', ' ', '(', ')', ' ', ' ', ' ', '_',
  ]);

  public static readonly CharacterMap LatinNameScreen = new CharacterMap(
  [
    /*          0    1    2    3    4    5    6    7    8    9    A    B    C    D    E    F */
    /* 0x0_ */ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
    /* 0x1_ */ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
    /* 0x2_ */ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
    /* 0x3_ */ 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'ß', 'Ä', 'Ö', 'Ü', 'a', 'b',
    /* 0x4_ */ 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
    /* 0x5_ */ 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'à', 'â', 'ä', 'è', 'é', 'ê', 'ù', 'û',
    /* 0x6_ */ 'ü', 'ô', 'ö', 'ç', 'î', '♥', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 
    /* 0x7_ */ '~', '!', '?', '-', '.', '‥', '♥', '&', ',', '.', '(', ')',
  ]);

  public static readonly CharacterMap LatinTitleScreen = new CharacterMap(
  [
    /*          0    1    2    3    4    5    6    7    8    9    A    B    C    D    E    F */
    /* 0x0_ */ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
    /* 0x1_ */ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
    /* 0x2_ */ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
    /* 0x3_ */ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
    /* 0x4_ */ 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'ß', 'Ä', 'Ö', 'Ü', 'a', 'b',
    /* 0x5_ */ 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
    /* 0x6_ */ 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'à', 'â', 'ä', 'è', 'é', 'ê', 'ù', 'û',
    /* 0x7_ */ 'ü', 'ô', 'ö', 'ç', 'î', '.', ','
  ]);

  public static readonly CharacterMap LatinJumbo = new CharacterMap(
  [
    /*          0    1    2    3    4    5    6    7    8    9    A    B    C    D    E    F */
    /* 0x0_ */ 'H', 'W', ' ', ' ', 'Z', 'S', 'P', 'G', 'a', 'h', 't', 'o', 'y', 'e', ' ', ' ',
    /* 0x1_ */ ' ', 'm', 'p', ' ', '?', '!', ' ', ' ', '…', 'A', ' ', ' ', ' ', ' ', ' ', ' ',
  ]);

  public static readonly CharacterMap Japanese = new CharacterMap(
  [      
    /*             00    10    20    30   40    50    60    70    80   90    A0   B0    C0   D0    E0    F0 */
    /* 0x500__ */ 'あ', 'い', 'う', 'え', 'お', 'か', 'き', 'く', 'け', 'こ', 'さ', 'し', 'す', 'せ', 'そ', 'た',
    /* 0x501__ */ 'ち', 'つ', 'て', 'と', 'な', 'に', 'ぬ', 'ね', 'の', 'は', 'ひ', 'ふ', 'へ', 'ほ', 'ま', 'み',
    /* 0x502__ */ 'む', 'め', 'も', 'や', 'ゆ', 'よ', 'ら', 'り', 'る', 'れ', 'ろ', 'わ', 'を', 'ん', 'ぁ', 'ぃ',
    /* 0x503__ */ 'ぅ', 'ぇ', 'ぉ', 'ゃ', 'ゅ', 'ょ', 'っ', 'が', 'ぎ', 'ぐ', 'げ', 'ご', 'ざ', 'じ', 'ず', 'ぜ',
    /* 0x504__ */ 'ぞ', 'だ', 'ぢ', 'づ', 'で', 'ど', 'ば', 'び', 'ぶ', 'べ', 'ぼ', 'ぱ', 'ぴ', 'ぷ', 'ぺ', 'ぽ', 
    /* 0x505__ */ 'ア', 'イ', 'ウ', 'エ', 'オ', 'カ', 'キ', 'ク', 'ケ', 'コ', 'サ', 'シ', 'ス', 'セ', 'ソ', 'タ', 
    /* 0x506__ */ 'チ', 'ツ', 'テ', 'ト', 'ナ', 'ニ', 'ヌ', 'ネ', 'ノ', 'ハ', 'ヒ', 'フ', 'ヘ', 'ホ', 'マ', 'ミ', 
    /* 0x507__ */ 'ム', 'メ', 'モ', 'ヤ', 'ユ', 'ヨ', 'ラ', 'リ', 'ル', 'レ', 'ロ', 'ワ', 'ヲ', 'ン', 'ァ', 'ィ', 
    /* 0x508__ */ 'ゥ', 'ェ', 'ォ', 'ャ', 'ュ', 'ョ', 'ッ', 'ガ', 'ギ', 'グ', 'ゲ', 'ゴ', 'ザ', 'ジ', 'ズ', 'ゼ', 
    /* 0x509__ */ 'ゾ', 'ダ', 'ヂ', 'ヅ', 'デ', 'ド', 'バ', 'ビ', 'ブ', 'ベ', 'ボ', 'パ', 'ピ', 'プ', 'ペ', 'ポ',
    /* 0x50A__ */ '〜', '！', '？', 'ー', '．', '‥',  '❤', '＆', '、', '。', '（', '）', '◯', '✕', '△', '＿',
    /* 0x50B__ */ 'Ａ', 'Ｂ', 'Ｃ', 'Ｄ', 'Ｅ', 'Ｆ', 'Ｇ', 'Ｈ', 'Ｉ', 'Ｊ', 'Ｋ', 'Ｌ', 'Ｍ', 'Ｎ', 'Ｏ', 'Ｐ',
    /* 0x50C__ */ 'Ｑ', 'Ｒ', 'Ｓ', 'Ｔ', 'Ｕ', 'Ｖ', 'Ｗ', 'Ｘ', 'Ｙ', 'Ｚ', 'ー', 'ー', 'ー', '▽', '「', '」',
    /* 0x50D__ */ '０', '１', '２', '３', '４', '５', '６', '７', '８', '９', '同', '代', '安', '京', '氷', '河',
    /* 0x50E__ */ '王', '子', '巨', '人', '々', '山', '時', '心', '大', '岩', '日', '回', '火', '水', '木', '年',
    /* 0x50F__ */ '上', '下', '平', '和', '左', '右', '東', '西', '南', '北', '国', '女', '姫', '金', '小', '中',
    /* 0x510__ */ '行', '百', '十', '千', '万', '変', '身', '申', '二', '町', '所', '今', '力', '村', '店', '用',
    /* 0x511__ */ '手', '先', '目', '乱', '私', '友', '井', '戸', '元', '必', '間', '奴', '？', '本', '自', '分',
    /* 0x512__ */ '気', '失', '死', '入', '匹', '穴', '？', '？', '兵', '士', '少', '以', '出', '我', '恐', '近',
    /* 0x513__ */ '当', '湖', '内', '外', '海', '全', '主', '方', '向', '字', '？', '記', '世', '宝', '法', '口',
  ]);

  public static readonly CharacterMap JapaneseJumbo = new CharacterMap(
  [
    /* 0x518xx */ 'タ', 'ダ', 'ゲ', 'ッ', '！', '？', 'な', 'に', 'ー', 'っ', '許', 'せ', 'ん', 'ス', 'ポ', 'ア',
    /* 0x51Cxx */ '～', 'レ', 'Ｚ', '‥',  'ギ', 'ャ', 'ぐ', 'わ', '同', 'じ', '？', '？', 'ハ', '？', '？', 'ぁ'
  ]);

  public static List<Line> GetLines(byte[] rom)
  {
    return new List<Line>()
      .Concat(GetDialogBlockLines(rom))
      .Concat(GetDiaryLines(rom))
      .Concat(GetNameScreenLines(rom))
      .Concat(GetTitleScreenLines(rom))
      .OrderBy(line => line.Address)
      .ToList();
  }

  static List<Line> GetDialogBlockLines(byte[] rom)
  {
    byte[]? Compose(Line line, Translation translation, out string? error)
    {
      if (translation.Skip)
      {
        error = null;
        return line.Header
          .Concat(new byte[] { 0x00, 0x00 })
          .Concat(line.Footer)
          .ToArray();
      }
      if (translation.Text == string.Empty)
      {
        error = null;
        return line.AllBytes;
      }

      var ret = new List<byte>();
      var mode = CompositionModes.Latin;

      ret.AddRange(line.Header);

      for (var i = 0; i < translation.Text.Length; i++)
      {
        var c = translation.Text[i];
        if (c == '[')
        {
          var closeIndex = translation.Text.IndexOf(']', i);
          if (closeIndex < 0)
          {
            error = "unmatched square bracket '['";
            return null;
          }

          // Shift character sets if appropriate.
          var controlCode = translation.Text.Substring(i, closeIndex - i + 1);
          if (controlCode == "[Latin]")
          {
            mode = CompositionModes.Latin;
          }
          if (controlCode == "[Jumbo]")
          {
            mode = CompositionModes.Jumbo;
          }

          // Express the control code.
          var match =
            ControlCodes.Any(pair => pair.Value == controlCode) ? 
            ControlCodes.Single(pair => pair.Value == controlCode).Key : 
            null;
          if (controlCode.StartsWith("[Text Speed"))
          {
            var byte2 = byte.Parse(controlCode.Substring("[Text Speed ".Length, controlCode.Length - "[Text Speed ".Length - 1), NumberStyles.AllowHexSpecifier);
            ret.AddRange([0xF1, byte2]);
          }
          else if (controlCode.StartsWith("[Flag"))
          {
            var byte2 = byte.Parse(controlCode.Substring("[Flag ".Length, controlCode.Length - "[Flag ".Length - 1), NumberStyles.AllowHexSpecifier);
            ret.AddRange([0xFC, byte2]);
          }
          else if (match is null)
          {
            error = $"unknown control code '{controlCode}'";
            return null;
          }
          else
          {
            if (match.Any(b => !b.HasValue))
            {
              error = $"control code '{controlCode}' has a parameter byte, but no custom processor is defined";
              return null;
            }

            ret.AddRange(match.Select(b => b!.Value).ToArray());
          }

          i = closeIndex;
        }
        else if (c == '\n')
        {
          mode = CompositionModes.Latin;
          ret.Add(0xFD);
        }
        else if (c == ' ')
        {
          ret.Add(0xFE);
        }
        else if (mode == CompositionModes.Latin)
        {
          if (!LatinDialog.Contains(c))
          {
            error = CharacterMapError(nameof(LatinDialog), c);
            return null;
          }
          ret.Add(LatinDialog.GetByte(c));
        }
        else
        {
          if (!LatinJumbo.Contains(c))
          {
            error = CharacterMapError(nameof(LatinJumbo), c);
            return null;
          }
          ret.Add(LatinJumbo.GetByte(c));
        }
      }

      ret.AddRange(line.Footer);

      error = null;
      return ret.ToArray();
    }

    string Parse(byte[] body)
    {
      var ret = new StringBuilder();
      var mode = ParseModes.Kana;

      for (int i = 0; i < body.Length; i++)
      {
        var b = body[i];

        if (b >= 0xF0)
        {
          // A control code sequence is one or two bytes. The byte must match. If there are two bytes the second byte must match unless it is null, indicating any byte works.
          var match = ControlCodes.Keys.Where(key => (key.Length == 1 && key[0] == b) ||
                                                     (key.Length == 2 && key[0] == b && i < body.Length - 1 && (key[1] == null || key[1] == body[i + 1]))).ToList();
          if (match.Count > 1)
          {
            throw new NotImplementedException("Multiple matches was not expected");
          }

          var key = match.Single();
          var value = ControlCodes[key];

          // Fill in the blank for control codes where the second byte can be anything.
          if (key.Length > 1 && key[1] == null)
          {
            value = string.Format(value, body[i + 1].ToString("X2"));
          }

          // Shift
          if (value == "[Kana]" || (value == "\n" && mode == ParseModes.Jumbo))
          {
            mode = ParseModes.Kana;
          }
          else if (value == "[Kanji]")
          {
            mode = ParseModes.Kanji;
          }
          else if (value == "[Jumbo]")
          {
            mode = ParseModes.Jumbo;
          }

          if (value == "[Kanji]" || value == "[Kana]") { }
          else
          {
            ret.Append($"{value}");
          }
          i += match.Single().Length - 1;
        }
        else
        {
          var c = mode switch
          {
            ParseModes.Kana  => Japanese.GetChar(b),
            ParseModes.Kanji => Japanese.GetChar((byte)(b + 0xDA)),
            ParseModes.Jumbo => JapaneseJumbo.GetChar(b),
            _ => throw new NotImplementedException(),
          };

          ret.Append(c);
        }
      }

      return ret.ToString();
    }

    static Dictionary<int, int> ReadDAT(byte[] rom)
    {
      var ret = new Dictionary<int, int>();

      var block = Constants.Blocks.DialogAddressTable;
      var datIndex = 0;
      for (var i = block.Start; i < block.Stop; i += 2)
      {
        var blockOffset = 
          datIndex <  557 ? Constants.Blocks.Dialog0.Start :
          datIndex <  890 ? Constants.Blocks.Dialog1.Start :
          datIndex < 1622 ? Constants.Blocks.Dialog2.Start : 
                            Constants.Blocks.Dialog3.Start;

        var lowByte = rom[i];
        var highByte = rom[i + 1];
        var dialogAddress = ((highByte << 8) | lowByte) + blockOffset;

        ret.Add(datIndex, dialogAddress);

        datIndex++;
      }

      return ret;
    }

    static string? ResolveComment(int address)
    {
      if (Constants.Comments.TryGetValue(address, out var comment))
      {
        return string.IsNullOrWhiteSpace(comment) ? null : comment;
      }

      return "Unknown";
    }

    var dat = ReadDAT(rom);

    var lines = new List<Line>();

    var index = Constants.Blocks.Dialog.Start;
    while (index < Constants.Blocks.Dialog.Stop)
    {
      if (rom[index] == 0xFF)
      {
        index++;
        continue;
      }

      var address = index;
      var header = new List<byte>();
      var body = new List<byte>();
      var footer = new List<byte>();

      // Take two standard header bytes.
      header.AddRange([rom[index], rom[index + 1]]);
      index += 2;

      // Process the body and footer of the line.
      while (index < Constants.Blocks.Dialog.Stop)
      {
        if (new[] { 0xF1, 0xF5, 0xF6, 0xF8, 0xF9, 0xFA }.Contains(rom[index]))
        {
          // Take a control code and its single byte argument verbatim.
          body.AddRange([rom[index], rom[index + 1]]);
          index += 2;
        }
        else if (rom[index] == 0xFB)
        {
          // Take three four bytes (indicating a jump to another line).
          footer.AddRange([rom[index], rom[index + 1], rom[index + 2], rom[index + 3]]);
          index += 4;
          break;
        }
        else if (rom[index] == 0xFC)
        {
          // Take the flag control code, so the translator doesn't have to worry about it.
          header.AddRange([rom[index], rom[index + 1]]);
          index += 2;
        }
        else if (rom[index] == 0xFF)
        {
          // Take the line terminator control code.
          footer.Add(rom[index]);
          index++;
          break;
        }
        else
        {
          // Take one body byte.
          body.Add(rom[index]);
          index++;
        }
      }
      if (index == Constants.Blocks.Dialog.Stop)
      {
        throw new NotImplementedException("Can't find body and footer of line.");
      }

      var datLocations = dat
        .Where(pair => pair.Value == address)
        .Select(pair => pair.Key)
        .ToArray();

      var height = 2;
      var comment = ResolveComment(address);
      var width = address >= 0x70F9B && address <= 0x7217A ? 16 : 18;
      var category = LineCategories.Dialog;
      lines.Add(new Line(category, comment, address, datLocations, height, width, header.ToArray(), body.ToArray(), footer.ToArray(), Compose, Parse));
    }

    return lines;
  }

  static List<Line> GetDiaryLines(byte[] rom)
  {
    byte[]? Compose(Line line, Translation translation, out string? error)
    {
      var fixedLength = line.Text.Length;
      if (translation.Text.Length > fixedLength)
      {
        error = $@"must be {fixedLength*2} bytes or less"; // processing will double the number of bytes
        return null;
      }

      var bytes = new List<byte>();
      for (int i = 0; i < fixedLength; i++)
      {
        var c = i >= translation.Text.Length ? ' ' : translation.Text[i];
        if (c == ' ')
        {
          bytes.Add(0xFE);
        }
        else
        {
          if (!LatinDialog.Contains(c))
          {
            error = CharacterMapError(nameof(LatinDialog), c);
            return null;
          }
          bytes.Add(LatinDialog.GetByte(c));
        }
      }

      var processedBytes = new List<byte>();
      for (int i = 0; i < bytes.Count; i++)
      {
        processedBytes.Add(0x00);
        processedBytes.Add(bytes[i]);
      }

      error = null;
      return processedBytes.ToArray();
    }

    return new List<Line>
    {
      new Line(LineCategories.Diary, "Load (Top)",            0xE208, [], 1, 14, [], [], [], Compose, bytes => "    日記ちょう     "),
                                                 
      new Line(LineCategories.Diary, "In-Game (Top 1)",       0xE22E, [], 1,  3, [], [], [], Compose, bytes => "王子 "),
      new Line(LineCategories.Diary, "In-Game (Top 2)",       0xE234, [], 1,  6, [], [], [], Compose, bytes => "日記ちょう "),
                                            
      new Line(LineCategories.Diary, "Load (Left 1)",         0xE240, [], 1,  7, [], [], [], Compose, bytes => " どの日記で "),
      new Line(LineCategories.Diary, "Load (Left 2)",         0xE24E, [], 1,  7, [], [], [], Compose, bytes => "はじめますか？ "),
      new Line(LineCategories.Diary, "Load (Left 3)",         0xE25C, [], 1,  7, [], [], [], Compose, bytes => "       "),
      new Line(LineCategories.Diary, "Load (Left 4)",         0xE26A, [], 1,  7, [], [], [], Compose, bytes => "       "),
      
      new Line(LineCategories.Diary, "Erase (Left 1)",        0xE278, [], 1,  7, [], [], [], Compose, bytes => " どの日記で "),
      new Line(LineCategories.Diary, "Erase (Left 2)",        0xE286, [], 1,  7, [], [], [], Compose, bytes => "けしますか？ "),
      new Line(LineCategories.Diary, "Erase (Left 3)",        0xE294, [], 1,  7, [], [], [], Compose, bytes => "       "),
      new Line(LineCategories.Diary, "Erase (Left 4)",        0xE2A2, [], 1,  7, [], [], [], Compose, bytes => "       "),

      new Line(LineCategories.Diary, "In-Game (Left 1)",      0xE2B0, [], 1,  7, [], [], [], Compose, bytes => "どうしますか？"),
      new Line(LineCategories.Diary, "In-Game (Left 2)",      0xE2BE, [], 1,  7, [], [], [], Compose, bytes => "       "),
      new Line(LineCategories.Diary, "In-Game (Left 3)",      0xE2CC, [], 1,  7, [], [], [], Compose, bytes => "       "),
      new Line(LineCategories.Diary, "In-Game (Left 4)",      0xE2DA, [], 1,  7, [], [], [], Compose, bytes => "       "),

      new Line(LineCategories.Diary, "Read (Left 1)",         0xE304, [], 1,  7, [], [], [], Compose, bytes => "どのぺーじから"),
      new Line(LineCategories.Diary, "Read (Left 2)",         0xE312, [], 1,  7, [], [], [], Compose, bytes => "よみますか？ "),
      new Line(LineCategories.Diary, "Read (Left 3)",         0xE320, [], 1,  7, [], [], [], Compose, bytes => "       "),
      new Line(LineCategories.Diary, "Read (Left 4)",         0xE32E, [], 1,  7, [], [], [], Compose, bytes => "       "),

      new Line(LineCategories.Diary, "Write (Left 1)",        0xE33C, [], 1,  7, [], [], [], Compose, bytes => " どの日記に "),
      new Line(LineCategories.Diary, "Write (Left 2)",        0xE34A, [], 1,  7, [], [], [], Compose, bytes => "きろくする？ "),
      new Line(LineCategories.Diary, "Write (Left 3)",        0xE358, [], 1,  7, [], [], [], Compose, bytes => "       "),
      new Line(LineCategories.Diary, "Write (Left 4)",        0xE366, [], 1,  7, [], [], [], Compose, bytes => "       "),
                                                                              
      new Line(LineCategories.Diary, "Keep Playing (Left 1)", 0xE374, [], 1,  7, [], [], [], Compose, bytes => "きろくしました"),
      new Line(LineCategories.Diary, "Keep Playing (Left 2)", 0xE382, [], 1,  7, [], [], [], Compose, bytes => "       "),
      new Line(LineCategories.Diary, "Keep Playing (Left 3)", 0xE390, [], 1,  7, [], [], [], Compose, bytes => "たびを    "),
      new Line(LineCategories.Diary, "Keep Playing (Left 4)", 0xE39E, [], 1,  7, [], [], [], Compose, bytes => "つづけますか？"),
                                                                              
      new Line(LineCategories.Diary, "Load (Right)",          0xE3AE, [], 1,  5, [], [], [], Compose, bytes => "日記けす "),
                                                                              
      new Line(LineCategories.Diary, "In-Game (Right)",       0xE3BC, [], 1,  5, [], [], [], Compose, bytes => "もどる  "),
      new Line(LineCategories.Diary, "In-Game (Right)",       0xE3CA, [], 1,  5, [], [], [], Compose, bytes => "日記つける"),
      new Line(LineCategories.Diary, "In-Game (Right)",       0xE3E6, [], 1,  5, [], [], [], Compose, bytes => "日記たる "),
                                                                              
      new Line(LineCategories.Diary, "Keep Playing (Right)",  0xE402, [], 1,  5, [], [], [], Compose, bytes => "YES  "),
      new Line(LineCategories.Diary, "Keep Playing (Right)",  0xE41E, [], 1,  5, [], [], [], Compose, bytes => "NO   "),
                                                                              
      new Line(LineCategories.Diary, "Write (Right)",         0xE43A, [], 1,  6, [], [], [], Compose, bytes => "____王子"),
      new Line(LineCategories.Diary, "Write (Right)",         0xE456, [], 1,  6, [], [], [], Compose, bytes => "____王子"),
    };
  }

  static List<Line> GetNameScreenLines(byte[] rom)
  {
    byte[]? Compose(Line line, Translation translation, out string? error)
    {
      var fixedLength = line.AllBytes.Length;
      if (translation.Text.Length > fixedLength)
      {
        error = $@"must be {fixedLength} bytes or less";
        return null;
      }

      var bytes = new List<byte>();

      for (int i = 0; i < fixedLength; i++)
      {
        var c = i >= translation.Text.Length ? ' ' : translation.Text[i];
        if (c == ' ')
        {
          bytes.Add(0xDF);
        }
        else
        {
          if (!LatinNameScreen.Contains(c))
          {
            error = CharacterMapError(nameof(LatinNameScreen), c);
            return null;
          }
          bytes.Add(LatinNameScreen.GetByte(c));
        }
      }

      error = null;
      return bytes.ToArray();
    }

    var map = new byte[]
    {
      0x0, 0x14, 0xF, 0x18, 0x14, 0x1E, 0x3, 0x2C, 0x5, 0x6, 0x9, 0x2D, 0x44, 0xF1, 0xA, 0x1,
    };

    string Parse(byte[] bytes)
    {
      var ret = new StringBuilder();

      for (int i = 0; i < bytes.Length; i++)
      {
        var b = bytes[i];
        if (b == 0xDF)
        {
          ret.Append(' ');
        }
        else
        {
          var index = b;
          ret.Append(Japanese.GetChar(map[index]));
        }
      }

      return ret.ToString();
    }

    return new List<Line>
    {
      new Line(LineCategories.Naming, null, 0x4F535, [], 1, 0x12, [], rom.Skip(0x4F535).Take(0x12).ToArray(), [], Compose, Parse)
    };
  }

  static List<Line> GetTitleScreenLines(byte[] rom)
  {
    byte[]? Compose(Line line, Translation translation, out string? error)
    {
      var fixedLength = line.AllBytes.Length;
      if (translation.Text.Length > fixedLength)
      {
        error = $@"must be {fixedLength} bytes or less";
        return null;
      }

      var bytes = new List<byte>();
      for (int i = 0; i < fixedLength; i++)
      {
        var c = i >= translation.Text.Length ? ' ' : translation.Text[i];
        if (c == ' ')
        {
          bytes.Add(0xBF);
        }
        else
        {
          if (!LatinTitleScreen.Contains(c))
          {
            error = CharacterMapError(nameof(LatinTitleScreen), c);
            return null;
          }
          bytes.Add(LatinTitleScreen.GetByte(c));
        }
      }

      error = null;
      return bytes.ToArray();
    }

    var rawMap = rom.Skip(0xB629).Take(72 * 2).ToArray();
    var map = new byte[72];
    for (int i = 0; i < map.Length; i++)
    {
      var byte0 = rawMap[i * 2];
      var byte1 = rawMap[(i * 2) + 1];
      var value = byte0 + (byte1 << 8);
      var index = value / 0x100;
      map[i] = (byte)index;
    }

    char ByteToChar(byte b) => b == 0xBF ? '　' : Japanese.GetChar(map[b - 0x30]);

    string ParseOpening(byte[] body)
    {
      var physicalLines = new List<string>();

      for (var physicalLineIndex = 0; physicalLineIndex < 3; physicalLineIndex++)
      {
        var physicalLine = new StringBuilder();
        for (var i = 0; i < 0x10; i++)
        {
          physicalLine.Append(ByteToChar(body[physicalLineIndex * 0x10 + i]));
        }
        physicalLines.Add(physicalLine.ToString());
      }

      return string.Join("\n", physicalLines.Select(pLine => pLine.TrimEnd('　')).ToArray());
    }

    string ParseButton(byte[] body) => new string(body.Select(ByteToChar).ToArray()).TrimEnd('　');

    var ret = new List<Line>();

    foreach (var address in new[] { 0xB6B9, 0xB6E9, 0xB719, 0xB749, 0xB779 })
    {
      ret.Add(new Line(LineCategories.Title, "Opening", address, [], 3, 16, [], rom.Skip(address).Take(0x30).ToArray(), [], Compose, ParseOpening));
    }

    ret.Add(new Line(LineCategories.Title, "Start",    0xB7A9, [], 1, 5, [], rom.Skip(0xB7A9).Take(0x05).ToArray(), [], Compose, ParseButton));
    ret.Add(new Line(LineCategories.Title, "Continue", 0xB7AE, [], 1, 5, [], rom.Skip(0xB7AE).Take(0x05).ToArray(), [], Compose, ParseButton));

    return ret;
  }

  static string CharacterMapError(string characterMapName, char c)
  {
    var characterStr = c == '\r' ? $@"'\r', use spaces instead of return" :
                       c == '\n' ? $@"'\n', use spaces instead of newline" :
                       $@"'{c}'";

    return $"invalid {nameof(LatinTitleScreen)} character {characterStr}";
  }

  enum CompositionModes
  {
    Latin,
    Jumbo,
  }

  enum ParseModes
  {
    Kana,
    Kanji,
    Jumbo,
  }
}
