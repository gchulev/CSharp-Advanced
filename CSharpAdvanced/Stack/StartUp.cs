using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        static void Main()
        {
            var stack = new CustomStack<string>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];

                if (command.Equals("END"))
                {
                    break;
                }

                if (command.Equals("Push"))
                {
                    if (input.Length > 1)
                    {
                        string[] elements = input.Select(elm => elm.Replace(",", "")).Where(c => !string.IsNullOrWhiteSpace(c)).ToArray();
                        for (int i = 1; i < elements.Length; i++)
                        {
                            stack.Push(elements[i]);
                        }
                    }
                }
                else if (command.Equals("Pop"))
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("No elements");
                    }
                }

            }

            if (stack.Count > 0)
            {
                foreach (string item in stack)
                {
                    Console.WriteLine(item);
                }
                foreach (string item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
