using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularNoteTaker
{
    public class Assignment
    {
        public DateTime CurrentDate { get; private set; }
        public DateTime DueDate { get; set; }
        public Boolean isTest { get; set; }

        public Assignment(Boolean isTest, DateTime DueDate)
        {
            this.isTest = isTest;
            this.DueDate = DueDate;
            CurrentDate = DateTime.Now;
            Debug.WriteLine("");
        }

        private String getTimetoDueDate()
        {
            return (DueDate - CurrentDate).ToString();
            //TODO return formatted string
        }

    }
}
