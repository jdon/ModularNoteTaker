﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleNoteTaker
{
    public class Module
    {
        public String MoudleCodeString { get; set; }
        public String ModuleTitle { get; set; }
        public String ModuleSynopsis { get; set; }
        public String ModuleLearningOutcomes { get; set; }
        public Assignment[] ModuleAssignments { get; set; }
        public List<Note> ModuleNotes { get; set; }

        public Module(String MoudleCode, String ModuleTitle, String ModuleSynopsis, String ModuleLearningOutcome, Assignment[] Assignments, List<Note> Notes)
        {
            this.MoudleCodeString = MoudleCode;
            this.ModuleTitle = ModuleTitle;
            this.ModuleSynopsis = ModuleSynopsis;
            this.ModuleLearningOutcomes = ModuleLearningOutcome;
            this.ModuleAssignments = Assignments;
            if (Notes == null)
            {
                //create empty list
                this.ModuleNotes = new List<Note>();
            }
            else
            {
                // set the list to the note for that module
                this.ModuleNotes = Notes;
            }
        }

        public Boolean isNotesinUse()
        {
            foreach (Note n in ModuleNotes)
            {
                if (n.inUse) return true;
            }
            foreach (Assignment a in ModuleAssignments)
            {
                if (a.note.inUse) return true;
            }
            return false;
        }
    }
}
