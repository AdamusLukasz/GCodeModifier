using System;
using System.Collections.Generic;
using System.IO;

namespace GCodeModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string textFile = @"D:\P1.txt";
            string[] lines = File.ReadAllLines(textFile);
            var numberOfTLines = new List<int>();
            var listOfTLines = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains('T'))
                {
                    numberOfTLines.Add(i);
                    listOfTLines.Add(lines[i].Substring(0, 2));
                }
            }
            foreach (var item in numberOfTLines)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            int count = 0;
            foreach (var item in lines)
            {
                if (item.Contains('T'))
                {
                    Console.WriteLine(item + "\n" + listOfTLines[count]);
                    count += 1;

                }
                else
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
