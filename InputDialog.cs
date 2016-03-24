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
    public partial class InputDialog : Form
    {
        public string NoteName { get; set; }
        public InputDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text != null ) // make sure that the text is valid
            {
                NoteName = NameTextBox.Text;
                this.DialogResult = DialogResult.OK; // set the dialogresults as "ok", so this can be used to make sure that a valid input has been given
                this.Close();// close the input dialog since the they have succesfully inputted valid data
            }
            else
            {
                MessageBox.Show("Name Must not be null", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error); // show error message if the input is not valid
            }
        }
    }
}
