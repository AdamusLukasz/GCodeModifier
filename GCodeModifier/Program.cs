using System;
using System.Collections.Generic;
using System.IO;


namespace GCodeModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Get file path: ");
            string textFile = Console.ReadLine();
            Console.Write("Get changed file path: ");
            string changedFile = Console.ReadLine();

            GCodeModify gCodeModify = new GCodeModify();
            var file = gCodeModify.ReadFile(textFile);
            var modify = gCodeModify.ModifyFile(file);

            File.WriteAllLines(changedFile, modify);
        }
    }
}
