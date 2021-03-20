using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MVC_Shop.Controller
{
    public class GuestMenu
    {
        static List<MenuItem> start_menu = new List<MenuItem>()
        {
            new MenuItem("Главное Меню"),
            new MenuItem("1. Показать список продуктов"),
            new MenuItem("2. Найти продукт"),
            new MenuItem("3. Зарегистрировать учётную запись"),
            new MenuItem("4. Вход в учётную запись"),
            new MenuItem("Нажмите Esc для Выхода")
        };
        public GuestMenu()
        {
           
        }

        public IEnumerator<MenuItem> GetEnumerator()
        {
            return start_menu.GetEnumerator();
        }

        public static void Show()
        {
            //Console.Clear();
            foreach (var item in start_menu)
            {
                Console.WriteLine(item);
            }
            //GuestInput.Input();
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
    }
}
