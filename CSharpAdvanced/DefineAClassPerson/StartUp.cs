using System;

namespace DefiningClasses

{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);

                var currentPerson = new Person(name, age);
                family.AddMember(currentPerson);
            }

            Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}"); 
        }
    }
}
