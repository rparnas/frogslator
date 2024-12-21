namespace Frogslator;

/// <summary>Represents a single 8x8 2-bits per pixel GameBoy Tile.</summary>
public class GameBoyTile
{
  public readonly int Address;
  public readonly Bitmap Bitmap;
  readonly byte[] Bytes;
  readonly byte[] Pixels;

  public GameBoyTile(byte[] rom, int address, Color[] palette)
  {
    Address = address;
    Bytes = new byte[16];
    Pixels = new byte[16 * 4];

    Array.Copy(rom, address, Bytes, 0, Bytes.Length);

    for (int i = 0; i < Bytes.Length; i += 2)
    {
      var lowByte = Bytes[i];
      var highByte = Bytes[i + 1];

      for (int j = 7; j >= 0; j--)
      {
        var lowBit = GetBit(lowByte, j);
        var highBit = GetBit(highByte, j);
        Pixels[i / 2 * 8 + (7 - j)] = (byte)((highBit << 1) + lowBit);
      }
    }

    Bitmap = MakeBitmap(Pixels, palette, 4);
  }

  /// <summary>Return the given bit from the given byte, an index of 0 retrieving the least significant bit and 7 retreiving the most significant bit.</summary>
  static byte GetBit(byte b, int index)
  {
    var mask = 1 << index;
    return (b & mask) == 0 ? (byte)0 : (byte)1;
  }

  static Bitmap MakeBitmap(byte[] pixels, Color[] palette, int scale)
  {
    var ret = new Bitmap(8, 8);

    for (int y = 0; y < 8; y++)
    {
      for (int x = 0; x < 8; x++)
      {
        var pixel = pixels[y * 8 + x];

        var color = pixel < palette.Length ? 
          palette[pixel] : 
          throw new NotImplementedException();

        ret.SetPixel(x, y, color);
      }
    }

    return ScaleBitmap(ret, scale);
  }

  static Bitmap ScaleBitmap(Bitmap original, int scale)
  {
    var ret = new Bitmap(original.Width * scale, original.Height * scale);
    for (int x = 0; x < original.Width; x++)
    {
      for (int y = 0; y < original.Width; y++)
      {
        var color = original.GetPixel(x, y);
        for (int i = 0; i < scale; i++)
        {
          for (int j = 0; j < scale; j++)
          {
            ret.SetPixel(x * scale + i, y * scale + j, color);
          }
        }
      }
    }
    return ret;
  }
}
