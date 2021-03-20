using System;
using System.Collections.Generic;
using System.Text;
using MVC_Shop.Model;

namespace MVC_Shop.Controller
{
    public class GuestInput
    {
        public static void Input()
        {
            ConsoleKey key;
            do
            {
                Console.Write("выберите пункт меню>");
                key = Console.ReadKey().Key;
                Console.WriteLine();
                if (key == ConsoleKey.D1)
                    Storage.ShowProductsList();
                else if (key == ConsoleKey.D2)
                    Storage.FindProduct();
                else if (key == ConsoleKey.D3)
                {
                    AccountManager.RegisterAccount();
                }                    
                else if (key == ConsoleKey.D4)
                {
                    Console.Write("Введите свой Login>");
                    string login = Console.ReadLine();
                    Console.Write("Введите свой password>");
                    string password = Console.ReadLine();
                    AccountType type = AccountManager.EnterToAccount(login, password);
                    if (type == AccountType.Admin)
                    {
                        Console.Clear();
                        AdminMenu.Show();
                        key = AdminInput.Input();
                        if (key != ConsoleKey.Escape)
                        {
                            Console.WriteLine("Возврат в Main Menu");
                            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
                            Console.ReadKey();
                            Console.Clear();
                            GuestMenu.Show();
                        }
                    }
                    else if (type == AccountType.RegisteredUser)
                    {
                        Console.Clear();
                        MenuForRegistered.Show();
                        key = RegisteredMemberInput.Input();
                        if(key!= ConsoleKey.Escape)
                        {
                            Console.WriteLine("Возврат в Main Menu");
                            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
                            Console.ReadKey();
                            Console.Clear();
                            GuestMenu.Show();
                        }
                    }
                    
                }
            } while (key != ConsoleKey.Escape);
        }
    }
}

