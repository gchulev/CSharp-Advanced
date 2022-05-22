using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> inputStack = new Stack<string>();
            string text = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string inputCommand = Console.ReadLine();
                int cmd = int.Parse(inputCommand.Split(' ')[0]);

                if (cmd == 1)
                {
                    string str = inputCommand.Split(' ')[1];
                    text = $"{text}{str}";
                    inputStack.Push(text);
                }
                else if (cmd == 2)
                {
                    int numOfElementsToRemove = int.Parse(inputCommand.Split(' ')[1]);
                    text = text.Remove(text.Length - numOfElementsToRemove, numOfElementsToRemove);
                    inputStack.Push(text);
                }
                else if (cmd == 3)
                {
                    int index = int.Parse(inputCommand.Split(' ')[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (cmd == 4)
                {
                    inputStack.Pop();
                    text = inputStack.Count > 0 ? inputStack.Peek() : string.Empty;
                }
            }
        }
    }
}
