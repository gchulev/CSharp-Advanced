using System;
using System.Collections.Generic;

namespace Reverse_Strings
{
    internal class Program
    {
        static void Main()
        {
            Stack<string> stack = new Stack<string>();
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i].ToString());
            }
            foreach (string item in stack)
            {
                Console.Write(item);
            }
        }
    }
}
