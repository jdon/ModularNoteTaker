using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleNoteTaker
{
    public class Note
    {
        public String NoteContents { get; set; }
        public String NoteName { get; set; }
        public Boolean inUse { get; set; }

        public Note(String NoteName,String NoteContents)
        {
            this.NoteName = NoteName;
            this.NoteContents = NoteContents;
            //set in use to false when ever you create a new note
            this.inUse = false;
        }
    }
}
