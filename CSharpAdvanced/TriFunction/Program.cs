using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();


            Func<string, int, bool> charactersSumLongerThanN = (inputString, inputNumber) =>
                    {
                        int charSum = 0;
                        for (int i = 0; i < inputString.Length; i++)
                        {
                            charSum += inputString[i];
                        }
                        if (charSum >= inputNumber)
                        {
                            return true;
                        }
                        return false;
                    };

            string nameFound = FindFirstEqualOrLongerName(input, charactersSumLongerThanN);
            Console.WriteLine(nameFound);

            string FindFirstEqualOrLongerName(List<string> inputList, Func<string, int, bool> func)
            {
                string output = string.Empty;
                foreach (string name in inputList)
                {
                    if (func(name, n))
                    {
                        output = name;
                        return output;
                    }
                }
                return output;
            }
        }
    }
}
