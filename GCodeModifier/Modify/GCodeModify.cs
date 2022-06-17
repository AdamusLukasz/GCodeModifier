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
        public List<string> GetListOfTools(string path)
        {
            string[] file = File.ReadAllLines(path);
            var listOfTools = new List<string>();
            int lengthOfFile = file.Length;
            for (int j = 0; j < lengthOfFile; j++)
            {
                var line = file[j];
                if (line == String.Empty)
                {
                    continue;
                }
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
            }
            return listOfTools;
        }
        public string[] PutToolChangesToFile(List<string> listOfTools, string[] fileToModify)
        {
            List<string> newFile = new List<string>();
            int count = 1;
            for (int i = 0; i < fileToModify.Length; i++)
            {
                var getLine = fileToModify[i];
                if (getLine == String.Empty)
                {
                    continue;
                }
                char firstCharOfLine = getLine[0];

                if (firstCharOfLine == '(')
                {
                    newFile.Add(getLine);
                    continue;
                }
                if (getLine.Contains('T'))
                {
                    if (count == listOfTools.Count)
                    {
                        newFile.Add(getLine);
                        newFile.Add(listOfTools[0]);
                        continue;
                    }
                    else
                    {
                        newFile.Add(getLine);
                        newFile.Add(listOfTools[count]);
                        count += 1;
                        continue;
                    }
                }
                newFile.Add(getLine);
            }
            return newFile.ToArray();
        }
    }
}
