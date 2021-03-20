using System;
using System.Collections.Generic;
using System.Text;
using MVC_Shop.Model;

namespace MVC_Shop.Controller
{
    public class RegisteredMemberInput
    {
        public static ConsoleKey Input()
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
                    OrderManager.MakeOrder();
                    Console.Clear();
                    MenuForRegistered.Show();
                }
                else if (key == ConsoleKey.D4)
                {
                    
                    OrderManager.CompleteOrder();
                }
                else if (key == ConsoleKey.D5)
                {
                    OrderManager.CheckMyOrders();
                    OrderManager.ChangeStatus();
                }
                else if (key == ConsoleKey.D6)
                    Console.WriteLine("Exit from current Account");
            } while (key != ConsoleKey.Escape && key != ConsoleKey.D6);
            return key;
        }
    }
}
