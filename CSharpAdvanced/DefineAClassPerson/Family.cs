using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> _people = new List<Person>();

        public List<Person> People
        {
            get
            {
                return _people;
            }
            set
            {
                _people = value;
            }
        }

        public Family()
        {
            People = _people;
        }


        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestMember = People.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestMember;
        }
    }
}
