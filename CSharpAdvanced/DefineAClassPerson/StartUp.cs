using System;

namespace DefiningClasses

{
    public class StartUp
    {
        static void Main()
        {
            string name = "Peter";
            int age = 45;
            Person person = new Person(name, age);
            Person anotherPerson = new Person();
            Person thirdPerson = new Person("Michael", 24);
            Person fourthPerson = new Person()
            {
                Name = "Josh",
                Age = 70
            };
        }
    }
}
