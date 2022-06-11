using System;

namespace Threeuple
{
    public class StartUp
    {
        static void Main()
        {
            string[] input1 = Console.ReadLine().Split();
            var threeuple1 = new Threeuple<string, string, string>($"{input1[0]} {input1[1]}", input1[2] , input1.Length > 4 ? $"{input1[3]} {input1[4]}" : input1[3]);

            string[] input2 = Console.ReadLine().Split();
            var threeuple2 = new Threeuple<string, int, bool>(input2[0], int.Parse(input2[1]), input2[2] == "drunk" ? true : false);

            string[] input3 = Console.ReadLine().Split();
            var threeuple3 = new Threeuple<string, decimal, string>(input3[0], decimal.Parse(input3[1]), input3[2]);

            Console.WriteLine($"{threeuple1.Item1} -> {threeuple1.Item2} -> {threeuple1.Item3}");
            Console.WriteLine($"{threeuple2.Item1} -> {threeuple2.Item2} -> {threeuple2.Item3}");
            Console.WriteLine($"{threeuple3.Item1} -> {threeuple3.Item2:f1} -> {threeuple3.Item3}");
        }
    }
}
