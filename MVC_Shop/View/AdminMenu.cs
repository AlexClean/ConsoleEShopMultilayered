using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MVC_Shop.Controller
{
    public class AdminMenu //:IMenu
    {
        static List<MenuItem> adminMenu = new List<MenuItem>()
        {
            new MenuItem("Меню Админа"),
            new MenuItem("1. Показать список продуктов"),
            new MenuItem("2. Найти продукт"),
            new MenuItem("3. Новый заказ"),
            new MenuItem("4. Оформление заказа"),
            new MenuItem("5. Посмотреть информацию пользователей"),
            new MenuItem("6. Добавить новый товар"),
            new MenuItem("7. Изменить информацию о товаре"),
            new MenuItem("8. Изменить статус заказа"),
            new MenuItem("9. Выход из учётной записи"),
            new MenuItem("Нажмите Esc для Выхода")
        };
        public AdminMenu()
        {
            adminMenu = new List<MenuItem>();
            adminMenu.Add(new MenuItem("Меню Админа"));
            adminMenu.Add(new MenuItem("1. Показать список продуктов"));
            adminMenu.Add(new MenuItem("2. Найти продукт"));
            adminMenu.Add(new MenuItem("3. Новый заказ"));
            adminMenu.Add(new MenuItem("4. Оформление заказа"));
            adminMenu.Add(new MenuItem("5. Посмотреть информацию пользователей"));
            adminMenu.Add(new MenuItem("6. Добавить новый товар"));
            adminMenu.Add(new MenuItem("7. Изменить информацию о товаре"));
            adminMenu.Add(new MenuItem("8. Изменить статус заказа"));
            adminMenu.Add(new MenuItem("9. Выход из учётной записи"));
            adminMenu.Add(new MenuItem("Нажмите Esc для Выхода"));
        }
        public static void Show()
        {
            //Console.Clear();
            foreach (var item in adminMenu)
            {
                Console.WriteLine(item);
            }
            //AdminInput.Input();
        }

        public IEnumerator<MenuItem> GetEnumerator()
        {
            return adminMenu.GetEnumerator();
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
    }
}
