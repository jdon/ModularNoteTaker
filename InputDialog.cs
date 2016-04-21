using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuleNoteTaker
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
            Debug.WriteLine("Sender" + sender.ToString() + "Event Arguments" + e.ToString()); // method coverage
            Debug.WriteLine(NameTextBox.Text); //
            if (!NameTextBox.Text.Equals("")) // make sure that the text is valid
            {
                NoteName = NameTextBox.Text;
                Debug.WriteLine("Input was valid"); // branch coverage
                Debug.WriteLine("Note name:"+ NoteName); // statement coverage
                this.DialogResult = DialogResult.OK; // set the dialogresults as "ok", so this can be used to make sure that a valid input has been given
                Debug.WriteLine("Dialog Result:" + DialogResult.ToString()); // statement coverage
                this.Close();// close the input dialog since the they have succesfully inputted valid data
            }
            else
            {
                Debug.WriteLine("Input was null"); // branch coverage
                MessageBox.Show("Name Must not be null", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error); // show error message if the input is not valid
                this.DialogResult = DialogResult.Cancel;
                this.Close();

            }
        }
    }
}
