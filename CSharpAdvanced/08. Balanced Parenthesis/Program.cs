using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> openedBrakets = new Stack<char>();
            bool balance = false;

            foreach (char braket in input)
            {
                if (braket == '{' || braket == '(' || braket == '[')
                {
                    openedBrakets.Push(braket);
                }
                else if (braket == '}' || braket == ')' || braket == ']')
                {
                    if (openedBrakets.Count > 0)
                    {
                        char lastOpenBraket = openedBrakets.Pop();

                        if (lastOpenBraket == '{' && braket == '}')
                        {
                            balance = true;
                        }
                        else if (lastOpenBraket == '(' && braket == ')')
                        {
                            balance = true;
                        }
                        else if (lastOpenBraket == '[' && braket == ']')
                        {
                            balance = true;
                        }
                        else
                        {
                            balance = false;
                            break;
                        }
                    }
                    else
                    {
                        balance = false;
                        break;
                    }
                }
                else
                {
                    balance = false;
                    break;
                }
            }
            if (balance)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
