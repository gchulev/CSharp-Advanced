using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses

{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            //Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);
                var currentPerson = new Person(name, age);
                people.Add(currentPerson);
                //family.AddMember(currentPerson);
            }

            //Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}"); 

            var output = people.Where(x => x.Age > 30).OrderBy(y => y.Name).ToList();

            foreach (Person p in output)
            {
                Console.WriteLine($"{p.Name} - {p.Age}");
            }

        }
    }
}
