using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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
                if (TextFile[9].Contains("ASSIGNMENT"))
                {
                    // two learning outcomes
                    ModuleAssignment1 = TextFile[10];
                    ModuleAssignment2 = TextFile[11];
                }
                else if(TextFile[10].Contains("ASSIGNMENT"))
                {
                    ModuleLO3 = TextFile[9];
                    ModuleAssignment1 = TextFile[11];
                    ModuleAssignment2 = TextFile[12];
                    // three learning outcomes
                }
                else if (TextFile[11].Contains("ASSIGNMENT"))
                {
                    ModuleLO3 = TextFile[9];
                    ModuleLO4 = TextFile[10];
                    ModuleAssignment1 = TextFile[12];
                    ModuleAssignment2 = TextFile[13];
                    // four learning outcomes
                }
                String ModuleLearningOutcomes = String.Concat(ModuleLO1,"\n",ModuleLO2, "\n", ModuleLO3, "\n", ModuleLO4);
                /*
                Debug.WriteLine(ModuleCode);
                Debug.WriteLine(ModuleTitle);
                Debug.WriteLine(ModuleSynopsis);
                Debug.WriteLine(ModuleLO1);
                Debug.WriteLine(ModuleLO2);
                Debug.WriteLine(ModuleLO3);
                Debug.WriteLine(ModuleLO4);
                Debug.WriteLine(ModuleAssignment1);
                Debug.WriteLine(ModuleAssignment2);
                */
                DateTime date = new DateTime(2017, 1, 18);
                Assignment as1 = new Assignment(ModuleCode, date);
                Assignment as2 = new Assignment(ModuleCode, date);
                Module m = new Module(ModuleCode,ModuleTitle,ModuleSynopsis,ModuleLearningOutcomes, as1, as2,null);
                ModuleList1.Add(m);
                //Debug.WriteLine(contents);
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
