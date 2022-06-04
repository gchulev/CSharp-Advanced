using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    internal class Program
    {
        static void Main()
        {
            List<string> invitations = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            var originalList = new List<string>(invitations);
            List<string> filters = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();
                string command = input.Split(';', StringSplitOptions.RemoveEmptyEntries)[0];
                if (command.Equals("Print"))
                {
                    break;
                }
                if (command.StartsWith("Add"))
                {
                    filters.Add(input);
                }
                else if (command.StartsWith("Remove"))
                {
                    filters.Remove(input.Replace("Remove", "Add"));
                }
            }
            foreach (string filter in filters)
            {
                Predicate<string> applyFilter = GetPredicate(filter);
                string cmd = filter.Split(';', StringSplitOptions.RemoveEmptyEntries)[0];

                if (cmd.StartsWith("Add"))
                {
                    invitations.RemoveAll(applyFilter);
                }
            }
            Console.WriteLine(string.Join(' ', invitations));

        }
        public static Predicate<string> GetPredicate(string inputCmd)
        {
            Predicate<string> predicate = null;

            string filterType = inputCmd.Split(';', StringSplitOptions.RemoveEmptyEntries)[1];
            string filterParameter = inputCmd.Split(';', StringSplitOptions.RemoveEmptyEntries)[2];

            if (filterType.Equals("Starts with"))
            {
                predicate = name => name.StartsWith(filterParameter);
            }
            else if (filterType.Equals("Ends with"))
            {
                predicate = name => name.EndsWith(filterParameter);
            }
            else if (filterType.Equals("Length"))
            {
                predicate = name => name.Length == int.Parse(filterParameter);
            }
            else if (filterType.Equals("Contains"))
            {
                predicate = name => name.Contains(filterParameter.ToLower()) || name.Contains(filterParameter.ToUpper());
            }
            return predicate;
        }
    }
}
