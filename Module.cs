using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularNoteTaker
{
    public class Module
    {
        public String MoudleCodeString { get; set; }
        public String ModuleTitle { get; set; }
        public String ModuleSynopsis { get; set; }
        public String ModuleLearningOutcomes { get; set; }
        public Assignment ModuleAssignment1 { get; set; }
        public Assignment ModuleAssignment2 { get; set; }
        public Assignment ModuleAssignment3 { get; set; }
        public List<Note> ModuleNotes { get; set; }

        public Module(String MoudleCode, String ModuleTitle, String ModuleSynopsis, String ModuleLearningOutcome, Assignment ModuleAssignment1, Assignment ModuleAssignment2, Assignment ModuleAssignment3, List<Note> Notes)
        {
            this.MoudleCodeString = MoudleCode;
            this.ModuleTitle = ModuleTitle;
            this.ModuleSynopsis = ModuleSynopsis;
            this.ModuleLearningOutcomes = ModuleLearningOutcome;
            this.ModuleAssignment1 = ModuleAssignment1;
            this.ModuleAssignment2 = ModuleAssignment2;
            this.ModuleAssignment3 = ModuleAssignment3;
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
    }
}
