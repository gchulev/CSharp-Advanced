using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main()
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0].Equals("END"))
                {
                    break;
                }
                string name = input[0];
                int age = int.Parse(input[1]);
                string town = input[2];
                people.Add(new Person(name, age, town));
            }

            int indexOfPersonToComapre = int.Parse(Console.ReadLine());
            var personTocompare = people[indexOfPersonToComapre - 1];
            int matchesFound = 0;
            int notEqual = 0;

            foreach (Person p in people)
            {
                if (p.CompareTo(personTocompare) == 0)
                {
                    matchesFound++;
                }
                else
                {
                    notEqual++;
                }
            }
            if (matchesFound > 1)
            {
                Console.WriteLine($"{matchesFound} {notEqual} {people.Count}");
                return;
            }
            Console.WriteLine("No matches");
        }
    }
}
