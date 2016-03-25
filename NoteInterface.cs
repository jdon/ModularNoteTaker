using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModularNoteTaker
{
    public partial class 
        NoteInterface : Form
    {
        private FileMan fm;
        private Note n;
        private bool b = true;
        FontFamily[] fontFamilies;

        public NoteInterface(Note n, int index,FileMan fm)
        {
            InitializeComponent();
            this.fm = fm;
            this.n = n;
            if (n.NoteContents != null)
            {
                try
                {
                    NoteTextBox.Rtf = n.NoteContents;
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
        }
        private void NoteInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            //auto save of closing of form
            n.NoteContents = NoteTextBox.Rtf;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //save
            n.NoteContents = NoteTextBox.Rtf;
        }

        private void FontButton_Click(object sender, EventArgs e)
        {
            // open font dialog and change the font selection
            FontDialog fd = new FontDialog();
            DialogResult result = fd.ShowDialog();
            if (result == DialogResult.OK)
            {

                NoteTextBox.SelectionFont = fd.Font;
            }
        }
    }
}
