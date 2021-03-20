using System;
using System.Collections.Generic;
using System.Text;
using MVC_Shop.Model;

namespace MVC_Shop.Controller
{
    class AdminInput
    {
        public static ConsoleKey Input()
        {
            ConsoleKey key;
            do{
                Console.Write("выберите пункт меню>");
                key = Console.ReadKey().Key;
                Console.WriteLine();
                if (key == ConsoleKey.D1)
                    Storage.ShowProductsList();
                else if (key == ConsoleKey.D2)
                    Storage.FindProduct();
                else if (key == ConsoleKey.D3)
                {
                    OrderManager.MakeOrder();
                    Console.Clear();
                    AdminMenu.Show();
                }
                else if (key == ConsoleKey.D4)
                    OrderManager.CompleteOrder();
                else if (key == ConsoleKey.D5)
                    Console.WriteLine("Looking for Accounts info");
                else if (key == ConsoleKey.D6)
                    Storage.AddProduct();
                else if (key == ConsoleKey.D7)
                {
                    Storage.ChangeProductInfo();
                    Console.Clear();
                    AdminMenu.Show();
                }    
                else if (key == ConsoleKey.D8)
                {
                    OrderManager.ChangeStatus();
                    Console.Clear();
                    AdminMenu.Show();
                }
                else if (key == ConsoleKey.D9)
                    Console.WriteLine("Exit from current Account");
            } while (key != ConsoleKey.Escape && key != ConsoleKey.D9) ;
            return key;
        }
    }
}
