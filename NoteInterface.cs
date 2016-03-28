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
            n.inUse = true;
        }
        private void NoteInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            //auto save on closing of form
            if(NoteTextBox.Rtf != null)
            {
                if (NoteTextBox.Rtf != n.NoteContents)
                { 
                    DialogResult result = MessageBox.Show("Do you want to save before exit?","Save?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        n.NoteContents = NoteTextBox.Rtf;
                    }
                }
            }
            n.inUse = false;
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

        private void NoteTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            new WebBrowserForm(e.LinkText).ShowDialog();
        }
    }
}
