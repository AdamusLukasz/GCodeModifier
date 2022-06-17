using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeModifier
{
    public class GCodeModify
    {
        public List<string> GetAllToolChanges(string path)
        {
            string[] file = File.ReadAllLines(path);
            var listOfTools = new List<string>();
            int l = file.Length;
            for (int j = 0; j < file.Length; j++)
            {
                var line = file[j];
                char firstCharOfFileLine = line[0];
                if (firstCharOfFileLine == '(')
                {
                    continue;
                }
                if (line.Contains('T'))
                {
                    int indexOfT = file[j].IndexOf('T');
                    int indexOfM = file[j].IndexOf('M');
                    int length = indexOfM - indexOfT;
                    string toolNumber = line.Substring(indexOfT, length);
                    listOfTools.Add(toolNumber);
                }
                continue;
            }
            return listOfTools;
        }
        //public string[] PutToolChangesToFile(List<string> list, string[] file)
        //{
        //    List<string> newFile = new List<string>();
        //    int count = 1;

        //    foreach (var item in list)
        //    {
        //        char c = item[0];
        //        if (c == '(')
        //        {
        //            newFile.Add(item);
        //            //continue;
        //        }
        //        if (count == listOfTools.Count)
        //        {
        //            count = 0;
        //        }
        //        if (item.Contains('T'))
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            newFile.Add(item);
        //            newFile.Add(listOfTools[count]);
        //            Console.WriteLine(item + "\n" + listOfTools[count]);
        //            Console.ForegroundColor = ConsoleColor.White;
        //            count += 1;
        //        }
        //        else
        //        {
        //            //Console.WriteLine(item);
        //            newFile.Add(item);
        //        }
        //    }
        //    return newFile.ToArray();
        //}
    }
}
