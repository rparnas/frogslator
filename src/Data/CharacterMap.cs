namespace Frogslator;

public class CharacterMap
{
  readonly char[] Map;
  readonly Dictionary<char, byte> CharToIndex;

  public CharacterMap(char[] map)
  {
    Map = map;

    CharToIndex = [];
    for (var i = 0; i < map.Length; i++)
    {
      CharToIndex[map[i]] = (byte)i; // the final occurance of repeated character will be used
    }
  }

  public bool Contains(char c) => CharToIndex.ContainsKey(c);

  public byte GetByte(char c) => CharToIndex[c];

  public char GetChar(byte b) => Map[b];
}
