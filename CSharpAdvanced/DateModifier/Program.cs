using System;

namespace DateModifier
{
    internal class StartUp
    {
        static void Main()
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();
            DateModifier modifier = new DateModifier(date1, date2);

            modifier.CalculateDateDifference(date1, date2);


        }
    }
}
