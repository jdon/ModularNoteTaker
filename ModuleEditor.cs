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
    public partial class ModuleEditor : Form
    {

        Module m;

        public ModuleEditor(Module m)
        {
            InitializeComponent();
            this.m = m;
            ModuleName.Text = m.MoudleCodeString;
            ModuleTitle.Text = m.ModuleTitle;
            ModuleSynopsis.Text = m.ModuleSynopsis;
            ModuelLO.Text = m.ModuleLearningOutcomes;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            m.MoudleCodeString = ModuleName.Text;
            m.ModuleTitle = ModuleTitle.Text;
            m.ModuleSynopsis = ModuleSynopsis.Text;
            m.ModuleLearningOutcomes = ModuelLO.Text;
            this.DialogResult = DialogResult.OK; // set the dialogresults as "ok", so this can be used to make sure that a valid input has been given
            this.Close();// close the input dialog since the they have succesfully inputted valid data
        }
    }
}
