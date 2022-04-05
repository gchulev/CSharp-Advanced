using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>(input.Reverse());
            int sum = 0;
            string currentSign = string.Empty;
            for (int i = 0; i < stack.Count; i++)
            {
                string item = stack.Pop();
                if (item == "-")
                {
                    currentSign = "-";
                }
                else if (item == "+")
                {
                    currentSign = "+";
                }
                else
                {
                    if (currentSign == "-")
                    {
                        sum -= int.Parse(item);
                    }
                    else if (currentSign == "+")
                    {
                        sum += int.Parse(item);
                    }
                    else
                    {
                        sum += int.Parse(item);
                    }
                }
                i--;
            }
            Console.WriteLine(sum);
        }
    }
}
