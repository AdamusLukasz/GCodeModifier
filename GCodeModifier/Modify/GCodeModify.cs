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
        public string[] ReadFile(string path)
        {
            string[] readFile = File.ReadAllLines(path);
            return readFile;
        }
        public string[] ModifyFile(string[] file)
        {
            List<string> newFile = new List<string>();
            var numberOfTLines = new List<int>();
            var listOfTLines = new List<string>();
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i].Contains('T'))
                {
                    numberOfTLines.Add(i);
                    int lenghtOfLine = file[i].Length - 1;
                    int indexOfFirstSpacebar = file[i].IndexOf(' ');
                    string removeFirstSpacebar = file[i].Substring(indexOfFirstSpacebar + 1);
                    int indexOfSecondSpacebar = removeFirstSpacebar.IndexOf(' ');
                    int indexOfT = file[i].IndexOf('T');
                    listOfTLines.Add(file[i].Substring(indexOfT, indexOfSecondSpacebar));
                }
            }
            int count = 1;
            foreach (var item in file)
            {
                if (count == numberOfTLines.Count)
                {
                    count = 0;
                }
                if (item.Contains('T'))
                {
                    //Console.ForegroundColor = ConsoleColor.Red;
                    newFile.Add(item);
                    newFile.Add(listOfTLines[count]);
                    //Console.WriteLine(item + "\n" + listOfTLines[count]);
                    //Console.ForegroundColor = ConsoleColor.White;
                    count += 1;
                }
                else
                {
                    //Console.WriteLine(item);
                    newFile.Add(item);
                }
            }
            return newFile.ToArray();
        }
    }
}
