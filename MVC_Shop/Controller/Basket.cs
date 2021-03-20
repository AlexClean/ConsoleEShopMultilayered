using MVC_Shop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_Shop.Controller
{
    class Basket
    {
        List<Order> orders;
        Order current;
        public Basket()
        {
            orders = new List<Order>();
            //current = new Order();
        }
        public Basket(Order order)
        {
            orders = new List<Order>();
            current = order;
        }
        public void Add(Order order)
        {
            if (order != null)
                orders.Add(order);
            
        }
        public void ClearBasket()
        {
            orders.Clear();
        }
        public void ChangeStatus(OrderStatus status)
        {
            //current.
        }
    }
}
