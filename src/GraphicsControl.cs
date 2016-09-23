using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Frog
{
    public partial class GraphicsControl : UserControl
    {
        private Dictionary<char, Bitmap> letters = new Dictionary<char, Bitmap>();
        private string text = "";
        private int page = 1;
        public int TotalPages = 6;

        public GraphicsControl()
        {
            InitializeComponent();

            if (Program.ROM == null) { return; }

            // Load the non-capital letters.
            FileInfo[] f1 = new DirectoryInfo(Program.ResourcesDirectory + "Graphics\\Text").GetFiles("*.jpg");
            FileInfo[] f2 = new DirectoryInfo(Program.ResourcesDirectory + "Graphics\\Text\\Cap").GetFiles("*.jpg");
            List<FileInfo> files = new List<FileInfo>();
            files.AddRange(f1);
            files.AddRange(f2);

            foreach (FileInfo file in files)
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
                letters.Add(c, new Bitmap(file.DirectoryName + "\\" + file.Name));
            }
        }

        // Sets the text this control displays.
        public void SetText(int pg, string s)
        {
            this.text = s;
            this.page = pg;
            this.Refresh();
        }

        // Called when the control is painted.
        private void GraphicsControl_Paint(object sender, PaintEventArgs e)
        {
            if (Program.ROM == null) { return; }

            int numRows = this.Size.Height / 32;
            int numCols = this.Size.Width / 32;

            int index = 0;

            int p = 1;
            for (; index < this.text.Length; p++)
            {
                for (int row = 0; row < numRows; row++)
                {
                    for (int col = 0; col < numCols; col++)
                    {
                        char c = index < this.text.Length ? this.text[index] : ' ';

                        if (c == '\n')
                        {
                            while (col < numCols)
                            {
                                if (p == page)
                                {
                                    e.Graphics.DrawImage(this.letters[' '], new Point(32 * col, 32 * row));
                                }
                                col++;
                            }
                        }
                        else if (p == page) // Only draw if you are on the correct page.
                        {
                            Bitmap b = this.letters.ContainsKey(c) ? this.letters[c] : this.letters['?'];
                            e.Graphics.DrawImage(b, new Point(32 * col, 32 * row));
                        }
                        index++;
                    }
                }
            }
            this.TotalPages = p-1;
        }
    }
}