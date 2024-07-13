namespace Frogslator;

public class Line
{
  public readonly int Address;
  public readonly byte[] Body;
  public readonly int BoxHeight;
  public readonly int BoxWidth;
  public readonly LineCategories Category;
  public readonly string? Comment;
  readonly ComposeDelegate ComposeDelegate;
  public readonly int[] DialogAddressTableIndicies;
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

  public int? Block
  {
    get
    {
      if (Address < Constants.Blocks.Dialog0.Start)
      {
        return null;
      }
      else if (Address < Constants.Blocks.Dialog1.Start)
      {
        return 0;
      }
      else if (Address < Constants.Blocks.Dialog2.Start)
      {
        return 1;
      }
      else if (Address < Constants.Blocks.Dialog3.Start)
      {
        return 2;
      }
      else if (Address <= Constants.Blocks.Dialog3.Stop)
      {
        return 3;
      }
      else
      {
        throw new NotImplementedException();
      }
    }
  }

  public Line(LineCategories category, string? comment, int address, int[] datIndicies, int boxHeight, int boxWidth, byte[] header, byte[] body, byte[] footer, ComposeDelegate compose, ParseBodyDelegate parseBody)
  {
    Address = address;
    Body = body;
    BoxHeight = boxHeight;
    BoxWidth = boxWidth;
    Category = category;
    Comment = comment;
    ComposeDelegate = compose;
    DialogAddressTableIndicies = datIndicies;
    Footer = footer;
    Header = header;
    Text = parseBody(body);
    Translation = new Translation(address);
  }

  public byte[]? Compose(out string? error) => ComposeDelegate(this, Translation, out error);

  public override string ToString()
  {
    var blockText = Block.HasValue ? $@" Block {Block}" : string.Empty;
    var commentText = Comment is null ? string.Empty : $@", {Comment}";

    return $@"{Address:X2}: {Category}{blockText}{commentText}";
  }
}

public enum LineCategories
{
  Dialog,
  Diary,
  Naming,
  Title,
}

public delegate byte[]? ComposeDelegate(Line line, Translation translation, out string? error);

public delegate string ParseBodyDelegate(byte[] bytes);
