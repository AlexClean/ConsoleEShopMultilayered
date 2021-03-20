using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MVC_Shop.Controller
{
    public class MenuForRegistered //:IMenu, IEnumerable<MenuItem>
    {
        static List<MenuItem> menu_for_registered = new List<MenuItem>()
        {
            new MenuItem("Меню зарегистрированного пользователя"),
            new MenuItem("1. Показать список продуктов"),
            new MenuItem("2. Найти продукт"),
            new MenuItem("3. Новый заказ"),
            new MenuItem("4. Оформление заказа или отмена заказа"),
            new MenuItem("5. Посмотреть историю заказов и статуса доставки"),
            new MenuItem("6. Выход из учётной записи"),
            new MenuItem("Нажмите Esc для Выхода")
        };
        public MenuForRegistered()
        {
            menu_for_registered = new List<MenuItem>();
            menu_for_registered.Add(new MenuItem("Меню зарегистрированного пользователя"));
            menu_for_registered.Add(new MenuItem("1. Показать список продуктов"));
            menu_for_registered.Add(new MenuItem("2. Найти продукт"));
            menu_for_registered.Add(new MenuItem("3. Новый заказ"));
            menu_for_registered.Add(new MenuItem("4. Оформление заказа или отмена заказа"));
            menu_for_registered.Add(new MenuItem("5. Посмотреть историю заказов и статуса доставки"));
            menu_for_registered.Add(new MenuItem("6. Изменить персональную информацию"));
            menu_for_registered.Add(new MenuItem("6. Выход из учётной записи"));
        }
        public static void Show()
        {
            //Console.Clear();
            foreach (var item in menu_for_registered)
            {
                Console.WriteLine(item);
            }
            //return RegisteredMemberInput.Input();
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
        public IEnumerator<MenuItem> GetEnumerator()
        {
            return menu_for_registered.GetEnumerator();
        }

    }
}
