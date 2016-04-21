using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuleNoteTaker
{
    public class FileManager
    {
        List<Module> ModuleList = new List<Module>();
        private String ModuleCode = "";
        private String ModuleTitle = "";
        private String ModuleSynopsis = "";
        private String ModuleLO1 = "";
        private String ModuleLO2 = "";
        private String ModuleLO3 = "";
        private String ModuleLO4 = "";
        private List<String> AssignmentStrings;
        private List<Assignment> ModuleAssignments;
        //getters and setters for the module list
        internal List<Module> ModuleList1
        {
            get
            {
                return ModuleList;
            }

            set
            {
                ModuleList = value;
            }
        }

        public void ReadModuleFiles(String Dir)
        {
            //loops through the directory given, read each txt file, removes any whitespace and other characters, then creates modules from them.
            foreach (string file in Directory.EnumerateFiles(Dir, "*.txt"))
            {
                int counter = 0;
                string line;
                String[] TextFile = new String[20];
                System.IO.StreamReader filereader = new System.IO.StreamReader(file);
                while ((line = filereader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        if(line != ".")
                        {
                            TextFile[counter] = line;
                            counter++;
                        }
                    }
                }
                filereader.Close();
                CreateModule(TextFile);
            }

        }

        public void CreateModule(String[] TextFile)
        {
            AssignmentStrings = new List<string>();
            // this data has fixed line numbers so can just be read by line number
            ModuleCode = TextFile[1];
            ModuleTitle = TextFile[3];
            ModuleSynopsis = TextFile[5];
            ModuleLO1 = TextFile[7];
            ModuleLO2 = TextFile[8];
            //loops through line 10-15 looking for assignments
            for (int i = 10; i <= 15; i++)
            {
                if (TextFile[i] != null)
                {
                    AssignmentStrings.Add(TextFile[i]);
                }

            }
            //checks to see if there is three or four learning outcomes
            if (TextFile[10] != null && TextFile[10].Contains("ASSIGNMENT"))
            {
                // three learning outcomes
                ModuleLO3 = TextFile[9];
            }
            else if (TextFile[11] != null && TextFile[11].Contains("ASSIGNMENT"))
            {
                // four learning outcomes
                ModuleLO3 = TextFile[9];
                ModuleLO4 = TextFile[10];
            }
            Assignment[] ModuleArray = CreateAssignments(AssignmentStrings);//creates an array based on the inputed strings that might be assignments
            QuickSort(ModuleArray);// sorts the assignments in descending order
            String ModuleLearningOutcomes = ModuleLO1 + "\r\n" + ModuleLO2 + "\r\n" + ModuleLO3 + "\r\n" + ModuleLO4; //creates one string with new lines between each learning objective
            Module m = new Module(ModuleCode, ModuleTitle, ModuleSynopsis, ModuleLearningOutcomes, ModuleArray, null);//since there are no notes for this module yet, sets it to null
             ModuleList1.Add(m);// adds the module to the master module list
        }


        public Assignment[] CreateAssignments(List<string> AssignmentStrings)
        {
            //loops through each string that could be an assignment and extracts information from the string if it is valid
            ModuleAssignments = new List<Assignment>();
            foreach (String assignmentstring in AssignmentStrings)
            {
                // regex that will find the date in pretty much any format e.g dd-mm-yyyy or dd/mm/yy etc
                Regex regex = new Regex(@"(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1
                [012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)
                ?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))$");
                if (assignmentstring == null) break;// if the string is null then we have read every assignment so it breaks from the loop
                Match match = regex.Match(assignmentstring);
                // if successfull then the string contains a date so lets create the assignment
                if (match.Success)
                {
                    bool istest = false;
                    DateTime date = Convert.ToDateTime(match.Value);
                    if (assignmentstring.Contains("w/c")) // checks if it is an inclass test
                    {
                        istest = true;
                    }
                    ModuleAssignments.Add(new Assignment(istest, date, new Note(date.ToString(), ""))); //creates the new assignments and adds it to a list of assignments
                }
            }
            return ModuleAssignments.ToArray(); // returns the list as an array
        }

        public void Save(String FileLocation) {
            // save method using json.net, stream writer is used as we could be working with large files
            try
            {
                using (FileStream fs = File.Open(FileLocation, FileMode.Create))
                using (StreamWriter sw = new StreamWriter(fs))
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(jw, ModuleList1); //serializes the module list so it can be saved
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to load file:" + e.Message, "Error!"); // throw if the file is not valid json or the file is cant be read etc
            }
        }

        public void Load(String FileLocation) {
            // load method using json.net stream read is used as we could be working with large files
            try
            {
                StreamReader file = new StreamReader(FileLocation);
                string jsonFile = file.ReadToEnd();
                ModuleList = JsonConvert.DeserializeObject<List<Module>>(jsonFile);//deserializes the module list
                file.Close(); // closes file so it can be over-written
            }
            catch(Exception e)
            {
                MessageBox.Show("Unable to load file:"+e.Message,"Error!");// throw if the file is not valid json or the file is cant be written to disk etc
            }
        }

        public static void QuickSort(Assignment[] Assignments)
        {
            //implmentation of quicksort which will sort assignments
            Quick_Sort(Assignments, 0, Assignments.Length - 1);
        }
        public static void Quick_Sort(Assignment[] Assignments, int left, int right)
        {
            // DueDate.Ticks is used to get the number of milliseconds
            int index, index2;
            long pivot;
            Assignment temp;
            index = left;
            index2 = right;
            pivot = Assignments[(left + right) / 2].DueDate.Ticks;
            do
            {
                while ((Assignments[index].DueDate.Ticks > pivot) && (index < right)) index++;
                while ((pivot > Assignments[index2].DueDate.Ticks) && (index2 > left)) index2--;
                if (index <= index2)
                {
                    temp = Assignments[index];
                    Assignments[index] = Assignments[index2];
                    Assignments[index2] = temp;
                    index++;
                    index2--;
                }
            } while (index <= index2);
            if (left < index2) Quick_Sort(Assignments, left, index2);
            if (index < right)Quick_Sort(Assignments, index, right);
        }
    }
}
