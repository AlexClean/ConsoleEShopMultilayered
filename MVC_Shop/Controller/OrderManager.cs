using MVC_Shop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_Shop.Controller
{
    class OrderManager
    {
        public static void MakeOrder()
        {
            Console.Write("Введите название продукта>");
            string product_name = Console.ReadLine();
            Product product = Storage.FindProduct(product_name);
            Console.Write("Введите количество>");
            string enter = "";
            int result = -1;
            do
            {
                enter = Console.ReadLine();
                if(int.TryParse(enter, out result))
                {
                    if (result < 0)
                        Console.WriteLine("Количество не может быть меньше 0");
                    else if (result == 0)
                    {
                        Console.WriteLine("Вы ввели 0, пожалуйста повторите ввод");
                    }
                    else
                        break;
                }
                else
                    Console.WriteLine("Введите целое число");
                
            } while (true);
            Order order = new Order(product);
            order.Count = result;
            AccountManager.CurrentAccount.AddOrder(order);
            Console.WriteLine("Ваш заказ добавлен в список");
            Console.WriteLine("Нажмите любую клавишу для того, чтобы продолжить");
            Console.ReadKey();

        }
        public static int CheckMyOrders()
        {
            if(AccountManager.CurrentAccount.order_list == null)
            {
                //Console.WriteLine("You have no orders yet. Make order first to change it Staus");
                return 0;
            }
            else if(AccountManager.CurrentAccount.order_list.Count != 0)
            {
                Console.WriteLine("Список заказов");
                for (int i = 0; i < AccountManager.CurrentAccount.order_list.Count; i++)
                {
                    Console.WriteLine(i + 1 + ") " + AccountManager.CurrentAccount.order_list[i]);
                }
                return AccountManager.CurrentAccount.order_list.Count;
            }
            else
                Console.WriteLine("У вас ещё нет ни одного заказа");
            return 0;
        }
        public static void CompleteOrder()
        {
            if (AccountManager.CurrentAccount.order_list == null)
            {
                Console.WriteLine("У вас ещё нет ни одного заказа");
                PressToContinue();
                return;
            }
                
            if(AccountManager.CurrentAccount.order_list.Count!=0)
            {
                CheckMyOrders();
            }
            Console.WriteLine($"Какой из {AccountManager.CurrentAccount.order_list.Count} заказов вы хотите Завершить?");
            Console.Write("выберите(введите порядковый номер)>");
            string input = Console.ReadLine();
            int index;
            if(int.TryParse(input, out index))
            {
                if(index <= 0)
                {
                    Console.WriteLine("Число должно быть больше 0");
                    PressToContinue();
                    return;
                }
                else
                {
                    Console.WriteLine("Вы хотите отменить заказ?(y/n)");
                    ConsoleKey key = Console.ReadKey().Key;
                    if(key == ConsoleKey.Y)
                    {
                        AccountManager.CurrentAccount.order_list[index - 1].Status = OrderStatus.CanceledByUser;
                        Console.WriteLine("Вы успешно изменили статус заказа на \"Canceled\"");
                        PressToContinue();
                    }
                    else if(key == ConsoleKey.N)
                    {
                        Console.WriteLine("Чтобы изменить статус заказа на Completed нажмите \"y\"");
                        key = Console.ReadKey().Key;
                        if(key  == ConsoleKey.Y)
                        {
                            AccountManager.CurrentAccount.order_list[index - 1].Status = OrderStatus.Completed;
                            Console.WriteLine("Вы успешно изменили статус заказа на \"Completed\"");
                            PressToContinue();
                        }
                        else
                        {
                            Console.WriteLine("Вы не изменили статус своего заказа");
                            PressToContinue();
                        }
                    }
                }
            }
        }
        public static void ChangeStatus()
        {
            //проверяем статус текущего Аккаунта и в зависиомсти от этого предлагем опции по изменению Статуса заказа
            if (AccountManager.CurrentAccount.Type == AccountType.RegisteredUser)
            {
                Console.WriteLine("Вы хотите изменить статус своих заказов?(y/n)");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Y)
                {
                    if(AccountManager.CurrentAccount.order_list == null && AccountManager.CurrentAccount.order_list.Count == 0)
                    {
                        Console.WriteLine("У вас ещё нет заказов");
                        PressToContinue();
                        return;
                    }
                    foreach (var order in AccountManager.CurrentAccount.order_list)
                    {
                        if (order.Status == OrderStatus.New)
                            order.Status = OrderStatus.Received;
                    }
                    Console.WriteLine("Вы только что изменили Статус New всех своих заказов на Received");
                    PressToContinue();
                }
                else if (key == ConsoleKey.N)
                {
                    PressToContinue();
                }
            }
            else if (AccountManager.CurrentAccount.Type == AccountType.Admin)
            {
                if (OrderManager.CheckMyOrders() > 0)
                {
                    Console.WriteLine("Вы хотите изменить статус своих заказов?(y/n)");
                    ConsoleKey changeStatus_key = Console.ReadKey().Key;
                    if (changeStatus_key == ConsoleKey.N)
                        return;
                    Console.WriteLine("Статус какого заказа вы хотите изменить?");
                    Console.Write("Введите номер продукта по порядку и нажмите Enter>");
                    string input = Console.ReadLine();
                    int index;
                    do
                    {
                        if (int.TryParse(input, out index))
                        {
                            if(index <= 0)
                            {
                                Console.WriteLine("Значение должно быть больше 0");
                                Console.WriteLine("Возврат в Админ Меню");
                                PressToContinue();
                                return;
                            }
                            if (index <= AccountManager.CurrentAccount.order_list.Count)
                            {
                                Console.Write("Какой Статус вы хотите установить: 1)Cancel " + "2)" +OrderStatus.Completed +" 3)"+ OrderStatus.PaymentReceived +" 4)"+ OrderStatus.Received + " 5)"+OrderStatus.Sended + "? ");
                                Console.Write("Введите номер Статуса>");
                                ConsoleKey key = Console.ReadKey().Key;
                                Console.WriteLine();
                                switch (key)
                                {
                                    case ConsoleKey.D1:
                                        AccountManager.CurrentAccount.order_list[index - 1].Status = OrderStatus.CanceledByAdmin;
                                        Console.WriteLine("Статус изменён на Cancel");
                                        break;
                                    case ConsoleKey.D2:
                                        AccountManager.CurrentAccount.order_list[index - 1].Status = OrderStatus.Completed;
                                        Console.WriteLine("Статус изменён на Completed");
                                        break;
                                    case ConsoleKey.D3:
                                        AccountManager.CurrentAccount.order_list[index - 1].Status = OrderStatus.PaymentReceived;
                                        Console.WriteLine("Статус изменён на Payment Received");
                                        break;
                                    case ConsoleKey.D4:
                                        AccountManager.CurrentAccount.order_list[index - 1].Status = OrderStatus.Received;
                                        Console.WriteLine("Статус изменён на Received");
                                        break;
                                    case ConsoleKey.D5:
                                        AccountManager.CurrentAccount.order_list[index - 1].Status = OrderStatus.Sended;
                                        Console.WriteLine("Статус изменён на Sended");
                                        break;
                                    default:
                                        Console.WriteLine("Неверный ввод");
                                        break;
                                }
                                PressToContinue();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод");
                                PressToContinue();
                                break;
                            }
                        }
                    } while (true);
                }
                else
                {
                    PressToContinue();
                }
            }
            else
            {
                Console.WriteLine("Войдите в аккаунт, чтобы менять статус заказа");
                PressToContinue();
            }
        }
        private static void PressToContinue()
        {
            Console.WriteLine("Нажмите любую клавишу для того, чтобы продолжить");
            Console.ReadKey();
        }
    }
}
