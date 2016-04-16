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
    public partial class AssessmentsList : Form
    {
        public AssessmentsList(List<string> AssignmentItems)
        {
            InitializeComponent();
            AssignmentListBox.DataSource = AssignmentItems;
        }
    }
}
