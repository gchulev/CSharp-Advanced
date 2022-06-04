using System;
using System.Linq;
using System.Collections.Generic;

namespace PredicateParty_
{
    internal class PredicateParty
    {
        static void Main()
        {
            List<string> people = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string inputCommand = Console.ReadLine();
                string command = inputCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];

                if (command.Equals("Party!"))
                {
                    break;
                }

                Predicate<string> filter = str =>
                {
                    string cmd = inputCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];
                    string argument = inputCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2];

                    if (cmd.Equals("StartsWith"))
                    {
                        if (!str.StartsWith(argument))
                        {
                            return false;
                        }
                        return true;
                    }
                    else if (cmd.Equals("EndsWith"))
                    {
                        if (!str.EndsWith(argument))
                        {
                            return false;
                        }
                        return true;
                    }
                    else if (cmd.Equals("Length"))
                    {
                        if (!(str.Length == int.Parse(argument)))
                        {
                            return false;
                        }
                        return true;
                    }
                    return false;
                };

                if (command.Equals("Remove"))
                {
                    people.RemoveAll(filter);
                }
                else if (command.Equals("Double"))
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        string person = people[i];
                        if (filter(person))
                        {
                            people.Insert(i + 1, person);
                            i++;
                        }
                    }
                }
            }
            if (people.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
