using System;
using System.Linq;

namespace Frog
{
  public class Line
  {
    public readonly int Address;
    public readonly byte[] Body;
    public readonly Func<byte[]> Compose;
    public readonly int BoxHeight;
    public readonly int BoxWidth;
    public readonly int DialogAddressTableLocation;
    public readonly byte[] Footer;
    public readonly byte[] Header;
    public readonly Translation Translation;
    public readonly string Text;

    public byte[] AllBytes => new[] { Header, Body, Footer }.SelectMany(arr => arr).ToArray();

    public int Block
    {
      get
      {
        if (DialogAddressTableLocation < 0)
        {
          return -1;
        }
        if (DialogAddressTableLocation < 557)
        {
          return 0;
        }
        if (DialogAddressTableLocation < 890)
        {
          return 1;
        }
        if (DialogAddressTableLocation < 1622)
        {
          return 2;
        }
        return 3;
      }
    }

    public Line(int address, int datLocation, int boxHeight, int boxWidth, byte[] header, byte[] body, byte[] footer, Func<byte[], string> parseBody, Func<Line, Translation, byte[]> compose)
    {
      Address = address;
      Body = body;
      Compose = () => compose(this, Translation);
      BoxHeight = boxHeight;
      BoxWidth = boxWidth;
      DialogAddressTableLocation = datLocation;
      Footer = footer;
      Header = header;
      Text = parseBody(body);
      Translation = new Translation(address);
    }

    public override string ToString() => Address.ToString("X2");
  }
}
