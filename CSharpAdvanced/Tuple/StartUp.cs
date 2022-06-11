﻿using System;

namespace Tuple
{
    public class StartUp
    {
        static void Main()
        {
            string[] input1 = Console.ReadLine().Split();
            var tuple1 = new Tuple<string, string>($"{input1[0]} {input1[1]}", input1[2]);

            string[] input2 = Console.ReadLine().Split();
            var tuple2 = new Tuple<string, int>(input2[0], int.Parse(input2[1]));

            string[] input3 = Console.ReadLine().Split();
            var tuple3 = new Tuple<int, double>(int.Parse(input3[0]), double.Parse(input3[1]));

            Console.WriteLine($"{tuple1.Item1} -> {tuple1.Item2}");
            Console.WriteLine($"{tuple2.Item1} -> {tuple2.Item2}");
            Console.WriteLine($"{tuple3.Item1} -> {tuple3.Item2}");
        }
    }
}
