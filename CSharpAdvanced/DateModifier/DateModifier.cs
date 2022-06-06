using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
    public class DateModifier
    {
        private DateTime _firstDate;
        private DateTime _secondDate;

        public DateTime FirstDate { get; set; }
        public DateTime SecondDate { get; set; }

        public DateModifier(string date1, string date2)
        {
            FirstDate = DateTime.Parse(date1);
            SecondDate = DateTime.Parse(date2);
        }

        public void CalculateDateDifference(string date1, string date2)
        {
            DateModifier modifier = new DateModifier(date1, date2);
            double dateDiff = Math.Abs(modifier.FirstDate.Subtract(modifier.SecondDate).TotalDays);
            Console.WriteLine(dateDiff);
        }
    }
}
