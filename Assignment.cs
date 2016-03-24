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
        public String ModuleCode { get; set; }
        private String Key;

        public Assignment(String ModuleCode, DateTime DueDate)
        {
            this.ModuleCode = ModuleCode;
            this.DueDate = DueDate;
            CurrentDate = DateTime.Now;
            Key = String.Concat(ModuleCode,DueDate.ToString());
            Debug.WriteLine("");
        }

        private String getTimetoDueDate()
        {
            return (DueDate - CurrentDate).ToString();
            //TODO return formatted string
        }

    }
}
