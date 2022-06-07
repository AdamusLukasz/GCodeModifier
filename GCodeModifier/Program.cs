using System;
using System.Collections.Generic;
using System.IO;

namespace GCodeModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Get file path: ");
            string textFile = Console.ReadLine();
            Console.Write("Get changed file path: ");
            string changedFile = Console.ReadLine();
            string[] lines = File.ReadAllLines(textFile);
            List<string> newFile = new List<string>();
            var numberOfTLines = new List<int>();
            var listOfTLines = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains('T'))
                {
                    numberOfTLines.Add(i);
                    int lenghtOfLine = lines[i].Length - 1;
                    int indexOfFirstSpacebar = lines[i].IndexOf(' ');
                    string removeFirstSpacebar = lines[i].Substring(indexOfFirstSpacebar + 1);
                    int indexOfSecondSpacebar = removeFirstSpacebar.IndexOf(' ');
                    int indexOfT = lines[i].IndexOf('T');
                    listOfTLines.Add(lines[i].Substring(indexOfT, indexOfSecondSpacebar));
                }
            }
            int count = 1;
            foreach (var item in lines)
            {
                if (count == numberOfTLines.Count)
                {
                    count = 0;
                }
                if (item.Contains('T'))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    newFile.Add(item);

                    newFile.Add(listOfTLines[count]);

                    Console.WriteLine(item + "\n" + listOfTLines[count]);
                    Console.ForegroundColor = ConsoleColor.White;
                    count += 1;
                }
                else
                {
                    Console.WriteLine(item);
                    newFile.Add(item);

                }

            }

            File.WriteAllLines(changedFile, newFile.ToArray());
        }
    }
}
