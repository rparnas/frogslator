# English Translation Notes

## History
In 2008, I was spending a semester in Japan and talked with some students (in English, my Japanese isn't great) about games. Kaeru came up. At the time, the Mother 3 translation blogged a lot of technical details and I was like, “I halfway understand what they are doing.”

Project goals and team roles developed over time. If I had to do it again, I would try to define them ahead of time. Loosely, the mission was "translate and localize the game as if it had been released professionally in the early 90s”. The project progressed as follows:

* Hacking (14 months / Jun '08 ~ Jul '09)
* Initial Translation by Eien Ni Hen (8 months / Aug '09 ~ Mar '10)
* Hacking/Inserting Translated Text (5 months / Mar '10 to Jul '10)
* First Beta (1 month / Aug '10)
* Processing Beta Feedback (4 months / Sep '10 to Dec '10)
* Text Overhaul with Brandon and Devin (3 months / Jan '11 to Mar '11)
* Second Beta (1 month / Mar '10)
* Additional Text Iteration (3 months / Apr '10 - Jun '11)
* v1.0 Release (July 10th, 2011)

My approach on the tech side was to keep things simple. No knowledge of ASM or program code was used. Mostly just the dialog data and a few graphics were edited. 

The ROM was not expanded. Normally, this would have an adverse effect on quality as English takes up about 1.5 times as much space as Japanese. This was mitigated somewhat by the fact there is 15% empty space in the dialog part of the ROM, and the original text is a bit kiddish and spells things out, using more space for Japanese text than everyday Japanese.

For the translation itself, the first pass focused on a raw translation of the text and documenting all the cultural references. After that, I was contacted by a writer and a game design instructor who had a lot of thoughts for taking the script to the next level. They drove a second phase of intense iterations on the script from a "writer's first" perspective. I feel this worked really well and I recommend having both a writer and a translator be represented on teams. 

A lot of the text work also involved not just the wording but the timing and pacing of how words appear on the screen. This is important especially for comedy.

## Philosophy
In any translation, there is a tension between translation (introducing foreign culture to the audience) and localization (seamlessly adapting local culture while preserving the ideas and feelings of the original). Neither is inherently good or bad. Either can be done poorly such as a translation that is too literal to understand or a localization that ignores the original meaning.

The weakest parts of our patch might be leaning too much towards translation. For example, I'm pretty sure Nintendo would have renamed wine to something else. However, it's not that Nintendo localizes all Japanese culture out of their games. Consider how weird a Nintendo game seems to someone who has never played one before. But I think what Nintendo does well is put themselves in the shoes of players who don't know about their culture. This is important as they sell games to each new generation of kids.

It's not that we made some parts translate on purpose. It's just that we were immersed in the culture of the game (as are many Nintendo fans) and had only a certain skill level for detecting what feels unnatural to others.

A good translation isn't just about individual words or lines. The comment about accenting the e in Sable is an interesting example. A lot of the game is named for snacks. Where I live in the US, things like cookies are common. In Japan, snacks are more of a delicacy. There are a lot more bakeries as few people own ovens. Specific cookies might be referred to by their technical names, such as the French word sablé. But what is the game trying to get across from this?

It's expressing that the game shouldn't be taken seriously. On a deeper level, it's sharing the fun and culture of the R&D department that made the game. They didn't take _making_ the game too seriously and nerds that they are, their lunchtime conversations moved seamlessly from things like technical discussions to arguing about the minutiae of nearby restaurants. 

Maybe staying with highly technical terms of snacks is too wordy and doesn't get that the game makers are making fun of themselves across. A lot of this cultural context I didn't get when we were making the patch and it would probably be a major overhaul to improve.

But what I'm really reflecting on is that in making a translation I recommend thinking about the big picture and developing broad rules of thumb first. Answer questions like "why are we talking about snacks in the first place?" Then decisions about individual words can then more easily fall into place.

## Translations

### Characters
* Alfred Jinbee - アルフレド じんべぇ
* Cellar Man/Cellar Pal - 穴ぐらのオトコ/穴ぐらの友人
* Croakian Army - ゲロニアン軍団 (lit. Geronian Army, "gero-gero" being the Japanese onomatopoeia for the noise a frog makes).
* Dr. Ivan Knit - アレヲ.シタイン (lit. Areo Shitain, a pun on "I want that", impatience, etc). 
* Lord Delarin - デラーリンさま
* Madeline - マドレーヌ
* Mandola - マンドラ
* Ore Supply - カザンオールスターズ (lit. "Couthern All Stars", a pun on the band "Southern All Stars" aka "SAS. Localized to parody the English soft rock duo "Air Supply". This adds an addition pun about the fact this is a team of miners not present in the original).
  * Russ - ヘースケ (lit. Heisuke)
  * Graham - コータ (lit. Kouta)
  * Chrissie - マーシー (lit. Marcy)
  * Rex - トディ - (lit. Toddy)
* Polnareff - ポルナレフ
* Princess Tiramisu - ティラミス姫
* Sable Prince - サブレ王子

### Places
* A La Mode - アラモード
* Bavarian - ババロア (lit. bavaroise, imported to Japanese from French but Bavarian Cream in English).
* Brown Sugar Island - クロザとう
* Custard Kingdom - カスターど王国
* Eclair Castle - エクレア宮殿
* Eskimo Village - エスキモー村
* Hop Hop - ゲロベップ (lit. "Gerobepp" like "gero" and "hop")
* Ice Cavern -氷のほら穴
* North Cap - 北のみさき
* Meringue Glacier - メレンゲ氷河
* Mille-Feuille - ミルフィーユ
* Port Saltwater - 港町シーミズみなと (lit. "Port Seamizu" a pun on the port town "Chimizu", and "sea", and "mizu" which means water in Japanese. The is localized to "Saltwater" to keep the reference to water and add an additional dessert reference to "Saltwater Taffy" not present in the original).
* Mt. Pudding - フーリン火山 (lit. "Furing Volcano". The Japanese text is clear that the mountain is a volcano while the localization is a bit more coy. But consider that even though Mt. Fuji is technically a Volcano, one wouldn't expect it to explode at any moment).
* Pudding - フーリン (lit. "Furing". A pun on "Furinkazan", the famous banner of Shingen Takeda).
* Snakes' Den - ヘビの穴  (lit. snake hole)
* Syrup Lake - シロップ湖
* Tart Plateau - タルト高原

### Things
* Another Weird Potion - 元にもどるクスリ (lit. Change-Back Potion)
* Bronze Sword - せいどうのつるぎ
* Club Key - クラブのカギ
* Diamond Key - ダイヤのカギ
* Diary - 日記ちょう
* Frogslator - バイリンガエル (lit. Bilingua-Frog).
* Golden Sword - おうごんのつるぎ
* Heart Key - ハートのカギ
* Holy Power - せいなる力
* Igari Z - 東京コミックショーZ (lit. Tokyo Comic Show Z. This is comic as in comedy not as in manga. This references a comedic sketch associated with the holidays and new year. The sketch uses snake puppets which interact with the host who wears an arabesque costume perhaps similar to Alfred Jinbee? "Comic Show" feels really out of place in English, so the reference is obscured using the comedian, Igari Chopin's name. The Z is a reference to the anime Mazinger Z).
* Joy Fruit - しあわせのかじつ
* Leather Shield - かわのたて
* Mammoth Controller / Mamicon - マンモス コントローラー (lit. Mammoth Controller. The Famicom pun was not in the original text).
* Mirror Shield - カガミのたて
* Money Bag - げん金
* Nuts - クリ (lit. chesnut, possibly as in dessert with nuts)
* Old Tablet - いにしえのせきばん (lit. Ancient Tablet)
* Power Suit - パワードスーツ
* Hot Springs Egg - おんせんタマゴ 
* Iron Shield - てつのたて
* Life Stone - ライフストーン
* Pickaxe - ツルハシ
* Power Stone - パワーストーン
* Prime Nouveau - ワイン1ばんしぼり (lit. "Wine Ichibanbori" a pun off of Kirin Ichibanbori, a beer).
* Saw - ノコギリ
* Silver Sword - ぎんのつるぎ
* Snake Killer - スネークキラー
* Spade Key - スペードのカギ
* Speed Stone - スピードストー 
* Spring Bell - はるをつげるベル (lit. "Bell That Rings In Spring")
* Tree Monster - オバケの木
* Weird Potion - あやしいクスリ (lit. "Strange Potion")
* Wine - かいふくのワイン (lit. "Recovery Wine")
* Wooden Shield - 木のたて
* Wonder Ball - イケイケだま (lit. "Groovy Ball". Very difficult to translate. Perhaps it is making fun of how convienient heal points are. The references to the totally 90s candy "Wonder Ball" was added).
* Work Glove - ぐんて
* Z-Flute - Ｚのふえ

### Specific Lines
ニョロ
Literally means "slither".  Localized as "hiss". 

ばばんば ばんばんばん
ハー ビバノンノン！
From the song "What a Nice Bath!" by the Drifters. Localized as "Splish splash! I was taking a bath..." by Bobby Darin.

レッドスネーク カモン
Means 'Red Snake, come on", a famous line said to a snake puppet in the sketch comedy Tokyo Comic Show.

えらいやっちゃ えらいやっちゃ！
年に1どの はるまつり。
おどるアホぅに みるアホぅ！
同じアホなら おどらにゃ ソンソン！
From a dance called Awa Odori, performed at the Obon Festival.

## Resources

### Documents Used
* [FAQ/Walkthrough by EntropicLobo](http://www.gamefaqs.com/gameboy/569755-kaeru-no-tame-ni-kane-wa-naru/faqs/46198): A mostly accurate walkthrough of the game.

### Programs Used
* [frogslator](https://github.com/ryanbgstl/frogslator): Translation utility.
* [No$gba](http://problemkaputt.de/gba.htm): An alternative gameboy emulator with robust debugging tools.
* [Lunar IPS](http://fusoya.eludevisibility.org/lips/): Generates binary patches in the IPS format.
* [relative-search](https://github.com/ryanbgstl/relative-search): A simple relative search tool.
* [Tile Layer Pro](http://www.romhacking.net/utilities/108/): Graphics viewer and editor with support for several console and handheld formats.
* [XVI32](http://www.chmaas.handshake.de/): A free hex editor.

### Links
* 2007
  * [Yasuhiko Fujii – 2007 Developer Interview](http://shmuplations.com/yasuhikofujii/)
* 2008
  * [For the Frog the Bell Tolls Remake [GBC – Cancelled]](https://www.unseen64.net/2008/10/03/for-the-frog-the-bell-tolls-remake/)
* 2011
  * [How exotic! For the Frog the Bell Tolls (Game Boy)](https://www.nsidr.com/archive/how-exotic-for-the-frog-the-bell-tolls-game-boy)
* 2016
  * [Zelda Link's Awakening's Founder: For The Frog The Bell Tolls - Region Locked Feat. Greg](https://www.youtube.com/watch?v=j8gnQ_NzaV8)
* 2023
  * [Link's Awakening & Kaeru no Tame ni Kane wa Naru technical comparison](https://toruzz.com/blog/la-kaeru-technical-comparison)
