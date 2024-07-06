namespace Frogslator;

public class Line
{
  public readonly int Address;
  public readonly byte[] Body;
  public readonly int BoxHeight;
  public readonly int BoxWidth;
  readonly ComposeDelegate ComposeDelegate;
  public readonly int DialogAddressTableLocation;
  public readonly byte[] Footer;
  public readonly byte[] Header;
  public readonly Translation Translation;
  public readonly string Text;

  public byte[] AllBytes
  {
    get
    {
      return new[] { Header, Body, Footer }
        .SelectMany(arr => arr)
        .ToArray();
    }
  }

  public int Block
  {
    get
    {
      return DialogAddressTableLocation switch
      {
        < 0    => -1,
        < 557  =>  0,
        < 890  =>  1,
        < 1622 =>  2,
        _      =>  3,
      };
    }
  }

  public Line(int address, int datLocation, int boxHeight, int boxWidth, byte[] header, byte[] body, byte[] footer, ParseBodyDelegate parseBody, ComposeDelegate compose)
  {
    Address = address;
    Body = body;
    BoxHeight = boxHeight;
    BoxWidth = boxWidth;
    ComposeDelegate = compose;
    DialogAddressTableLocation = datLocation;
    Footer = footer;
    Header = header;
    Text = parseBody(body);
    Translation = new Translation(address);
  }

  public byte[]? Compose(out string? error) => ComposeDelegate(this, Translation, out error);

  public override string ToString() => $@"{Address:X2}";
}

public delegate byte[]? ComposeDelegate(Line line, Translation translation, out string? error);

public delegate string ParseBodyDelegate(byte[] bytes);
