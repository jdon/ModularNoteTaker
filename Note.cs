using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularNoteTaker
{
    public class Note
    {
        public String NoteContents { get; set; }
        public String NoteName { get; set; }

        public Note(String NoteName,String NoteContents)
        {
            this.NoteName = NoteName;
            this.NoteContents = NoteContents;
        }

    }
}
