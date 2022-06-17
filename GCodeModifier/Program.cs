using System;
using System.Collections.Generic;
using System.IO;


namespace GCodeModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string textFile = "D:\\p1.min";
            var read = File.ReadAllLines(textFile);
            string changedFile = "D:\\p11.min";
            //Console.Write("Get file path: ");
            //string textFile = Console.ReadLine();
            //Console.Write("Get changed file path: ");
            //string changedFile = Console.ReadLine();

            GCodeModify gCodeModify = new GCodeModify();

            var a = gCodeModify.GetAllToolChanges(textFile);
            var b = gCodeModify.PutToolChangesToFile(a, read);

            foreach (var item in b)
            {
                Console.WriteLine(b);
            }

            var c = b.ToString();

            foreach (var item in c)
            {
                Console.WriteLine(c);
            }

            //var file = gCodeModify.ReadFile(textFile);
            //var modify = gCodeModify.ModifyFile(file);

            //File.WriteAllLines(changedFile, modify);
        }
    }
}
