namespace Frogslator;

public partial class GraphicsControl : UserControl
{
  List<List<string>> Pages;
  public int PageIndex { get; private set; }
  public int PageCount => Pages.Count;
  public int Cols { get; private set; }
  public int Rows { get; private set; }

  public GraphicsControl()
  {
    InitializeComponent();
    DoubleBuffered = true;

    Paint += (s, e) =>
    {
      if (Pages == null)
      {
        return;
      }

      var page = Pages[PageIndex];
      var qmIndex = Parser.LatinDialog.GetByte('?');

      for (var row = 0; row < Rows; row++)
      {
        var line = row < page.Count ? page[row] : "";
        for (var col = 0; col < Cols; col++)
        {
          var c = col < line.Length ? line[col] : ' ';
          var spaceIndex = 79;

          var i = c == ' ' ? spaceIndex : Parser.LatinDialog.Contains(c) ? Parser.LatinDialog.GetByte(c) : qmIndex;
          var bmp = i < Program.FontBitmaps.Count ? Program.FontBitmaps[i] : Program.FontBitmaps[qmIndex];
          e.Graphics.DrawImage(bmp.Bitmap, new Point(32 * col, 32 * row));
        }
      }
    };

    PageIndex = 0;
    Pages = new List<List<string>> { new List<string> { string.Empty } };
  }

  public void SetPage(int pageIndex)
  {
    PageIndex = pageIndex;
    Refresh();
  }

  public void Setup(bool reset, int rows, int cols, string text, bool assumeSixLetterNames)
  {
    var oldPageCount = Pages.Count;
    var processedText = ProcessText(text, assumeSixLetterNames);
    var newPages = PaginateText(rows, cols, processedText);
    var newPageCount = newPages.Count;

    Cols = cols;
    PageIndex = reset ? 0 : 
                newPageCount != oldPageCount && PageIndex == oldPageCount - 1 ? newPageCount - 1 : 
                PageIndex >= newPages.Count ? newPageCount -1 :
                PageIndex;
    Pages = newPages;
    Rows = rows;
    Size = new Size(32 * cols, 32 * rows);

    Refresh();
  }

  static List<List<string>> PaginateText(int rows, int cols, string text)
  {
    var pages = new List<List<string>> { new List<string> { string.Empty } };

    void newline()
    {
      if (pages.Last().Count == rows)
      {
        pages.Add(new List<string> { string.Empty });
      }
      else
      {
        pages.Last().Add(string.Empty);
      }
    }

    foreach (var c in text)
    {
      if (c == '\n')
      {
        newline();
        continue;
      }

      if (pages.Last().Last().Length == cols)
      {
        newline();
      }
      pages.Last()[pages.Last().Count - 1] += c;
    }

    return pages;
  }

  static string ProcessText(string text, bool assumeSixLetterNames)
  {
    var displayLines = text
      .Split('\n')
      .ToList();

    for (var i = 0; i < displayLines.Count; i++)
    {
      var displayLine = displayLines[i];

      displayLine = displayLine.Replace("[Text Name]", assumeSixLetterNames ? "~NAME~" : "NAME");

      while (displayLine.Contains('['))
      {
        var openIndex = displayLine.IndexOf('[');
        var closeIndex = displayLine.IndexOf(']');
        if (closeIndex == -1)
        {
          break;
        }

        var term = displayLine.Substring(openIndex, closeIndex - openIndex + 1);
        displayLine = displayLine.Remove(openIndex, closeIndex - openIndex + 1);

        if (term == "[Jumbo]")
        {
          displayLines.Insert(i + 1, string.Empty);
        }
        if (term == "[Text Space For Icon]")
        {
          var spaceForIcon = "    ";
          displayLine = spaceForIcon + displayLine;
        }
      }

      displayLines[i] = displayLine;
    }

    return string.Join('\n', displayLines.ToArray());
  }
}