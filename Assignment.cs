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
        public Note note { get; set; }

        public Assignment(Boolean isTest, DateTime DueDate, Note n)
        {
            this.isTest = isTest;
            this.DueDate = DueDate;
            this.note = n;
            CurrentDate = DateTime.Now;
            Debug.WriteLine("");
        }

        public double getTimetoDueDate()
        {
            double daysreamining = Math.Round((DueDate - CurrentDate).TotalDays);
            if (daysreamining < 0)
            {
                return 0;
            }
            return daysreamining;
        }

    }
}
