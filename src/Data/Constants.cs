namespace Frogslator;

internal static class Constants
{
  public static class Addresses
  {
    public const int FontGraphicsStart  = 0x50000;
    public const int FontGraphicsStop   = 0x52000;
    public const int TitleGraphicsStart = 0x4D770;
    public const int TitleGraphicsStop  = 0x4DD10;
  }

  public static class Lengths
  {
    public const int FontGraphics = Addresses.FontGraphicsStop - Addresses.FontGraphicsStart;
    public const int TitleGraphics = Addresses.TitleGraphicsStop - Addresses.TitleGraphicsStart;
  }
}
