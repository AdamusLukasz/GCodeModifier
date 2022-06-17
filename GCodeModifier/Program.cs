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
            GCodeModify gCodeModify = new GCodeModify();
            var list = gCodeModify.GetListOfTools(textFile);
            var modify = gCodeModify.PutToolChangesToFile(list, read);
            File.WriteAllLines(changedFile, modify);
        }
    }
}
