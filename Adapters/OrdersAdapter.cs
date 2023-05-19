using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dal_proj.DAL;
using kr_lib;

#nullable enable

namespace bll_proj.Adapters
{
    public class OrdersAdapter
    {
        private OrdersDAL DAL = new OrdersDAL();

        public void AddOrder(Order order)
        {
            DAL.AddOrder(order);
        }

        public int GetLastID()
        {
            return DAL.GetLastID();
        }

        public List<Order>? GetOrders()
        {
            return DAL.GetOrders();
        }

        public Order? GetOrderByID(int orderID)
        {
            return DAL.GetOrderByID(orderID);
        }

        public void UpdateOrderCustomer(int orderID, int newCustomerID)
        {
            DAL.UpdateOrderCustomer(orderID, newCustomerID);
        }

        public void UpdateOrderPaymentMethod(int orderID, string newPaymentMethod)
        {
            DAL.UpdateOrderPaymentMethod(orderID, newPaymentMethod);
        }

        public void RemoveOrder(int orderID)
        {
            DAL.RemoveOrder(orderID);
        }
    }
}
