using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
                    if (!String.IsNullOrWhiteSpace(line))
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
                String ModuleAssignment1 = "";
                String ModuleAssignment2 = "";
                String ModuleAssignment3 = "";
                Assignment as1 = null;
                Assignment as2 = null;
                Assignment as3 = null;
                AssignmentStrings.Add(TextFile[10]);
                AssignmentStrings.Add(TextFile[11]);
                AssignmentStrings.Add(TextFile[12]);
                AssignmentStrings.Add(TextFile[13]);
                AssignmentStrings.Add(TextFile[14]);
                AssignmentStrings.Add(TextFile[15]);
                /*
                if (TextFile[9].Contains("ASSIGNMENT"))
                {
                    // two learning outcomes
                    AssignmentStrings.Add(TextFile[10]);
                    AssignmentStrings.Add(TextFile[11]);
                    AssignmentStrings.Add(TextFile[12]);
                    ModuleAssignment1 = TextFile[10];
                    ModuleAssignment2 = TextFile[11];
                    ModuleAssignment3 = TextFile[12];
                }
                else if(TextFile[10].Contains("ASSIGNMENT"))
                {
                    ModuleLO3 = TextFile[9];
                    AssignmentStrings.Add(TextFile[11]);
                    AssignmentStrings.Add(TextFile[12]);
                    AssignmentStrings.Add(TextFile[13]);
                    ModuleAssignment1 = TextFile[11];
                    ModuleAssignment2 = TextFile[12];
                    ModuleAssignment3 = TextFile[13];
                    // three learning outcomes
                }
                else if (TextFile[11].Contains("ASSIGNMENT"))
                {
                    ModuleLO3 = TextFile[9];
                    ModuleLO4 = TextFile[10];
                    AssignmentStrings.Add(TextFile[12]);
                    AssignmentStrings.Add(TextFile[13]);
                    AssignmentStrings.Add(TextFile[14]);
                    ModuleAssignment1 = TextFile[12];
                    ModuleAssignment2 = TextFile[13];
                    ModuleAssignment3 = TextFile[14];
                    // four learning outcomes
                }
                */
                foreach (String assignmentstring in AssignmentStrings)
                {
                    Regex regex = new Regex(@"((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$");
                    if (assignmentstring == null) break;
                    Match match = regex.Match(assignmentstring);
                    Debug.WriteLine("loop");
                    if (match.Success)
                    {
                        Debug.WriteLine("match");
                        Debug.WriteLine(assignmentstring);
                        bool istest = false;
                        DateTime date= Convert.ToDateTime(match.Value);
                        if (assignmentstring.Contains("w/c"))
                        {
                            istest = true;
                        }
                        ModuleAssgnments.Add(new Assignment(istest, date, new Note(date.ToString(), "")));
                    }
                }
                String ModuleLearningOutcomes = ModuleLO1 + "\r\n" + ModuleLO2 + "\r\n" + ModuleLO3 + "\r\n" + ModuleLO4;
 
                Module m = new Module(ModuleCode,ModuleTitle,ModuleSynopsis,ModuleLearningOutcomes, ModuleAssgnments, null);
                ModuleList1.Add(m);
            }

        }

        public void SaveJson(String FileLocation) {
            using (FileStream fs = File.Open(FileLocation, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, ModuleList1);
            }
        }

        public void loadJson(String FileLocation) {
            StreamReader file = new StreamReader(FileLocation);
            string jsonFile = file.ReadToEnd();
            ModuleList = JsonConvert.DeserializeObject<List<Module>>(jsonFile);
            file.Close();
        }

        public void saveNote(Note n, Module m) {
            //ModuleList1
        }
    }
}
