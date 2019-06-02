using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Frog
{
  public partial class GraphicsControl : UserControl
  {
    Dictionary<char, Bitmap> Letters;
    List<List<string>> Pages;
    public int PageIndex { get; private set; }
    public int PageCount => Pages.Count;
    public int Cols { get; private set; }
    public int Rows { get; private set; }

    public GraphicsControl()
    {
      if (!Program.IsRuning)
      {
        return;
      }

      InitializeComponent();

      Paint += (s, e) =>
      {
        var page = Pages[PageIndex];

        for (var row = 0; row < Rows; row++)
        {
          var line = row < page.Count ? page[row] : "";
          for (var col = 0; col < Cols; col++)
          {
            var c = col < line.Length ? line[col] : ' ';
            e.Graphics.DrawImage(Letters.ContainsKey(c) ? Letters[c] : Letters['?'], new Point(32 * col, 32 * row));
          }
        }
      };

      // Load Graphics
      Letters = new Dictionary<char, Bitmap>();
      var lower = new DirectoryInfo(Program.ResourcesDirectory + "Graphics\\Text").GetFiles("*.jpg");
      var capital = new DirectoryInfo(Program.ResourcesDirectory + "Graphics\\Text\\Cap").GetFiles("*.jpg");
      foreach (FileInfo file in lower.Concat(capital))
      {
        string name = file.Name.Replace(".jpg", "");
        char c = name[0];
        if (name.Equals("question"))
        {
          c = '?';
        }
        else if (name.Equals("quote"))
        {
          c = '\"';
        }
        else if (name.Equals("space"))
        {
          c = ' ';
        }
        Letters.Add(c, new Bitmap(file.DirectoryName + "\\" + file.Name));
      }
      PageIndex = 0;
      Pages = new List<List<string>> { new List<string> { "" } };
    }

    public void Setup(int pageIndex, int rows, int cols, string text)
    {
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

      Cols = cols;
      PageIndex = pageIndex < pages.Count ? pageIndex : pages.Count - 1;
      Pages = pages;
      Rows = rows;
      Size = new Size(32 * cols, 32 * rows);

      Refresh();
    }
  }
}