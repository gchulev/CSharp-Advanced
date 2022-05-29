using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace EvenLines
{
    using System.Linq;
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));

        }

        public static string ProcessLines(string inputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            var strBuilder = new StringBuilder();
            int counter = 0;

            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    
                    Regex rgx = new Regex(@"[-,.!?]");

                    if (counter % 2 == 0)
                    {
                        line = rgx.Replace(line, "@");
                        string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        for ( int i = words.Length - 1; i >= 0 ; i--)
                        {
                            strBuilder.Append($"{words[i]} ");
                        }
                        strBuilder.Append('\n');
                    }
                    counter++;
                    line = reader.ReadLine();
                }
            }
            return strBuilder.ToString();
        }
    }
}
