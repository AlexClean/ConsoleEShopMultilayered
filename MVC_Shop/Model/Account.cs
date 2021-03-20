using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_Shop.Model
{
    public enum AccountType { Admin, RegisteredUser, Guest};
    public class Account
    {
        Person _person;
        public readonly List<Order> order_list;
        AccountType _type;
        string _login;
        string _password;
        public string Login
        {
            get => _login;
            private set
            {
                _login = value;
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
            }
        }
        public AccountType Type
        {
            get => _type;
            set
            {
                _type = value;
            }
        }
        public Account(string login, string password)
        {
            Login = login;
            _password = password;
            Type = AccountType.RegisteredUser;
            order_list = new List<Order>();
        }
        public Account(string login, string password, AccountType type)
        {
            Login = login;
            _password = password;
            Type = type;
            order_list = new List<Order>();
        }
        public Account(Person person, string login, string password)
        {
            _person = person;
            Login = login;
            Password = password;
            order_list = new List<Order>();
        }
        public bool CheckPassword(string password)
        {
            if (_password.Equals(password))
                return true;
            return false;
        }
        public bool CheckAccount(string login, string password)
        {
            if (Login.Equals(login) && _password.Equals(password))
                return true;
            return false;
        }
        public void SetPersonalInfo(Person person)
        {
            this._person = person;
        }
        public void AddOrder(Order order)
        {
            if (order != null)
                order_list.Add(order);
        }
    }
}
