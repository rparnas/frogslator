using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Frog
{
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

        for (var row = 0; row < Rows; row++)
        {
          var line = row < page.Count ? page[row] : "";
          for (var col = 0; col < Cols; col++)
          {
            var c = col < line.Length ? line[col] : ' ';
            var spaceIndex = 79;
            var qmIndex = Parser.ReverseLatin['?'];
            var i = c == ' ' ? spaceIndex : Parser.ReverseLatin.ContainsKey(c) ? Parser.ReverseLatin[c] : qmIndex;
            var bmp = i < Program.FontBitmaps.Count ? Program.FontBitmaps[i] : Program.FontBitmaps[qmIndex];
            e.Graphics.DrawImage(bmp.Bitmap, new Point(32 * col, 32 * row));
          }
        }
      };

      PageIndex = 0;
      Pages = new List<List<string>> { new List<string> { "" } };
    }

    public void SetPage(int pageIndex)
    {
      PageIndex = pageIndex;
      Refresh();
    }

    public void Setup(bool reset, int rows, int cols, string text)
    {
      var oldPages = Pages.Count;

      var pages = new List<List<string>> { new List<string> { "" } };

      void newline()
      {
        if (pages.Last().Count == rows)
        {
          pages.Add(new List<string> { "" });
        }
        else
        {
          pages.Last().Add("");
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

      var newPages = pages.Count;

      Cols = cols;
      PageIndex = reset ? 0 : 
                  newPages != oldPages && PageIndex == oldPages - 1 ? newPages - 1 : 
                  PageIndex >= pages.Count ? newPages -1 :
                  PageIndex;
      Pages = pages;
      Rows = rows;
      Size = new Size(32 * cols, 32 * rows);

      Refresh();
    }
  }
}