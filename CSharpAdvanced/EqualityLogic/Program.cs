﻿using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class Program
    {
        static void Main()
        {
            var sortedSet = new SortedSet<Person>();
            var hasSet = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                sortedSet.Add(new Person(name, age));
                hasSet.Add(new Person(name, age));
            }
            
            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hasSet.Count);
        }
    }
}
