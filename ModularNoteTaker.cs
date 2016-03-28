using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModularNoteTaker
{
    public partial class ModularNoteTaker : Form
    {
        FileMan FileManInstance;
        private List<Module> ModuleList;
        public ModularNoteTaker()
        {
            InitializeComponent();
            FileManInstance = new FileMan();
            ModuleList = FileManInstance.ModuleList1;
        }
        private void updateModuleList()
        {
            ModuleList = FileManInstance.ModuleList1;

        }

        private void updateSelectedModule()
        {
            if (ModuleListBox.Items.Count >= 1)
            {
                int index = ModuleListBox.SelectedIndex;
                updateModuleList();
                Module CurrentModule = ModuleList[index];
                List<string> NoteItems = new List<string>();
                foreach (Note note in CurrentModule.ModuleNotes)
                {
                    NoteItems.Add(note.NoteName);
                }
                NoteListBox.DataSource = NoteItems;
                List<string> AssignmentItems = new List<string>();
                foreach (Assignment assignment in CurrentModule.ModuleAssignments)
                {
                    if (assignment.isTest)
                    {
                        AssignmentItems.Add("In class test:  " + assignment.DueDate.ToShortDateString() +"  "+ assignment.getTimetoDueDate() + " days remaining");
                    }
                    else
                    {
                        AssignmentItems.Add("Assignment:  " + assignment.DueDate.ToShortDateString() + "  " + assignment.getTimetoDueDate() + " days remaining");
                    }
                }
                AssignmentListBox.DataSource = AssignmentItems;
            }
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void moduleFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ModuleList.Count != 0) // already modules loaded
            {
                MessageBox.Show("Modules already loaded!Please delete the current ones", "Error!");
                return;
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                FileManInstance.ReadModuleFiles(folderBrowserDialog1.SelectedPath);
                updateModuleList();
                List<string> Items = new List<string>();
                foreach (Module m in ModuleList)
                {
                    Items.Add(m.MoudleCodeString + "-" + m.ModuleTitle);
                }
                ModuleListBox.DataSource = Items;
            }
        }

        private void ModuleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateSelectedModule();
        }

        private void savedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog LoadDialog = new OpenFileDialog();
            LoadDialog.Filter = "json Data File|*.json";
            DialogResult result = LoadDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                FileManInstance.Load(LoadDialog.FileName);
            }
            List<string> Items = new List<string>();
            foreach (Module m in FileManInstance.ModuleList1)
            {
                Items.Add(m.MoudleCodeString + "-" + m.ModuleTitle);
            }
            ModuleListBox.DataSource = Items;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ModuleListBox.Items.Count == 0)
            {
                MessageBox.Show("There are no items to save!","Error!");
                return;
            }
            SaveFileDialog SaveDialog = new SaveFileDialog();
            SaveDialog.Filter = "json Data File|*.json";
            SaveDialog.Title = "Save an json File";
            DialogResult result = SaveDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                FileManInstance.Save(SaveDialog.FileName);
                MessageBox.Show("File Saved Successfully");
            }
        }

        private void DeleteModuleButton_Click(object sender, EventArgs e)
        {
            if (ModuleListBox.Items.Count != 0)
            {
                int index = ModuleListBox.FindStringExact(ModuleListBox.SelectedItem.ToString());
                //updateModuleList();
                Module CurrentModule = ModuleList[index];
                if (CurrentModule.isNotesinUse())
                {
                    MessageBox.Show("A note for this module is currently in use, please close it.", "Error!");
                    return;
                }
                ModuleList.RemoveAt(index);
                //FileManInstance.ModuleList1 = ModuleList;
                List<string> Items = new List<string>();
                foreach (Module m in FileManInstance.ModuleList1)
                {
                    Items.Add(m.MoudleCodeString + "-" + m.ModuleTitle);
                }
                ModuleListBox.DataSource = Items;
            }
            if (ModuleListBox.Items.Count == 0)
            {
                //if the last module is deleted then clear the note and assignment list boxes
                AssignmentListBox.DataSource = null;
                NoteListBox.DataSource = null;
            }
        }

        private void NewNoteButton_Click(object sender, EventArgs e)
        {
            if (ModuleListBox.Items.Count != 0)
            {
                InputDialog input = new InputDialog();
                if (input.ShowDialog().Equals(DialogResult.OK))// makes sure the inputted results are valid
                {
                    int index = ModuleListBox.FindStringExact(ModuleListBox.SelectedItem.ToString());
                    Debug.WriteLine("Module Index" + index);
                    Module CurrentModule = ModuleList[index];
                    foreach (Note n in CurrentModule.ModuleNotes)
                    {
                        if (string.Equals(n.NoteName, input.NoteName, StringComparison.OrdinalIgnoreCase))
                        {
                            //can not create new note with same name
                            MessageBox.Show("Can not create a note with the same name!","Error!");
                            return;
                        }
                    }
                    Note note = new Note(input.NoteName, null);
                    CurrentModule.ModuleNotes.Add(note);
                    Debug.WriteLine(CurrentModule.ModuleNotes.Count);
                    updateSelectedModule();
                }
            }
        }
        private void NoteListBox_DoubleClick_1(object sender, EventArgs e)
        {
            int index = NoteListBox.FindStringExact(NoteListBox.SelectedItem.ToString());
            Debug.WriteLine(index);
            int moduleindex = ModuleListBox.FindStringExact(ModuleListBox.SelectedItem.ToString());
            Debug.WriteLine("Module Index" + moduleindex);
            Module CurrentModule = ModuleList[moduleindex];
            Debug.WriteLine("note amount" + CurrentModule.ModuleNotes.Count);
            Note n = CurrentModule.ModuleNotes[index];
            if (n.inUse)
            {
                MessageBox.Show("Note is in use!", "Error!");
                return;
            }
            try
            {
                NoteInterface ni = new NoteInterface(n, 0, FileManInstance);
                ni.Text = n.NoteName;
                ni.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("The note you are trying to read is invalid or may be corrupted"+ex.Message, "Error!");
            }
        }

        private void DeleteNoteButton_Click(object sender, EventArgs e)
        {
            if (NoteListBox.Items.Count == 0) return;
            int index = NoteListBox.FindStringExact(NoteListBox.SelectedItem.ToString());
            Debug.WriteLine(index);
            int moduleindex = ModuleListBox.FindStringExact(ModuleListBox.SelectedItem.ToString());
            Module CurrentModule = ModuleList[moduleindex];
            if (CurrentModule.ModuleNotes[index].inUse)
            {
                MessageBox.Show("Note is in use!", "Error!");
                return;
            }
            CurrentModule.ModuleNotes.RemoveAt(index);
            List<string> NoteItems = new List<string>();
            foreach (Note note in CurrentModule.ModuleNotes)
            {
                NoteItems.Add(note.NoteName);
            }
            NoteListBox.DataSource = NoteItems;
        }

        private void EditModuleButton_Click(object sender, EventArgs e)
        {
            if (ModuleListBox.Items.Count == 0) return;
            int index = ModuleListBox.FindStringExact(ModuleListBox.SelectedItem.ToString());
            updateModuleList();
            ModuleEditor me = new ModuleEditor(ModuleList[index]);
            DialogResult rd = me.ShowDialog();
            if (rd == DialogResult.OK)
            {
                List<string> Items = new List<string>();
                foreach (Module m in FileManInstance.ModuleList1)
                {
                    Items.Add(m.MoudleCodeString + "-" + m.ModuleTitle);
                }
                ModuleListBox.DataSource = Items;
            }
        }

        private void AssignmentListBox_DoubleClick(object sender, EventArgs e)
        {
            int index = AssignmentListBox.FindStringExact(AssignmentListBox.SelectedItem.ToString());
            Debug.WriteLine(index);
            int moduleindex = ModuleListBox.FindStringExact(ModuleListBox.SelectedItem.ToString());
            Debug.WriteLine("Module Index" + moduleindex);
            Module CurrentModule = ModuleList[moduleindex];
            Debug.WriteLine("note amount" + CurrentModule.ModuleAssignments);
            Assignment assignment = CurrentModule.ModuleAssignments[index];
            Note n = assignment.note;
            if (n.inUse)
            {
                MessageBox.Show("Note is in use!", "Error!");
                return;
            }
            try
            {
                NoteInterface ni = new NoteInterface(n, 0, FileManInstance);
                if (assignment.isTest)
                {
                    ni.Text = ("In class test:  " + assignment.DueDate.ToShortDateString() + "  " + assignment.getTimetoDueDate() + " days remaining");
                }
                else
                {
                    ni.Text = ("Assignment:  " + assignment.DueDate.ToShortDateString() + "  " + assignment.getTimetoDueDate() + " days remaining");
                }
                ni.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The note you are trying to read is invalid or may be corrupted"+ex.Message, "Error");
            }
        }
    }
}
