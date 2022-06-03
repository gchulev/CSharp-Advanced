using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    public delegate List<int> MathOperations(List<int> list, int num);
    internal class Program
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command.Equals("end"))
                {
                    break;
                }
                else if (command.Equals("add"))
                {
                    MathOperations addition = (list, num) => list.Select(x => x + num).ToList();
                    nums = addition(nums, 1);
                }
                else if (command.Equals("multiply"))
                {
                    MathOperations multiply = (list, num) => list.Select(x => x * num).ToList();
                    nums = multiply(nums, 2);
                }
                else if (command.Equals("subtract"))
                {
                    MathOperations substract = (list, num) => list.Select(x => x - num).ToList();
                    nums = substract(nums, 1);
                }
                else if (command.Equals("print"))
                {
                    Console.WriteLine(String.Join(' ', nums));
                }
            }
        }
    }
}
