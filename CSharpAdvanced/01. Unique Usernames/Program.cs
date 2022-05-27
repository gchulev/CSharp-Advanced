using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var users = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string userName = Console.ReadLine();
                users.Add(userName);
            }

            Console.WriteLine(string.Join(Environment.NewLine, users));
        }
    }
}
