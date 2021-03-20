using System;
using System.Collections.Generic;
using System.Text;
using MVC_Shop.Controller;
using MVC_Shop.Model;

namespace MVC_Shop.View
{
    public class Show
    {
        public static void ShowProductsList(Storage storage)
        {
            Storage.ShowProductsList();
        }
        public static void ShowRegistration()
        {

        }
        public static void ShowMenu(IMenu menu)
        {
            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }
        }
    }
}
