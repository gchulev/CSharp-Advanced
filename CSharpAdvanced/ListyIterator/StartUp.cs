using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main()
        {
            var listIterator = new ListyIterator<string>(new List<string>());

            while (true)
            {
                List<string> input = Console.ReadLine().Split().ToList();
                //string[] input = Console.ReadLine().Split();
                string command = input[0];

                if (command.Equals("END"))
                {
                    break;
                }

                if (command.Equals("Create"))
                {
                    if (input.Count > 1)
                    {
                        var outputList = input.Where(elm => input.IndexOf(elm) > 0);
                        foreach (string element in outputList)
                        {
                            listIterator.Items.Add(element);
                        }
                    }

                }
                else if (command.Equals("Move"))
                {
                    Console.WriteLine(listIterator.Move());
                }
                else if (command.Equals("Print"))
                {
                    listIterator.Print();
                }
                else if (command.Equals("HasNext"))
                {
                    Console.WriteLine(listIterator.HasNext());
                }
            }

        }
    }
}
