namespace Frogslator;

internal static class Utils
{
  public static byte[] GetBytes(long value)
  {
    if (value == 0)
    {
      return [0];
    }
    if (value < 0)
    {
      throw new ArgumentOutOfRangeException(nameof(value), "Value cannot be negative.");
    }

    var bytes = new List<byte>();

    while (value > 0)
    {
      bytes.Insert(0, (byte)(value & 0xFF));
      value >>= 8;
    }

    return bytes
      .ToArray();
  }

  public static byte[] GetBytes(long value, int count)
  {
    var bytes = GetBytes(value);

    if (bytes.Length > count)
      throw new ArgumentException($"Value {value} is too large to fit in {count} bytes.");

    if (bytes.Length < count)
    {
      var paddedBytes = new byte[count];
      Array.Copy(bytes, 0, paddedBytes, count - bytes.Length, bytes.Length);
      return paddedBytes;
    }

    return bytes;
  }
}
