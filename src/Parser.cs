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
    /* 0x3_ */ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
    /* 0x4_ */ '~', '!', '?', '-', '.', ',', '\'','"', '▲', '▼', '◄', '►', ':', '‘', '“', ' ',
    /* 0x5_ */ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
    /* 0x6_ */ 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'ß', 'Ä', 'Ö', 'Ü', 'a', 'b',
    /* 0x7_ */ 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
    /* 0x8_ */ 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'à', 'â', 'ä', 'è', 'é', 'ê', 'ù', 'û',
    /* 0x9_ */ 'ü', 'ô', 'ö', 'ç', 'î', ' ', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
    /* 0xA_ */ ' ', ' ', ' ', ' ', ' ', ' ', '♥', '&', ' ', ' ', '(', ')', ' ', ' ', ' ', '_',
  ]);

  public static readonly CharacterMap LatinNaming = new CharacterMap(
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

  public static readonly CharacterMap LatinOpening = new CharacterMap(
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
      .Concat(GetNamingLines(rom))
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
            error = "unmatched square bracket";
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
          var match = ControlCodes.Any(pair => pair.Value == controlCode) ? 
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
            error = $"invalid latin dialog character '{c}'";
            return null;
          }
          ret.Add(LatinDialog.GetByte(c));
        }
        else
        {
          if (!LatinJumbo.Contains(c))
          {
            error = $"invalid latin jumbo character '{c}'";
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

    var lines = new List<Line>();

    var index = 0x70000;
    while (index < 0x80000)
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
      while (index < 0x80000)
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
      if (index == 0x80000)
      {
        throw new NotImplementedException("Can't find body and footer of line.");
      }

      var height = 2;
      var width = address >= 0x70F9B && address <= 0x7217A ? 16 : 18;
      lines.Add(new Line(address, ResolveDialogAddressTableIndex(lines.Count), height, width, header.ToArray(), body.ToArray(), footer.ToArray(), Parse, Compose));
    }

    return lines;
  }

  static List<Line> GetDiaryLines(byte[] rom)
  {
    byte[]? Compose(Line line, Translation translation, out string? error)
    {
      var bytes = new List<byte>();

      var count = line.Text.Length;
      for (int i = 0; i < count; i++)
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
            error = $"invalid latin character '{c}'";
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
      new Line(0xE210, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "日記ちょう", Compose),
      new Line(0xE22E, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "王子", Compose),
      new Line(0xE234, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "日記ちょう", Compose),
      new Line(0xE242, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "どの日記で", Compose),
      new Line(0xE24E, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "はじめますか？", Compose),
      new Line(0xE25C, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "       ", Compose),
      new Line(0xE27A, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "どの日記を", Compose),
      new Line(0xE288, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "けしますか？", Compose),
      new Line(0xE294, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "       ", Compose),
      new Line(0xE2B0, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "どうしますか？", Compose),
      new Line(0xE304, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "どのぺーじからよみますか？ ", Compose),
      new Line(0xE33E, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "どの日記に", Compose),
      new Line(0xE34C, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "きろくする？", Compose),
      new Line(0xE358, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "      ", Compose),
      new Line(0xE364, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "        ", Compose),
      new Line(0xE374, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "きろくしました", Compose),
      new Line(0xE382, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "       ", Compose),
      new Line(0xE390, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "たびを ", Compose),
      new Line(0xE39E, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "つづけますか？ ", Compose),
      new Line(0xE3AE, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "日記けす ", Compose),
      new Line(0xE3BC, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "もどる ", Compose),
      new Line(0xE3CA, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "日記つける", Compose),
      new Line(0xE3E6, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "日記たる", Compose),
      new Line(0xE402, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "YES", Compose),
      new Line(0xE41E, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "NO", Compose),
      new Line(0xE43A, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "____王子", Compose),
      new Line(0xE456, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "____王子", Compose),
      new Line(0xE478, -1, 1, 1, new byte[0], new byte[0], new byte[0], bytes => "日め", Compose)
    };
  }

  static List<Line> GetNamingLines(byte[] rom)
  {
    byte[]? Compose(Line line, Translation translation, out string? error)
    {
      var bytes = new List<byte>();

      var count = line.AllBytes.Length;

      for (int i = 0; i < count; i++)
      {
        var c = i >= translation.Text.Length ? ' ' : translation.Text[i];
        if (c == ' ')
        {
          bytes.Add(0xDF);
        }
        else
        {
          if (!LatinNaming.Contains(c))
          {
            error = $"invalid naming character '{c}'";
            return null;
          }
          bytes.Add(LatinNaming.GetByte(c));
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
      new Line(0x4F535, -1, 1, 0x12, new byte[0], rom.Skip(0x4F535).Take(0x12).ToArray(), new byte[0], Parse, Compose)
    };
  }

  static List<Line> GetTitleScreenLines(byte[] rom)
  {
    byte[]? Compose(Line line, Translation translation, out string? error)
    {
      var bytes = new List<byte>();

      var count = line.AllBytes.Length;

      for (int i = 0; i < count; i++)
      {
        var c = i >= translation.Text.Length ? ' ' : translation.Text[i];
        if (c == ' ')
        {
          bytes.Add(0xBF);
        }
        else
        {
          if (!LatinOpening.Contains(c))
          {
            error = $"invalid latin opening character '{c}'";
            return null;
          }
          bytes.Add(LatinOpening.GetByte(c));
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

      for (int physicalLineIndex = 0; physicalLineIndex < 3; physicalLineIndex++)
      {
        var physicalLine = new StringBuilder();
        for (int i = 0; i < 0x10; i++)
        {
          physicalLine.Append(ByteToChar(body[physicalLineIndex * 0x10 + i]));
        }
        physicalLines.Add(physicalLine.ToString());
      }

      return string.Join("\n", physicalLines.Select(pLine => pLine.TrimEnd('　')).ToArray());
    }

    string ParseButton(byte[] body) => new string(body.Select(ByteToChar).ToArray()).TrimEnd('　');

    var ret = new List<Line>();

    // Title Screen - Opening Crawl
    foreach (var address in new[] { 0xB6B9, 0xB6E9, 0xB719, 0xB749, 0xB779 })
    {
      ret.Add(new Line(address, -1, 3, 16, new byte[0], rom.Skip(address).Take(0x30).ToArray(), new byte[0], ParseOpening, Compose));
    }

    // Title Screen - Start
    ret.Add(new Line(0xB7A9, -1, 1, 5, new byte[0], rom.Skip(0xB7A9).Take(0x05).ToArray(), new byte[0], ParseButton, Compose));

    // Title Screen - Continue
    ret.Add(new Line(0xB7AE, -1, 1, 5, new byte[0], rom.Skip(0xB7AE).Take(0x05).ToArray(), new byte[0], ParseButton, Compose));

    return ret;
  }

  static int ResolveDialogAddressTableIndex(int lineIndex)
  {
    var ret = lineIndex;
    ret += (ret >  163 ?   1 : 0); // 163  - 164  are repeats.
    ret += (ret >  165 ?  11 : 0); // 165  - 176  are repeats.
    ret += (ret >  206 ?   2 : 0); // 206  - 208  are repeats.
    ret += (ret >  214 ?  10 : 0); // 214  - 224  are repeats.
    ret += (ret >  234 ?   2 : 0); // 234  - 236  are repeats.
    ret += (ret >  237 ?   1 : 0); // 237  - 238  are repeats.
    ret += (ret >  252 ?   2 : 0); // 252  - 254  are repeats.
    ret += (ret >  313 ? 199 : 0); // 313  - 512  are repeats.
    ret += (ret >  897 ? 127 : 0); // 897  - 1024 are repeats.
    ret += (ret > 1188 ?  92 : 0); // 1188 - 1280 are repeats.
    ret += (ret > 1372 ? 164 : 0); // 1372 - 1536 are repeats.
    ret += (ret > 1682 ? 110 : 0); // 1682 - 1792 are repeats.
    ret += (ret > 1959 ?  89 : 0); // 1959 - 2048 are repeats.
    ret += (ret > 2129 ? 175 : 0); // 2129 - 2304 are repeats.
    return ret;
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
