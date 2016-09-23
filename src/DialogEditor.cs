using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Frog
{
    public partial class DialogEditor : Form
    {
        // Setup a new dialog editor.
        public DialogEditor()
        {
            this.InitializeComponent();

            // Setup the file menu.
            #region Menu

            MainMenu mainMenu = new MainMenu();

            # region File

            MenuItem File = new MenuItem("&File");

            File.MenuItems.Add("Save Translation to Disk...", new EventHandler(this.menuBtn_SaveTrans));
            File.MenuItems.Add("Load Translation from Disk...", new EventHandler(this.menuBtn_LoadTrans));

            File.MenuItems.Add("-");
            
            File.MenuItems.Add("Export ROM Image...", new EventHandler(this.menuBtn_ExportROM));

            File.MenuItems.Add("-");
            
            File.MenuItems.Add("Exit", new EventHandler(this.menuBtn_Exit));

            mainMenu.MenuItems.Add(File);

            #endregion

            this.Menu = mainMenu;

            #endregion

            // Display the lines currently loaded in.
            this.ShowLines();
        }

        // Display the current lines.
        private void ShowLines()
        {
            // Clear the line display.
            this.lb_DialogLines.Items.Clear();

            // Display all the lines in the display.
            foreach (Line l in Program.Lines)
            {
                // If the line doesn't contain the parsed text you are searching for.
                if (!this.tb_SearchParsedText.Text.Equals("") && !l.Dialog.Contains(this.tb_SearchParsedText.Text))
                {
                    continue;
                }

                // If the line doesn't contain the insert text you are searching for.
                if (!this.tb_SearchInsertText.Text.Equals("") && !l.NewDialog.ToLower().Contains(this.tb_SearchInsertText.Text.ToLower()))
                {
                    continue;
                }

                if (!this.tb_SearchSpecialChar.Text.Equals(""))
                {
                    bool has = false;
                    foreach (SpecialChar sc in l.UserSpecialChars)
                    {
                        if (sc.ToString().Contains(tb_SearchSpecialChar.Text))
                            has = true;
                    }
                    if (!has)
                        continue;
                }

                this.lb_DialogLines.Items.Add(l);
            }

            // Special lines
            this.tb_Open1.Text = Program.Line0_Open1.NewDialog;
            this.tb_Open2.Text = Program.Line1_Open2.NewDialog;
            this.tb_Open3.Text = Program.Line2_Open3.NewDialog;
            this.tb_Open4.Text = Program.Line3_Open4.NewDialog;
            this.tb_Open5.Text = Program.Line4_Open5.NewDialog;
            this.tb_Start.Text = Program.Line5_Start.NewDialog;
            this.tb_Continue.Text = Program.Line6_Continue.NewDialog;
            this.tb_Naming.Text = Program.Line7_Naming.NewDialog;

            // Diary lines
            this.tb_Diary_0xE210.Text = Program.Lines_Diary[0].NewDialog;
            this.tb_Diary_0xE22E.Text = Program.Lines_Diary[1].NewDialog;
            this.tb_Diary_0xE234.Text = Program.Lines_Diary[2].NewDialog;
            this.tb_Diary_0xE242.Text = Program.Lines_Diary[3].NewDialog;
            this.tb_Diary_0xE24E.Text = Program.Lines_Diary[4].NewDialog;
            this.tb_Diary_0xE27A.Text = Program.Lines_Diary[5].NewDialog;
            this.tb_Diary_0xE288.Text = Program.Lines_Diary[6].NewDialog;
            this.tb_Diary_0xE2B0.Text = Program.Lines_Diary[7].NewDialog;
            this.tb_Diary_0xE304.Text = Program.Lines_Diary[8].NewDialog;
            this.tb_Diary_0xE33E.Text = Program.Lines_Diary[9].NewDialog;
            this.tb_Diary_0xE34C.Text = Program.Lines_Diary[10].NewDialog;
            this.tb_Diary_0xE374.Text = Program.Lines_Diary[11].NewDialog;
            this.tb_Diary_0xE390.Text = Program.Lines_Diary[12].NewDialog;
            this.tb_Diary_0xE39E.Text = Program.Lines_Diary[13].NewDialog;
            this.tb_Diary_0xE3AE.Text = Program.Lines_Diary[14].NewDialog;
            this.tb_Diary_0xE3BC.Text = Program.Lines_Diary[15].NewDialog;
            this.tb_Diary_0xE3CA.Text = Program.Lines_Diary[16].NewDialog;
            this.tb_Diary_0xE3E6.Text = Program.Lines_Diary[17].NewDialog;
            this.tb_Diary_0xE402.Text = Program.Lines_Diary[18].NewDialog;
            this.tb_Diary_0xE41E.Text = Program.Lines_Diary[19].NewDialog;
            this.tb_Diary_0xE43A.Text = Program.Lines_Diary[20].NewDialog;
            this.tb_Diary_0xE456.Text = Program.Lines_Diary[21].NewDialog;
            this.tb_Diary_0xE478.Text = Program.Lines_Diary[22].NewDialog;

            // Select the first item if it exists.
            this.lb_DialogLines.SelectedIndex = this.lb_DialogLines.Items.Count > 0 ? 0 : -1;

            // Display the number of lines that are in the list box.
            this.lbl_DialogBlock.Text = "Location (" + this.lb_DialogLines.Items.Count + " items)";

            // Show the current free space.
            this.ShowFreeSpace();
        }

        // Display the current free space.
        private void ShowFreeSpace()
        {
            Func<int, string> FreeSpaceString = (i) =>
                {
                    return "Blk" + i + ": " +
                           (Program.BlockMaxSize - Program.BlockSize[i]) + " Bytes Free (" +
                           (100 * ((double)(Program.BlockMaxSize - Program.BlockSize[0]) / Program.BlockMaxSize)).ToString("N2") +
                           "%)" + " (" + Program.BlockBlankLines[i] + ")";
                };

            this.lbl_Block0Bytes.Text = FreeSpaceString(0);
            this.lbl_Block1Bytes.Text = FreeSpaceString(1);
            this.lbl_Block2Bytes.Text = FreeSpaceString(2);
            this.lbl_Block3Bytes.Text = FreeSpaceString(3);
        }

        #region Menu

        private void menuBtn_SaveTrans(object sender, EventArgs e) { Program.SaveLinesToDisk(); }
        private void menuBtn_LoadTrans(object sender, EventArgs e) 
        {
            Program.ReadLinesFromDisk();
            this.ShowLines();
        }

        private void menuBtn_ExportROM(object sender, EventArgs e) { Program.ExportROM(); }

        private void menuBtn_Exit(object sender, EventArgs e) { this.Close(); }

        #endregion

        #region Dialog Block

        // Returns the currently selected line.
        private Line SelectedDialogBlockLine
        {
            get
            {
                // Return null if nothing is selected.
                if (this.lb_DialogLines.SelectedItem == null)
                {
                    return null;
                }

                // Return the selected line.
                return (Line)this.lb_DialogLines.SelectedItem;
            }
        }

        // The current preview page.
        private int Page;

        // The maximum possible pages.
        private int MaxPage;

        private void DisplaySpecialChars()
        {
            int scCount = this.SelectedDialogBlockLine.UserSpecialChars.Count;
            this.lbl_SpecialChars.Text = "Special Chars (" + scCount + ")";
            this.lb_SpecialChars.Items.Clear();
            foreach (SpecialChar sc in this.SelectedDialogBlockLine.UserSpecialChars)
            {
                this.lb_SpecialChars.Items.Add(sc);
            }
        }

        // If the user selects a different line.
        private void lb_DialogLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If something is selected
            if (this.SelectedDialogBlockLine != null)
            {
                this.tb_Dialog.Text = this.SelectedDialogBlockLine.Dialog;
                this.lbl_Dialog.Text = "Parsed Text (" + (this.SelectedDialogBlockLine.Bytes.Count + 1) +  " bytes)";

                this.DisplaySpecialChars();

                this.ShowNewBytesLength(this.SelectedDialogBlockLine.NewBytes(Program.ReverseDialogBlock_Latin, true).Count);
                this.tb_TextToInsert.Text = this.SelectedDialogBlockLine.NewDialog;
                this.tb_Notes.Text = this.SelectedDialogBlockLine.Notes;

                this.tb_Notes1.Text = this.SelectedDialogBlockLine.Notes1;
                this.tp_Notes1.Text = string.IsNullOrEmpty(this.SelectedDialogBlockLine.Notes1) ? "Notes1" : " Notes1*";

                this.tb_Notes2.Text = this.SelectedDialogBlockLine.Notes2;
                this.tp_Notes2.Text = string.IsNullOrEmpty(this.SelectedDialogBlockLine.Notes2) ? "Notes2" : " Notes2*";

                this.tb_Notes3.Text = this.SelectedDialogBlockLine.Notes3;
                this.tp_Notes3.Text = string.IsNullOrEmpty(this.SelectedDialogBlockLine.Notes3) ? "Notes3" : " Notes3*";

                this.cb_IgnoreLine.Checked = this.SelectedDialogBlockLine.IgnoreLine;

                this.tb_TextToInsert.Enabled = true;
                
            }
            else
            {
                this.tb_Dialog.Text = "";
                this.lbl_Dialog.Text = "Parsed Text";

                this.tb_TextToInsert.Text = "";
                this.tb_TextToInsert.Enabled = false;
                this.lbl_TextToInsert.Text = "Text to Insert";

                this.lb_SpecialChars.Items.Clear();
            }

            // You are viewing the first page.
            this.Page = 1;
        }

        // If the text to insert changes.
        private void tb_TextToInsert_TextChanged(object sender, EventArgs e)
        {
            // If no line is selected.
            if (this.SelectedDialogBlockLine == null)
            {
                return;
            }

            // Get the old length of the new dialog.
            int oldLen = SelectedDialogBlockLine.NewBytes(Program.ReverseDialogBlock_Latin, true).Count;

            // Save the new dialog.
            this.SelectedDialogBlockLine.NewDialog = this.tb_TextToInsert.Text.Replace("\r\n", "\n");

            // Show the new dialog length.
            int len = this.SelectedDialogBlockLine.NewBytes(Program.ReverseDialogBlock_Latin, true).Count;
            this.ShowNewBytesLength(len);

            // Update the free space.
            Program.BlockSize[this.SelectedDialogBlockLine.BlockNumber] -= oldLen;
            Program.BlockSize[this.SelectedDialogBlockLine.BlockNumber] += len;

            this.ShowFreeSpace();

            string[] text = this.tb_TextToInsert.Text.Replace("\r", "").Split(new char[]{'*'});
            StringBuilder sb = new StringBuilder();
            Dictionary<int, char> forceValues = new Dictionary<int, char>();

            // The number of characters to ignore.
            int ignoreChars = 0;

            // Text before the first asterisk.
            sb.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (ignoreChars > 0)
                {
                    ignoreChars--;
                    sb.Append(text[i]);
                    continue;
                }

                // Determine what to do based on the asterisk that occurred directly before this text.
                SpecialChar sc = this.SelectedDialogBlockLine.UserSpecialChars.Count > i ? this.SelectedDialogBlockLine.UserSpecialChars[i - 1] : new SpecialChar(0x00, "Circle");

                if (sc.Ignore) { /* Do nothing. */}
                else if (sc.Text.Equals("Heart"))      { sb.Append("♥"); }
                else if (sc.Text.Equals("Circle"))     { sb.Append("*"); }
                else if (sc.Text.Equals("X"))          { sb.Append("X"); }
                else if (sc.Text.Equals("Triangle"))   { sb.Append("*"); }
                else if (sc.Text.Equals("Begin Line")) { sb.Append("-"); }
                else if (sc.Text.Equals("Mid Line"))   { sb.Append("-"); }
                else if (sc.Text.Equals("End Line"))   { sb.Append("-"); }
                else if (sc.Text.Equals("Cursor"))     { sb.Append("*"); }
                else if (sc.Text.Equals("F1 Mode"))    
                {
                    // Ignore this and the next character.
                    ignoreChars = 1;
                }
                else if (sc.Text.Equals("F2"))         { /* Do nothing. */ }
                else if (sc.Text.Equals("F3"))         { /* Do nothing. */ }
                else if (sc.Text.Equals("F5 Mode"))
                {
                    // Ignore this and the next character.
                    ignoreChars = 1;

                    // If there is not another special character.
                    if (i >= this.SelectedDialogBlockLine.UserSpecialChars.Count)
                    {
                        continue;
                    }

                    // Do something based on the next character.
                    SpecialChar nextSC = this.SelectedDialogBlockLine.UserSpecialChars[i];
                    if (nextSC.Text.Equals("F5 - Yes/No Choice"))
                    {
                        forceValues.Add(18, '_');
                        forceValues.Add(26, '_');
                    }
                    else if (nextSC.Text.Equals("F5 - Number Choice"))
                    {
                        forceValues.Add(12, '_');
                        forceValues.Add(13, '_');
                    }
                    else if (nextSC.Text.Equals("F5 - Pick item during fight"))
                    {
                        // Do nothing, this only affects one line.
                    }
                }
                else if (sc.Text.Equals("F6 Mode"))
                {
                    // Ignore this and the next character.
                    // FA - spacing indents chars, F6 simply displays a pic.
                    // Without the FA - spacing, text will display over the image.
                    ignoreChars = 1;
                }
                else if (sc.Text.Equals("Jumbo Mode"))
                {
                    for (int index = i; index < this.SelectedDialogBlockLine.UserSpecialChars.Count; index++)
                    {
                        ignoreChars++;
                        if (this.SelectedDialogBlockLine.UserSpecialChars[index].Text.Equals("Jumbo Return"))
                        {
                            break;
                        }
                    }
                    sb.Append("Jumbo Text\n\n");
                }
                else if (sc.Text.Equals("Music Mode"))
                {
                    // Ignore this and the next character.
                    ignoreChars = 1;
                }
                else if (sc.Text.Equals("SFX Mode"))
                {
                    // Ignore this and the next character.
                    ignoreChars = 1;
                }
                else if (sc.Text.Equals("FA Mode"))
                {
                    // Ignore this and the next character.
                    ignoreChars = 1;

                    // If there is not another special character.
                    if (i >= this.SelectedDialogBlockLine.UserSpecialChars.Count)
                    {
                        continue;
                    }

                    // Do something based on the next character.
                    SpecialChar nextSC = this.SelectedDialogBlockLine.UserSpecialChars[i];
                    if (nextSC.Text.Equals("FA - Text Spacing"))
                    {

                    }
                    else if (nextSC.Text.Equals("FA -  手に入れた！"))
                    {

                    }
                    else if (nextSC.Text.Equals("FA - イエス　ノー"))
                    {

                    }
                    else if (nextSC.Text.Equals("FA - かべしんぶん　ミルフィーユ　タイムズ　No."))
                    {

                    }
                    else if (nextSC.Text.Equals("FA Mode - Player Name"))
                    {
                        sb.Append("NAME");
                    }
                    else if (nextSC.Text.Equals("FA Mode - Player Balance"))
                    {
                        sb.Append("#######");
                    }
                    else if (nextSC.Text.Equals("FA Mode - Some Big Number"))
                    {
                        sb.Append("#");
                    }
                }
                else if (sc.Text.Equals("Jump to Line"))
                {
                    ignoreChars = 2;
                }
                else if (sc.Text.Equals("FC Mode"))
                {
                    // Ignore this and the next character.
                    ignoreChars = 1;
                }

                sb.Append(text[i]);
            }

            char[] s = new char[sb.ToString().Length];
            sb.ToString().CopyTo(0, s, 0, s.Length);
            foreach (int key in forceValues.Keys)
            {
                if (key < s.Length)
                {
                    s[key] = forceValues[key];
                }
            }
            string str = new string(s);

            if (this.SelectedDialogBlockLine.Location >= 0x70F9B && this.SelectedDialogBlockLine.Location <= 0x7217A)
            {
                this.graphicsControl1.Size = new Size(512, 64);
            }
            else
            {
                this.graphicsControl1.Size = new Size(576, 64);
            }

            // Determine what the max page is.
            this.graphicsControl1.SetText(-1, str);

            // If you just added a new page.
            if (this.MaxPage < this.graphicsControl1.TotalPages)
            {
                this.Page = this.graphicsControl1.TotalPages;
            }
            else if (this.MaxPage > this.graphicsControl1.TotalPages) // Max pages decreased.
            {
                if (this.Page > this.graphicsControl1.TotalPages)
                {
                    this.Page = this.graphicsControl1.TotalPages;
                }
            }
            this.graphicsControl1.SetText(this.Page, str);
            this.MaxPage = this.graphicsControl1.TotalPages;

            this.SetPreviewButtons();
        }

        // Show the length of th new bytes.
        private void ShowNewBytesLength(int len)
        {
            this.lbl_TextToInsert.Text = "Text to Insert (" + len + " bytes)";
        }

        private void SetPreviewButtons()
        {
            this.lbl_Prev.Text = "Preview (Page " + this.Page + " of " + this.MaxPage + ")";
            this.btn_PreviewUp.Enabled = this.Page > 1;
            this.btn_PreviewDown.Enabled = this.Page < this.MaxPage;
        }

        private void btn_PreviewUp_Click(object sender, EventArgs e)
        {
            this.Page--;
            this.SetPreviewButtons();
            this.tb_TextToInsert_TextChanged(null, null);
        }

        private void btn_PreviewDown_Click(object sender, EventArgs e)
        {
            this.Page++;
            this.SetPreviewButtons();
            this.tb_TextToInsert_TextChanged(null, null);
        }

        private void tb_TextToSearch_TextChanged(object sender, EventArgs e)
        {
            this.ShowLines();
        }

        #endregion

        private void tb_NameScreen_TextChanged(object sender, EventArgs e)
        {
            char[] str = new char[60];
            for (int i = 0; i < 60; i++) { str[i] = ' '; }
            this.tb_Naming.Text.Replace('\n', '?').CopyTo(0, str, 0, this.tb_Naming.Text.Length > 60 ? 60 : this.tb_Naming.Text.Length);

            // These characters will always be hypens.
            str[46] = '_';
            str[47] = '_';
            str[48] = '_';
            str[49] = '_';

            Program.Line7_Naming.NewDialog = new String(str);
            this.gc_NameScreen.SetText(1, new String(str));
        }

        private void tb_SaveScreen_Top_TextChanged(object sender, EventArgs e)
        {
            char[] str = new char[14];
            for (int i = 0; i < 14; i++) {str[i] = ' ';}
            this.tb_SaveScreen_Top.Text.Replace('\n', '?').CopyTo(0, str, 0, this.tb_SaveScreen_Top.Text.Length > 14 ? 14 : this.tb_SaveScreen_Top.Text.Length);

            this.gc_SaveScreen_Top.SetText(1, new String(str));
        }

        #region Opening Text

        private string ParseNewDialog(string str, State CheckState, int maxLength)
        {
            char[] ret = new char[maxLength];
            for (int i = 0; i < ret.Length; i++) 
            {
                ret[i] = ' '; 
            }

            for (int i = 0; i < str.Length && i < ret.Length; i++)
            {
                ret[i] = Program.ReverseOpening_Latin.ContainsKey("" + str[i]) ? str[i] : '?';
            }
            return new String(ret);
        }

        private void tb_Open1_TextChanged(object sender, EventArgs e)
        {
            string ret = ParseNewDialog(this.tb_Open1.Text, Program.ReverseOpening_Latin, 48);
            Program.Line0_Open1.NewDialog = ret;
            this.gc_Open1.SetText(1, ret);
        }

        private void tb_Open2_TextChanged(object sender, EventArgs e)
        {
            string ret = ParseNewDialog(this.tb_Open2.Text, Program.ReverseOpening_Latin, 48);
            Program.Line1_Open2.NewDialog = ret;
            this.gc_Open2.SetText(1, ret);
        }

        private void tb_Open3_TextChanged(object sender, EventArgs e)
        {
            string ret = ParseNewDialog(this.tb_Open3.Text, Program.ReverseOpening_Latin, 48);
            Program.Line2_Open3.NewDialog = ret;
            this.gc_Open3.SetText(1, ret);
        }

        private void tb_Open4_TextChanged(object sender, EventArgs e)
        {
            string ret = ParseNewDialog(this.tb_Open4.Text, Program.ReverseOpening_Latin, 48);
            Program.Line3_Open4.NewDialog = ret;
            this.gc_Open4.SetText(1, ret);
        }

        private void tb_Open5_TextChanged(object sender, EventArgs e)
        {
            string ret = ParseNewDialog(this.tb_Open5.Text, Program.ReverseOpening_Latin, 48);
            Program.Line4_Open5.NewDialog = ret;
            this.gc_Open5.SetText(1, ret);
        }

        private void tb_Start_TextChanged(object sender, EventArgs e)
        {
            string ret = ParseNewDialog(this.tb_Start.Text, Program.ReverseOpening_Latin, 5);
            Program.Line5_Start.NewDialog = ret;
            this.gc_Start.SetText(1, ret);
        }

        private void tb_Continue_TextChanged(object sender, EventArgs e)
        {
            string ret = ParseNewDialog(this.tb_Continue.Text, Program.ReverseOpening_Latin, 5);
            Program.Line6_Continue.NewDialog = ret;
            this.gc_Continue.SetText(1, ret);
        }

        #endregion

        private void tb_SearchInsertText_TextChanged(object sender, EventArgs e)
        {
            this.ShowLines();
        }

        private void tb_Notes_TextChanged(object sender, EventArgs e)
        {
            if (!this.tb_Notes.Text.Equals(this.SelectedDialogBlockLine.Notes))
            {
                this.SelectedDialogBlockLine.Notes = this.tb_Notes.Text;
            }
        }

        private void tb_Notes1_TextChanged(object sender, EventArgs e)
        {
            if (!this.tb_Notes1.Text.Equals(this.SelectedDialogBlockLine.Notes1))
            {
                this.SelectedDialogBlockLine.Notes1 = this.tb_Notes1.Text;
            }
        }

        private void tb_Notes2_TextChanged(object sender, EventArgs e)
        {
            if (!this.tb_Notes2.Text.Equals(this.SelectedDialogBlockLine.Notes2))
            {
                this.SelectedDialogBlockLine.Notes2 = this.tb_Notes2.Text;
            }
        }

        private void tb_Notes3_TextChanged(object sender, EventArgs e)
        {
            if (!this.tb_Notes3.Text.Equals(this.SelectedDialogBlockLine.Notes3))
            {
                this.SelectedDialogBlockLine.Notes3 = this.tb_Notes3.Text;
            }
        }

        private void lb_SpecialChars_DoubleClick(object sender, EventArgs e)
        {
            if (this.lb_SpecialChars.SelectedIndex < 0)
                return;

            SpecialChar sc = this.SelectedDialogBlockLine.UserSpecialChars[this.lb_SpecialChars.SelectedIndex];
            sc.Ignore = !sc.Ignore;

            // Re-display the special chars so the user will see that it is no italicized.
            this.DisplaySpecialChars();
        }

        private void lb_SpecialChars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lb_SpecialChars.SelectedIndex < 0)
                return;

            SpecialChar sc = this.SelectedDialogBlockLine.UserSpecialChars[this.lb_SpecialChars.SelectedIndex];
            this.btn_EditJumbo.Enabled = sc.ToString().Contains("Jumbo - ");
        }

        #region Diary Text Boxes

        private void tb_Diary_0xE210_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[0].NewDialog = this.tb_Diary_0xE210.Text;
        }

        private void tb_Diary_0xE22E_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[1].NewDialog = this.tb_Diary_0xE22E.Text;
        }

        private void tb_Diary_0xE234_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[2].NewDialog = this.tb_Diary_0xE234.Text;
        }

        private void tb_Diary_0xE242_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[3].NewDialog = this.tb_Diary_0xE242.Text;
        }

        private void tb_Diary_0xE24E_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[4].NewDialog = this.tb_Diary_0xE24E.Text;
        }

        private void tb_Diary_0xE27A_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[5].NewDialog = this.tb_Diary_0xE27A.Text;
        }

        private void tb_Diary_0xE288_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[6].NewDialog = this.tb_Diary_0xE288.Text;
        }

        private void tb_Diary_0xE2B0_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[7].NewDialog = this.tb_Diary_0xE2B0.Text;
        }

        private void tb_Diary_0xE304_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[8].NewDialog = this.tb_Diary_0xE304.Text;
        }

        private void tb_Diary_0xE33E_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[9].NewDialog = this.tb_Diary_0xE33E.Text;
        }

        private void tb_Diary_0xE34C_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[10].NewDialog = this.tb_Diary_0xE34C.Text;
        }

        private void tb_Diary_0xE374_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[11].NewDialog = this.tb_Diary_0xE374.Text;
        }

        private void tb_Diary_0xE390_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[12].NewDialog = this.tb_Diary_0xE390.Text;
        }

        private void tb_Diary_0xE39E_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[13].NewDialog = this.tb_Diary_0xE39E.Text;
        }

        private void tb_Diary_0xE3AE_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[14].NewDialog = this.tb_Diary_0xE3AE.Text;
        }

        private void tb_Diary_0xE3BC_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[15].NewDialog = this.tb_Diary_0xE3BC.Text;
        }

        private void tb_Diary_0xE3CA_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[16].NewDialog = this.tb_Diary_0xE3CA.Text;
        }

        private void tb_Diary_0xE3E6_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[17].NewDialog = this.tb_Diary_0xE3E6.Text;
        }

        private void tb_Diary_0xE402_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[18].NewDialog = this.tb_Diary_0xE402.Text;
        }

        private void tb_Diary_0xE41E_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[19].NewDialog = this.tb_Diary_0xE41E.Text;
        }

        private void tb_Diary_0xE43A_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[20].NewDialog = this.tb_Diary_0xE43A.Text;
        }

        private void tb_Diary_0xE456_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[21].NewDialog = this.tb_Diary_0xE456.Text;
        }

        private void tb_Diary_0xE478_TextChanged(object sender, EventArgs e)
        {
            Program.Lines_Diary[22].NewDialog = this.tb_Diary_0xE478.Text;
        }

        #endregion

        private void cb_IgnoreLine_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cb_IgnoreLine.Checked != this.SelectedDialogBlockLine.IgnoreLine)
            {
                this.SelectedDialogBlockLine.IgnoreLine = this.cb_IgnoreLine.Checked;
            }
        }

        private void btn_EditJumbo_Click(object sender, EventArgs e)
        {
            if (this.lb_SpecialChars.SelectedIndex >= 0 && this.lb_SpecialChars.SelectedItem is SpecialChar)
                new EditJumboForm().ShowDialog((SpecialChar)this.lb_SpecialChars.SelectedItem);

            this.DisplaySpecialChars();
        }

        private void tb_SearchSpecialChar_TextChanged(object sender, EventArgs e)
        {
            this.ShowLines();
        }
    }
}