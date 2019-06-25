using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Sample.Utilites
{
    class ReadingFile
    {
        // Read Json File 
        public static dynamic RdWrJsonFile(String fileName)
        {
            //To obtain the current solution path/project path
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            //Append the html report file to current project path
            string filepath = projectPath + "\\JsonFile\\" + fileName + ".json";
            string readResult = string.Empty;
            using (StreamReader r = new StreamReader(filepath))
            {
                var json = r.ReadToEnd();
                var jobj = JObject.Parse(json);
                readResult = jobj.ToString();
                foreach (var item in jobj.Properties())
                {
                    item.Value = item.Value.ToString();
                }
            }

            String test = readResult;
            dynamic data = JObject.Parse(test);

            return data;
        }

        // Read Folder Name and File Name
        public static String ReadFile(String folderName, String fileName)
        {
            //To obtain the current solution path/project path
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;

            //Append the html report file to current project path
            string filepath = projectPath + "\\" + folderName + "\\" + fileName;
            return filepath;
        }
    }
    
}
