using System;
using MVC_Shop.View;
using MVC_Shop.Controller;
using MVC_Shop.Model;
using System.Collections.Generic;

namespace MVC_Shop
{
    class Test
    {
        public static void Example()
        { }
    }
    class Program
    {
        delegate void ShowAdminMenu();
        static void Main(string[] args)
        {
            //ShowAdminMenu showAdmMen;
            //Storage storage = new Storage();
            //GuestMenu guestMenu = new GuestMenu();
            //MenuForRegistered menu = new MenuForRegistered();
            //AdminMenu adminMenu = new AdminMenu();
            //showAdmMen = menu.Show;
            //Show.ShowMenu(guestMenu);
            GuestMenu.Show();
            GuestInput.Input();
            
        }
    }
}
