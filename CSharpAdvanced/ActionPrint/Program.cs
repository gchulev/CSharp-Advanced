using System;

namespace ActionPrint
{
    internal class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Action<string> printAction = Print;

            foreach (string item in input)
            {
                printAction(item);
            }
        }

        public static void Print(string str)
        {
            Console.WriteLine(str);
        }
    }
}
