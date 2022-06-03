using System;

namespace KnightsOfHonor
{
    internal class KnightsOfHonor
    {
        static void Main()
        {
            string[] collection = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string> action = x => Console.WriteLine($"Sir {x}");

            foreach (string item in collection)
            {
                action(item);
            }
        }
    }
}
