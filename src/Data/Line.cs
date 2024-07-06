﻿namespace Frogslator;

public class Line
{
  public readonly int Address;
  public readonly byte[] Body;
  public readonly int BoxHeight;
  public readonly int BoxWidth;
  public readonly string Category;
  public readonly string? Comment;
  readonly ComposeDelegate ComposeDelegate;
  public readonly int[] DialogAddressTableLocations;
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
      if (!DialogAddressTableLocations.Any())
        return null;

      return DialogAddressTableLocations.First() switch
      {
        < 557  =>  0,
        < 890  =>  1,
        < 1622 =>  2,
        _      =>  3,
      };
    }
  }

  public Line(string category, string? comment, int address, int[] datLocations, int boxHeight, int boxWidth, byte[] header, byte[] body, byte[] footer, ComposeDelegate compose, ParseBodyDelegate parseBody)
  {
    Address = address;
    Body = body;
    BoxHeight = boxHeight;
    BoxWidth = boxWidth;
    Category = category;
    Comment = comment;
    ComposeDelegate = compose;
    DialogAddressTableLocations = datLocations;
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

public delegate byte[]? ComposeDelegate(Line line, Translation translation, out string? error);

public delegate string ParseBodyDelegate(byte[] bytes);