using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList
{
    public enum Sex
    {
        Male,
        Female
    }

    public class Person
    {
        public string Name;
        public int Age;
        public Sex Sex;
        public int Balance;

        public Person(string name, int age, Sex sex, int balance)
        {
            Name = name;
            Age = age;
            Sex = sex;
            Balance = balance;
        }

        public override string ToString()
        {
            return Name + " возраст: " + Age + " пол: " + (Sex == Sex.Male ? "мужской" : "женский") + " Баланс: " + Balance;
        }
    }


}
