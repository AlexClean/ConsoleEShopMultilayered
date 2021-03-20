using System;
using System.Collections.Generic;
using System.Text;
using MVC_Shop.Controller;
using MVC_Shop.View;

namespace MVC_Shop.Model
{
    public class Storage
    {
        static List<Product> products = new List<Product>()
        {
            new Product("Tomato", 76.35),
            new Product("Banana", 54.18),
            new Product("Лук", 18.00),
            new Product("Морковка", 23.00),
            new Product("Овсянка", 54.25),
            new Product("Кофе",220.75)
        };
        public Storage()
        {
            products = new List<Product>();
            products.Add(new Product("Tomato", 76.35));
            products.Add(new Product("Banana", 54.18));
            products.Add(new Product("Лук", 18.00));
            products.Add(new Product("Морковка", 23.00));
            products.Add(new Product("Овсянка", 54.25));
            products.Add(new Product("Кофе",220.75));
        }
        public void Add(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            products.Add(product);
        }
        public static void ShowProductsList()
        {
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
        public static Product FindProduct(string productName = "")
        {
            string name;
            bool isFind = false;
            Product current = null;
            if (productName.Length == 0)
            {
                Console.Write("Введите название продукта, который хотите найти>");
                name = Console.ReadLine();
            }
            else
                name = productName;
            foreach (var product in products)
            {
                if(product.Name == name)
                {
                    Console.WriteLine("Есть продукт " + product.Name);
                    isFind = true;
                    current = product;
                    break;
                }
                    
            }
            if(!isFind)
            {
                Console.WriteLine("Нет продукта с таким названием");
                PressToContinue();
            }
            return current;
        }
        public static bool AddProduct()
        {
            Console.Write("Введите название продукта>");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Введите цену>");
            int atempt = 0;
            do
            {
                string price_input = Console.ReadLine();
                double price;
                if (double.TryParse(price_input, out price))
                {
                    products.Add(new Product(name, price));
                    Console.WriteLine("Вы успешно добавили новый товар");
                    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
                    Console.ReadKey();
                    return true;
                }
                else
                {
                    Console.WriteLine("Введите корректное значение(целое или дробное число через \".\")");
                    atempt++;
                    Console.WriteLine($"у вас осталось {3 - atempt} попытки");
                }

            } while (atempt <= 3);
            return false;
        }
        public static bool ChangeProductInfo()
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(i + 1 + ") " + products[i].ToString());
            }
            Console.WriteLine("Информацию о каком продукте хотите изменить?");
            
            string index_input;
            int index;
            int input_attempt = 0 ;
            do
            {
                Console.Write("введите порядковый номер>");
                index_input = Console.ReadLine();
                if(int.TryParse(index_input, out index))
                {
                    
                    if(index > 0 && index <= products.Count)
                    {
                        index--;
                        Console.Write("Введите новое название товара>");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите новую цену(целое или дробное число через \".\"");
                        string price_input;
                        double price;
                        int atempt = 0;
                        do
                        {
                            Console.Write("введите цену>");
                            price_input = Console.ReadLine();
                            if (double.TryParse(price_input,out price))
                            {
                                products[index].Name = name;
                                products[index].Price = price;
                                Console.WriteLine("Вы успешно изменили информацию о продукте");
                                PressToContinue();
                                return true;
                            }
                            else
                            {
                                Console.WriteLine("Введите корректное значение цены(целое или дробное число(дробное через \".\"");
                                atempt++;
                                Console.WriteLine($"У вас осталось {3 - atempt} попытки");
                            }
                        } while (atempt < 3);
                        products[index].Name = name;
                        Console.WriteLine("Вы успешно изменили только название продукта");
                        PressToContinue();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Такого номера не существует.Вы ввели неверный номер продукта.");
                        PressToContinue();
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели неверное значение, попробуйте ещё раз");
                    PressToContinue();
                    input_attempt++;
                }
                
            } while (input_attempt  > 0);
            return false;
        }
        private static void PressToContinue()
        {
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
            Console.ReadKey();
        }
    }
}
