using System;

namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            var fileContent = File.ReadAllLines(inputFilePath);
            int lineCounter = 1;
            var outputList = new List<string>();

            foreach (string line in fileContent)
            {
                int charCount = line.Count(x => char.IsLetter(x));
                int punctuationMarksCount = line.Count(x => char.IsPunctuation(x));
                outputList.Add($"Line {lineCounter}: {line} ({charCount})({punctuationMarksCount})");
                lineCounter++;
            }

            File.WriteAllLines(outputFilePath, outputList);
        }
    }
}
