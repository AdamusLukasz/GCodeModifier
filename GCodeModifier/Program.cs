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
            string changedFile = "D:\\p11.min";
            //Console.Write("Get file path: ");
            //string textFile = Console.ReadLine();
            //Console.Write("Get changed file path: ");
            //string changedFile = Console.ReadLine();

            GCodeModify gCodeModify = new GCodeModify();

            var a = gCodeModify.GetAllToolChanges(textFile);
            var b = a.ToArray();

            //a.ForEach(Console.WriteLine);


            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
            //var file = gCodeModify.ReadFile(textFile);
            //var modify = gCodeModify.ModifyFile(file);

            //File.WriteAllLines(changedFile, modify);
        }
    }
}
