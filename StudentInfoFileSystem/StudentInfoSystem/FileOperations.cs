using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace StudentInfoSystem
{
     class FileOperations
    {
        
        public static string DirPath= @"C:\Users\apandey\Documents\Visual Studio 2017\Projects\StudentInfoFileSystem\FileStore";

        void createDirectory()
        {
            Directory.CreateDirectory(DirPath);
        }
                                
        public void StoreToFile(StudentDataStore datastore)
        {
            createDirectory();
            if (!File.Exists(DirPath + @"\" + datastore.userID.ToString() + ".txt"))
            {
                using (File.Create(DirPath + @"\" + datastore.userID.ToString() + ".txt"));
            }
            File.WriteAllText(DirPath + @"\" + datastore.userID.ToString() + ".txt", datastore.ToString());
        }
            
        public StudentDataStore ReadFromFile(String id)
        {
            String json=File.ReadAllText(DirPath+@"\"+id+".txt");
            return JsonConvert.DeserializeObject<StudentDataStore>(json);

        }

        public StudentDataStore ReadFromFileFromCompletePath(string path)
        {
                string json = File.ReadAllText(path);
                string todisplay = json.Replace("\"", string.Empty);
                todisplay = todisplay.Replace("{", string.Empty);
                todisplay = todisplay.Replace("}", string.Empty);
                todisplay = todisplay.Replace(",", "\n");
                Console.WriteLine(todisplay);
                Console.WriteLine("---------------------------------------------");
                return JsonConvert.DeserializeObject<StudentDataStore>(json);

            
        }



    }
}
