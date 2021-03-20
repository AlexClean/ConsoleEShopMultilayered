using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_Shop.Controller
{
    public class MenuItem
    { 
        string _name;
        public string Name
        {
            get => _name;
            private set
            {
                _name = value;
            }
        }
        public MenuItem(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return _name;
        }
    }
}
