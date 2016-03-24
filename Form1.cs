﻿using Newtonsoft.Json;
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
    public partial class Form1 : Form
    {
        FileMan FileManInstance;
        private List<Module> ModuleList;
        public Form1()
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
            if (ModuleListBox.Items.Count != 0)
            {
                int index = ModuleListBox.FindStringExact(ModuleListBox.SelectedItem.ToString());
                Module CurrentModule = ModuleList[index];
                List<string> NoteItems = new List<string>();
                foreach (Note note in CurrentModule.ModuleNotes)
                {
                    NoteItems.Add(note.NoteName);
                }
                NoteListBox.DataSource = NoteItems;
                List<string> AssignmentItems = new List<string>();
                AssignmentItems.Add(CurrentModule.ModuleAssignment1.DueDate.ToShortDateString());
                AssignmentItems.Add(CurrentModule.ModuleAssignment2.DueDate.ToShortDateString());
                AssignmentListBox.DataSource = AssignmentItems;
            }
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void moduleFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            if (ModuleListBox.Items.Count != 0)
            {
                int index = ModuleListBox.FindStringExact(ModuleListBox.SelectedItem.ToString());
                updateModuleList();
                Module CurrentModule = ModuleList[index];
                List<string> NoteItems = new List<string>();
                foreach (Note note in CurrentModule.ModuleNotes)
                {
                    NoteItems.Add(note.NoteName);
                }
                NoteListBox.DataSource = NoteItems;
                List<string> AssignmentItems = new List<string>();
                AssignmentItems.Add(CurrentModule.ModuleAssignment1.DueDate.ToShortDateString());
                AssignmentItems.Add(CurrentModule.ModuleAssignment2.DueDate.ToShortDateString());
                AssignmentListBox.DataSource = AssignmentItems;
            }
        }

        private void savedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog LoadDialog = new OpenFileDialog();
            LoadDialog.Filter = "json Data File|*.json";
            DialogResult result = LoadDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                FileManInstance.loadJson(LoadDialog.FileName);
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
            SaveFileDialog SaveDialog = new SaveFileDialog();
            SaveDialog.Filter = "json Data File|*.json";
            SaveDialog.Title = "Save an json File";
            DialogResult result = SaveDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                FileManInstance.SaveJson(SaveDialog.FileName);
                MessageBox.Show("File Saved Successfully");
            }
        }

        private void DeleteModuleButton_Click(object sender, EventArgs e)
        {
            if (ModuleListBox.Items.Count != 0)
            {
                int index = ModuleListBox.FindStringExact(ModuleListBox.SelectedItem.ToString());
                //updateModuleList();
                ModuleList.RemoveAt(index);
                //FileManInstance.ModuleList1 = ModuleList;
                List<string> Items = new List<string>();
                foreach (Module m in FileManInstance.ModuleList1)
                {
                    Items.Add(m.MoudleCodeString + "-" + m.ModuleTitle);
                }
                ModuleListBox.DataSource = Items;
            }
        }

        private void NewNoteButton_Click(object sender, EventArgs e)
        {
            if (ModuleListBox.Items.Count != 0)
            {
                InputDialog input = new InputDialog();
                if (input.ShowDialog().Equals(DialogResult.OK))// makes sure the inputted results are valid
                {
                    Note note = new Note(input.NoteName, null);
                    int index = ModuleListBox.FindStringExact(ModuleListBox.SelectedItem.ToString());
                    Debug.WriteLine("Module Index" + index);
                    Module CurrentModule = ModuleList[index];
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
            NoteInterface ni = new NoteInterface(n, 0, FileManInstance);
            ni.Show();
        }

        private void DeleteNoteButton_Click(object sender, EventArgs e)
        {
            int index = NoteListBox.FindStringExact(NoteListBox.SelectedItem.ToString());
            Debug.WriteLine(index);
            int moduleindex = ModuleListBox.FindStringExact(ModuleListBox.SelectedItem.ToString());
            Debug.WriteLine("Module Index" + moduleindex);
            Module CurrentModule = ModuleList[moduleindex];
            Debug.WriteLine("note amount" + CurrentModule.ModuleNotes.Count);
            CurrentModule.ModuleNotes.RemoveAt(index);
            List<string> NoteItems = new List<string>();
            foreach (Note note in CurrentModule.ModuleNotes)
            {
                NoteItems.Add(note.NoteName);
            }
            NoteListBox.DataSource = NoteItems;
        }
    }
}