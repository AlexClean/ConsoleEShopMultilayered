using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_Shop.Model
{
    public enum OrderStatus { New, CanceledByAdmin, PaymentReceived, Sended, CanceledByUser, Received, Completed, }
    public class Order
    {
        Product _product;
        int _count;
        OrderStatus _status;
        public Product Product
        {
            get => _product;
        }
        public int Count
        {
            get => _count;
            set
            {
                _count = value;
            }
        }
        public OrderStatus Status
        {
            get => _status;
            set
            {
                _status = value;
            }
        }
        public Order(Product product)
        {
            _product = product;
        }
        public static bool operator ==(Order first, Order second)
        {
            //if (first.Account.Login == second.Account.Login)
            //    return true;
            return false;
        }
        public static bool operator !=(Order first, Order second)
        {
            //if (first.Account.Login == second.Account.Login)
            //    return false;
            return true;
        }
        public override string ToString()
        {
            return "Product name is " + Product.Name + " price is " + Product.Price + " status " + Status;
        }
    }
}
