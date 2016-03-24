using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModularNoteTaker
{
    public partial class NoteInterface : Form
    {
        private FileMan fm;
        private Note n;
        private bool b = true;

        public NoteInterface(Note n, int index,FileMan fm)
        {
            InitializeComponent();
            this.fm = fm;
            this.n = n;
            if(n.NoteContents != null)
            {
            NoteTextBox.Rtf = n.NoteContents;
            }
        }
        private void assesmentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //save
            n.NoteContents = NoteTextBox.Rtf;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (b)
            {
                NoteTextBox.SelectionFont = new Font(NoteTextBox.Font, FontStyle.Bold);
                b = false;
            }
            else
            {
                NoteTextBox.SelectionFont = new Font(NoteTextBox.Font, FontStyle.Regular);
                b = true;
            }
        }
    }
}
