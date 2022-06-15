using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int CompareTo([AllowNull] Person other)
        {
            if (other == null)
            {
                return 1;
            }
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            Person p = (Person)obj;
            return p.Name.ToLower() == Name.ToLower() && p.Age == Age;
        }

        public override int GetHashCode()
        {
            return this.Name.ToLower().GetHashCode() ^ this.Age.GetHashCode();
        }
    }
}
