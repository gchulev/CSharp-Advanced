using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main()
        {
            string expression = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            List<string> subexpressions = new List<string>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int startingBrackedIdx = stack.Pop();
                    int endBracketIdx = i;
                    int length = endBracketIdx - startingBrackedIdx + 1;
                    string subexp = expression.Substring(startingBrackedIdx, length);
                    subexpressions.Add(subexp);
                }
            }
            Console.WriteLine(string.Join($"{Environment.NewLine}", subexpressions));
        }
    }
}
