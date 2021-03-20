using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_Shop.Model
{
    public class Person
    {
        string _name;
        string _surname;
        public string Name
        {
            get => _name;
            private set
            {
                _name = value;
            }
        }
        public string Surname
        {
            get => _surname;
            private set
            {
                _surname = value;
            }
        }
        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
