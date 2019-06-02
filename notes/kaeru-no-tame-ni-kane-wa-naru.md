# Kaeru no Tame ni Kane wa Naru Technical Notes

## Opening (`0xB629` – `0xB7B4`)

From `0xB629` – `0xB6B8` is a table of 72 2-byte entries. Each entry points to the tile at `[2-byte entry] + 0x50000`. 

Bytes on the opening screen refer the above table. The table index referred to by a byte is `([byte] * 2) - 0x30 + 0xB629`. However, the value `0xBF` indicates a space rather than a table index.

Each paragraph in the opening crawl has three physical lines of 16 bytes. This is followed by the Start and Continue buttons.

* Paragraph 1
  * `0xB6B9` – `0xB6C8`  –  むか～し　むかし
  * `0xB6C9` – `0xB6D8`  –  大変　なかのよい　２つの国に
  * `0xB6D9` – `0xB6E8`  – ２人の　王子セマが　おりました。
* Paragraph 2
  * `0xB6E9` – `0xB6F8` – 
  * `0xB6F9` – `0xB708` – １人は　チャッカリものの
  * `0xB709` – `0xB718` –  カスターど王国の　　王子セマ。
* Paragraph 3
  * `0xB719` – `0xB728`  – 
  * `0xB729` – `0xB738`  –  もう１ひとは　あわてんぼうの
  * `0xB739` – `0xB748`  –  サブレ王国の　  王子サマ。
* Paragraph 4
  * `0xB749` – `0xB758`  – ２人は　小さなころから　
  * `0xB759` – `0xB768`  –  ナニをやっても　ライバルでした。
  * `0xB769` – `0xB778`  – 
* Paragraph 5
  * `0xB779` – `0xB788`  –  これは　そんな
  * `0xB789` – `0xB798`  –  ２ひとの　王子サマの
  * `0xB799` – `0xB7A8`  –  ぼうけんの　ものがたり　です。
* Start Button 
  * `0xB7A9` – `0xB7AD`  –  はじめから
* Continue Button
  * `0xB7AE` – `0xB7B4`  –  つづき　　

## Name Entry (`0x4F534` – `0x4F69B`)

The name entry screen includes the naming prompt, graphics and options for naming the player character. It is `0x12` rows with `0x14` bytes each. These bytes refer to tiles loaded in memory at Char Base `0x8800`, Tile `0x192`. 

Prompt

- `0x4F535` – `0x4F546` – あなたの　なまえを　かきこんで下さい

## Diary

Each character on the graphics screen is specified by two bytes. The first byte is always 0x00. The lines seem delimited with 0xFF, putting in longer phrases than intended seems to cause extra letters to be ignored.

* `0xE210` – `0xE219` – 日記ちょう (header, diary from title screen)

* `0xE22E`  – `0xE231` – 王子 (header, diary in-game)
* `0xE234` – `0xE23D` – 日記ちょう (header, diary in-game)
* `0xE242` – `0xE24B` – どの日記で (left page, 1st line, diary from title screen)
* `0xE24E` – `0xE25B` – はじめますか？(left page, 2nd line, diary from title screen)
* `0xE25C` – 
* `0xE27A` – `0xE283` どの日記を (left page, 1st line, erase diary from title screen)
* `0xE288` – `0xE295` けしますか？ (left page, 2nd line, erase diary from title screen)
* `0xE2B0` – どうしますか？
* `0xE304` – どのぺーじからよみますか？
* `0xE33E` – どの日記に
* `0xE34C` – きろくする？
* `0xE374` – きろくしました
* `0xE390` – たびを
* `0xE39E` – つづけますか？
* `0xE3AE` – 日記けす
* `0xE3BC` – もどる
* `0xE3CA` – 日記つける
* `0xE3E6` – 日記たる
* `0xE402` – YES
* `0xE41E` – NO
* `0xE43A` – `0xE435` – ----王子 (right page, diary from title screen)
* `0xE456` – `0xE461` – ----王子 (right page, diary from title screen)
* `0xE478` – `0xE47B` 日め (right page, diary from title screen)


## Dialog Address Table
The address of the nth line’s address is stored in a 2 byte pair at `0x1CB2E + (0x02 * [N])`. To find a line in the dialog block, reverse the bytes of the 2 byte pair and add one of the following offsets: 

Offset:
Lines N=0..556: 0x70000
Lines N=557..889: 0x74000
Lines N=890..1621: 0x78000
Lines N=1622..2331: 0x7C000

Although 2331 line addresses are stored, only 1348 lines exist in the game as many line addresses refer to the same line (or are junk data).

163 – 164
165 – 176
206 – 208
214 – 224
234 – 236
237 – 238
252 – 254
313 – 512
897 – 1024
1188 – 1280
1372 – 1536
1682 – 1792
1959 – 2048
2129 – 2304

## Dialog Blocks
Dialog is stored in four blocks offset by `0x4000` bytes each (`0x70000`, `0x74000`, `0x78000`, `0x7C0000`). Extra space at the end of a block padded with `0xFF`. 

Dialog consists of lines (which may contain multiple physical lines of text). Every line is in the following format, with the first line starting at `0x70000`. `0xF1` to `0xFF` are control codes.

Lines are delimited with `0xFF`.

Font graphics are in a standard Gameboy format. They can be viewed and modified with Tile Layer Pro. Most characters use a single `0x10` byte tile. Jumbo characters, located at the end of this region, are made up of four tiles.

### Header
The first two bytes of a line. At least controls window position (top, middle,
or bottom) and shape (plain white box or dialog cloud). The exact features have
not been investigated in detail. The pairs used in the game are:

* `0x00 0x00`
* `0x00 0x01`
* `0x00 0x03`
* `0x01 0x00`
* `0x01 0x01`
* `0x02 0x00`
* `0x02 0x01`
* `0x03 0x00`
* `0x03 0x01`

### Control Codes
* `0xF1 0x__` -- Text Speed. The second byte indicates the speed. 0x00 is normal speed and higher numbers are slower:
* `0xF2` -- Animation. Triggers animation during first-person dialog sequences.
* `0xF3` -- Shift to Kana Mode.
* `0xF4` -- Shift to on Kanji Mode.
* `0xF5 0x__` -- Choice. The second byte indicates the type of choice.
* `0xF6 0x__` -- Icon. The second byte displays a 2x2 tile icon from `0x48000 + 0x40 * [2nd Byte]`
* `0xF7` -- Shift to Jumbo Mode.
* `0xF8 0x__` -- Change Music. The second byte indicates the music played.
* `0xF9 0x__` -- Play Sound. The second byte indicates the sound played:
* `0xFA 0x__` -- Displays text. The subsequent byte indicates the text displayed.
* `0xFB 0x__ 0x__` -- Jump to another line. The two byte are the address of the line in the Dialog Address Table. See that section for details. Only occurs immediately before `0xFF` End of Line.
* `0xFC 0x__` Flag. This changes a game variable or flag. This is related to altering game variables. For example, a dialog may begin as soon as a map is entered and the `0xFC` byte pair sets a variable preventing this same dialog from popping up again.
* `0xFD` -- Newline. Also, if in Jumbo mode, shifts back to Kana Mode.
* `0xFE` -- Space
* `0xFF` -- End of Line

#### Control Code Examples
* `0xF1 0x00` -- [Text Speed 0x00]
* `0xF1 0x02` -- [Text Speed 0x02]
* `0xF1 0x03` -- [Text Speed 0x03]
* `0xF1 0x05` -- [Text Speed 0x05]
* `0xF1 0x08` -- [Text Speed 0x08]
* `0xF1 0x10` -- [Text Speed 0x10]
* `0xF1 0x15` -- [Text Speed 0x15]
* `0xF1 0x20` -- [Text Speed 0x20]
* `0xF1 0x30` -- [Text Speed 0x30]
* `0xF2` -- [Animation]
* `0xF3` -- [Kana]
* `0xF4` -- [Kanji]
* `0xF5 0x00` -- [Choice Yes/No]
* `0xF5 0x01` -- [Choice Number]
* `0xF5 0x02` -- [Choice Item]
* `0xF6 0x00` -- [Icon Wooden Shield]
* `0xF6 0x01` -- [Icon Leather Shield]
* `0xF6 0x02` -- [Icon Iron Shield]
* `0xF6 0x03` -- [Icon Mirror Shield]
* `0xF6 0x04` -- [Icon Money]
* `0xF6 0x05` -- [Icon Bracelets]
* `0xF6 0x06` -- [Icon Glove]
* `0xF6 0x07` -- [Icon Frog]
* `0xF6 0x08` -- [Icon Scroll]
* `0xF6 0x09` -- [Icon Book]
* `0xF6 0x0A` -- [Icon Mammoth Controller]
* `0xF6 0x0B` -- [Icon Flute]
* `0xF6 0x0C` -- [Icon Frog Bottle]
* `0xF6 0x0D` -- [Icon Human Bottle]
* `0xF6 0x0E` -- [Icon Heart Bottle]
* `0xF6 0x0F` -- [Icon Big Heart Bottle]
* `0xF6 0x11` -- [Icon Fruit]
* `0xF6 0x12` -- [Icon Egg]
* `0xF6 0x13` -- [Icon Saw]
* `0xF6 0x14` -- [Icon Axe]
* `0xF6 0x15` -- [Icon Wasabi]
* `0xF6 0x16` -- [Icon Door]
* `0xF6 0x17` -- [Icon Tablet]
* `0xF6 0x19` -- [Icon Bronze Sword]
* `0xF6 0x1A` -- [Icon Silver Sword]
* `0xF6 0x1B` -- [Icon Golden Sword]
* `0xF6 0x1C` -- [Icon Heart]
* `0xF6 0x1D` -- [Icon Star]
* `0xF6 0x1E` -- [Icon Moon]
* `0xF6 0x24` -- [Icon Heart Key]
* `0xF6 0x25` -- [Icon Spade Key]
* `0xF6 0x26` -- [Icon Diamond Key]
* `0xF6 0x27` -- [Icon Club Key]
* `0xF7` -- [Jumbo]
* `0xF8 0x01` -- [BGM Fade] -- (Not used in the game)
* `0xF8 0x06` -- [BGM Defeat]
* `0xF8 0x08` -- [BGM Panic+Intro]
* `0xF8 0x0C` -- [BGM Furing]
* `0xF8 0x0E` -- [BGM A La Mode]
* `0xF8 0x11` -- [BGM Seamizu]
* `0xF8 0x13` -- [BGM Underground]
* `0xF8 0x1A` -- [BGM Assault]
* `0xF8 0x1D` -- [BGM Reunion]
* `0xF8 0x1E` -- [BGM Last Duel]
* `0xF8 0x21` -- [BGM Flute]
* `0xF8 0xFA` -- [BGM Speech Off]
* `0xF8 0xFF` -- [BGM Off]
* `0xF9 0x23` -- [SFX Error]
* `0xF9 0x24` -- [SFX Pickup]
* `0xF9 0x29` -- [SFX Jump]
* `0xF9 0x2A` -- [SFX Suprise]
* `0xF9 0x2E` -- [SFX Upgrade]
* `0xF9 0x2F` -- [SFX Mystery]
* `0xF9 0x36` -- [SFX Flute]
* `0xF9 0x37` -- [SFX Victory]
* `0xF9 0x46` -- [SFX Roar]
* `0xF9 0x65` -- [SFX Punch]
* `0xF9 0x66` -- [SFX Kick]
* `0xF9 0x67` -- [SFX Stab]
* `0xF9 0x6A` -- [SFX Snore]
* `0xF9 0x72` -- [SFX Off]
* `0xFA 0x01` -- [Text Space For Icon]
* `0xFA 0x02` -- [Text Item Get] -- "手に入れた！"
* `0xFA 0x04` -- [Text Yes/No]  -- "イエス　ノー"
* `0xFA 0x05` -- [Text News] -- "かべしんぶん　ミルフィーユ•タイムズ NO."
* `0xFA 0x80:` -- [Text Name]
* `0xFA 0x81` -- [Text Nuts]
* `0xFA 0x82` -- [Text Spent] -- (This is the player's money balance saved at certain point in the game and repeated later for comedic effect).
* `0xFD` -- [Newline]
* `0xFE` -- [Space]
* `0xFF` -- [End of Line]

### Kana Mode

A line starts in this mode at byte three (after the two header bytes). Unless a
control code is encountered, the tile at `0x50000 + (0x10 * [byte value])` is
displayed. `0xCA`, `0xCB` and `0xCC` are actually the beginning, middle and end
of a long line respectively. `0xCD` represents the cursor.

|          | **0** |  1   |  2   |  3   |  4   |  5   |  6   |  7   |  8   |  9   |  A   |  B   |  C   |  D   |  E   |  F   |
| :------: | :---: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: |
| **0x0_** |  あ   |  い  |  う  |  え  |  お  |  か  |  き  |  く  |  け  |  こ  |  さ  |  し  |  す  |  せ  |  そ  |  た  |
| **0x1_** |  ち   |  つ  |  て  |  と  |  な  |  に  |  ぬ  |  ね  |  の  |  は  |  ひ  |  ふ  |  へ  |  ほ  |  ま  |  み  |
| **0x2_** |  む   |  め  |  も  |  や  |  ゆ  |  よ  |  ら  |  り  |  る  |  れ  |  ろ  |  わ  |  を  |  ん  |  ぁ  |  ぃ  |
| **0x3_** |  ぅ   |  ぇ  |  ぉ  |  ゃ  |  ゅ  |  ょ  |  っ  |  が  |  ぎ  |  ぐ  |  げ  |  ご  |  ざ  |  じ  |  ず  |  ぜ  |
| **0x4_** |  ぞ   |  だ  |  ぢ  |  づ  |  で  |  ど  |  ば  |  び  |  ぶ  |  べ  |  ぼ  |  ぱ  |  ぴ  |  ぷ  |  ぺ  |  ぽ  |
| **0x5_** |  ア   |  イ  |  ウ  |  エ  |  オ  |  カ  |  キ  |  ク  |  ケ  |  コ  |  サ  |  シ  |  ス  |  セ  |  ソ  |  タ  |
| **0x6_** |  チ   |  ツ  |  テ  |  ト  |  ナ  |  ニ  |  ヌ  |  ネ  |  ノ  |  ハ  |  ヒ  |  フ  |  ヘ  |  ホ  |  マ  |  ミ  |
| **0x7_** |  ム   |  メ  |  モ  |  ヤ  |  ユ  |  ヨ  |  ラ  |  リ  |  ル  |  レ  |  ロ  |  ワ  |  ヲ  |  ン  |  ァ  |  ィ  |
| **0x8_** |  ゥ   |  ェ  |  ォ  |  ャ  |  ュ  |  ョ  |  ッ  |  ガ  |  ギ  |  グ  |  ゲ  |  ゴ  |  ザ  |  ジ  |  ズ  |  ゼ  |
| **0x9_** |  ゾ   |  ダ  |  ヂ  |  ヅ  |  デ  |  ド  |  バ  |  ビ  |  ブ  |  ベ  |  ボ  |  パ  |  ピ  |  プ  |  ペ  |  ポ  |
| **0xA_** |  ～   |  ！  |  ？  |  ー  |  ．  |  ‥   |  ❤   |  ＆  |  、  |  。  |  （  |  ）  |  ◯   |  ✕   |  △   |  ＿  |
| **0xB_** |  Ａ   |  Ｂ  |  Ｃ  |  Ｄ  |  Ｅ  |  Ｆ  |  Ｇ  |  Ｈ  |  Ｉ  |  Ｊ  |  Ｋ  |  Ｌ  |  Ｍ  |  Ｎ  |  Ｏ  |  Ｐ  |
| **0xC_** |  Ｑ   |  Ｒ  |  Ｓ  |  Ｔ  |  Ｕ  |  Ｖ  |  Ｗ  |  Ｘ  |  Ｙ  |  Ｚ  |  ー  |  ー  |  ー  |  ▽   |  「  |  」  |
| **0xD_** |  ０   |  １  |  ２  |  ３  |  ４  |  ５  |  ６  |  ７  |  ８  |  ９  |  同  |      |      |      |      |      |
| **0xE_** |       |      |      |      |      |      |      |  心  |      |      |      |      |      |      |      |      |

### Kanji Mode ###

The font tile at the font tile `0x50DA0 * 0x10 * <byte value>` is displayed. 

|          | **0** |  1   |  2   |  3   |  4   |  5   |  6   |  7   |  8   |  9   |  A   |  B   |  C   |  D   |  E   |  F   |
| :------: | :---: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: |
| **0x0_** |  同   |  代  |  安  |  京  |  氷  |  河  |  王  |  子  |  巨  |  人  |  々  |  山  |  時  |  心  |  大  |  岩  |
| **0x1_** |  日   |  回  |  火  |  水  |  木  |  年  |  上  |  下  |  平  |  和  |  左  |  右  |  東  |  西  |  南  |  北  |
| **0x2_** |  国   |  女  |  姫  |  金  |  小  |  中  |  行  |  百  |  十  |  千  |  万  |  変  |  身  |  申  |  二  |  町  |
| **0x3_** |  所   |  今  |  力  |  村  |  店  |  用  |  手  |  先  |  目  |  乱  |  私  |  友  |  井  |  戸  |  元  |  必  |
| **0x4_** |  間   |  奴  |      |  本  |  自  |  分  |  気  |  失  |  死  |  入  |  匹  |  穴  |      |      |  兵  |  士  |
| **0x5_** |  少   |  以  |  出  |  我  |  恐  |  近  |  当  |  湖  |  内  |  外  |  海  |  全  |  主  |  方  |  向  |  字  |
| **0x6_** |       |  記  |  世  |  宝  |  法  |  口  |      |      |      |      |      |      |      |      |      |      |

### Jumbo Mode ###
Displays special 2x2 font tile at `0x51800 + 0x40 * <Byte Value>`

|          | **0** |  1   |  2   |  3   |  4   |  5   |  6   |  7   |  8   |  9   |  A   |  B   |  C   |  D   |  E   |  F   |
| :------: | :---: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: | :--: |
| **0x0_** |  タ   |  ダ  |  ゲ  |  ッ  |  !   |  ?   |  な  |  に  |  ー  |  っ  |  許  |  せ  |  ん  |  ス  |  ポ  |  ア  |
| **0x1_** |  ～   |  レ  |  Z   |  ‥   |  ギ  |  ャ  |  ぐ  |  わ  |  同  |  じ  |      |      |  ハ  |      |      |  ぁ  |