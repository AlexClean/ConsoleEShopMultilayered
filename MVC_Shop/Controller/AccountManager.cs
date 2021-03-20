using System;
using System.Collections.Generic;
using System.Text;
using MVC_Shop.Model;

namespace MVC_Shop.Controller
{
    public class AccountManager
    {
        static List<Account> accounts = new List<Account>()
        {
            new Account("admin", "admin", AccountType.Admin),
            new Account("Alex", "1221")
        };
        static Account _current = null;
        public static Account CurrentAccount
        {
            get => _current;
            set
            {
                _current = value;
            }
        }
        public AccountManager()
        {
            
        }
        public static bool RegisterAccount()
        {
            Console.WriteLine("Чтобы зарегистрировать Аккаунт введите Login и password");
            Console.Write("Введите Login>");
            string login = Console.ReadLine();
            Console.Write("Введите Password>");
            string password = Console.ReadLine();
            foreach (var account in accounts)
            {
                if(account.Login == login)
                {
                    Console.WriteLine("Аккаунт с таким Login уже существует. Войдите в аккаунт");
                    return false;
                }
            }
            Account temp_account = new Account(login, password);
            accounts.Add(temp_account);
            Console.WriteLine("Аккаунт был успешно создан");
            return true;
        }
        public static AccountType EnterToAccount(string login, string password)
        {
            foreach (var account in accounts)
            {
                if (account.Login == login && account.Password == password)
                {
                    CurrentAccount = account;
                    return account.Type;
                }
                   
            }
            Console.WriteLine("Неверный Login или password");
            return AccountType.Guest;
        }
        
        private static void PressToContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
