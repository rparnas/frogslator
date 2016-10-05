using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frogslator
{
    public partial class EditJumboForm : Form
    {
        private SpecialChar SpecialChar;

        public EditJumboForm()
        {
            InitializeComponent();
        }

        public void ShowDialog(SpecialChar sc)
        {
            this.SpecialChar = sc;
            this.lbl_OriginalValue.Text += sc.OriginalValue + " - " + SpecialChar.JumboOriginalValueDictionary[sc.OriginalValue];

            foreach (KeyValuePair<byte, string> pair in SpecialChar.JumboValueDictionary)
            {
                this.cb_NewValues.Items.Add(pair);

                if (pair.Key == sc.OriginalValue)
                    this.cb_NewValues.SelectedItem = pair;
            }
            this.cb_NewValues.DisplayMember = "Value";

            base.ShowDialog();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            KeyValuePair<byte, string> newValuePair = (KeyValuePair<byte, string>)this.cb_NewValues.SelectedItem;
            this.SpecialChar.Value = newValuePair.Key;

            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
