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

namespace ModularNoteTaker
{
    public class FileMan
    {
        List<Module> ModuleList = new List<Module>();

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
            foreach (string file in Directory.EnumerateFiles(Dir, "*.txt"))
            {
                List<String> AssignmentStrings = new List<string>();
                List<Assignment> ModuleAssgnments = new List<Assignment>();
                int counter = 0;
                string line;
                String[] TextFile = new String[20];
                // Read the file and display it line by line.
                System.IO.StreamReader filereader =
                   new System.IO.StreamReader(file);
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
                String ModuleCode = TextFile[1];
                String ModuleTitle = TextFile[3];
                String ModuleSynopsis = TextFile[5];
                String ModuleLO1 = TextFile[7];
                String ModuleLO2 = TextFile[8];
                String ModuleLO3 = "";
                String ModuleLO4 = "";
                AssignmentStrings.Add(TextFile[10]);
                AssignmentStrings.Add(TextFile[11]);
                AssignmentStrings.Add(TextFile[12]);
                AssignmentStrings.Add(TextFile[13]);
                AssignmentStrings.Add(TextFile[14]);
                AssignmentStrings.Add(TextFile[15]);
                if(TextFile[10] != null && TextFile[10].Contains("ASSIGNMENT"))
                {
                    ModuleLO3 = TextFile[9];
                    // three learning outcomes
                }
                else if (TextFile[11] != null && TextFile[11].Contains("ASSIGNMENT"))
                {
                    ModuleLO3 = TextFile[9];
                    ModuleLO4 = TextFile[10];
                    // four learning outcomes
                }
                foreach (String assignmentstring in AssignmentStrings)
                {
                    Regex regex = new Regex(@"(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1
                    [012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|
                    ((16|[2468][048]|[3579][26])00)|00)))$");
                    if (assignmentstring == null) break;
                    Match match = regex.Match(assignmentstring);
                    if (match.Success)
                    {
                       // Debug.WriteLine("match");
                        //Debug.WriteLine(assignmentstring);
                        bool istest = false;
                        DateTime date= Convert.ToDateTime(match.Value);
                        if (assignmentstring.Contains("w/c"))
                        {
                            istest = true;
                        }
                        ModuleAssgnments.Add(new Assignment(istest, date, new Note(date.ToString(), "")));
                    }
                }
                Assignment[] ModuleArray = ModuleAssgnments.ToArray();
               // Debug.WriteLine("before");
                foreach (Assignment assign in ModuleArray)
                {
                   // Debug.WriteLine(assign.DueDate);
                }
                QuickSort(ModuleArray);
                //Debug.WriteLine("after");
                foreach (Assignment assign in ModuleArray)
                {
                    //Debug.WriteLine(assign.DueDate);
                }
                String ModuleLearningOutcomes = ModuleLO1 + "\r\n" + ModuleLO2 + "\r\n" + ModuleLO3 + "\r\n" + ModuleLO4;
                Module m = new Module(ModuleCode,ModuleTitle,ModuleSynopsis,ModuleLearningOutcomes, ModuleArray, null);
                ModuleList1.Add(m);
            }

        }

        public void SaveJson(String FileLocation) {
            using (FileStream fs = File.Open(FileLocation, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                try
                {
                    jw.Formatting = Formatting.Indented;
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(jw, ModuleList1);
                } catch(Exception e)
                {
                MessageBox.Show("Unable to load file:"+e.Message,"Error!");
                }
            }
        }

        public void loadJson(String FileLocation) {
            try
            {
                StreamReader file = new StreamReader(FileLocation);
                string jsonFile = file.ReadToEnd();
                ModuleList = JsonConvert.DeserializeObject<List<Module>>(jsonFile);
                file.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("Unable to load file:"+e.Message,"Error!");
            }
        }
        public static void QuickSort(Assignment[] data)
        {
            // pre: 0 <= n <= data.length
            // post: values in data[0 ... n -1] are in ascending order
            Quick_Sort(data, 0, data.Length - 1);
        }
        public static void Quick_Sort(Assignment[] data, int left, int right)
        {
            int index, index2;
            long pivot;
            Assignment temp;
            index = left;
            index2 = right;
            pivot = data[(left + right) / 2].DueDate.Ticks;
            do
            {
                while ((data[index].DueDate.Ticks > pivot) && (index < right)) index++;
                while ((pivot > data[index2].DueDate.Ticks) && (index2 > left)) index2--;
                if (index <= index2)
                {
                    temp = data[index];
                    data[index] = data[index2];
                    data[index2] = temp;
                    index++;
                    index2--;
                }
            } while (index <= index2);
            if (left < index2) Quick_Sort(data, left, index2);
            if (index < right)Quick_Sort(data, index, right);
        }
    }
}
