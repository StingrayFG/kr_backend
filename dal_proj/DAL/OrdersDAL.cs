using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kr_lib;

#nullable enable

namespace dal_proj.DAL
{
    public class OrdersDAL
    {
        ApplicationContext db = new ApplicationContext();

        public void AddOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public int GetLastID()
        {
            int? id = db.Orders.Max(mb => mb.ID);
            if (id == null) { return 1; }
            else { return (int)id; }
        }

        public List<Order>? GetOrders()
        {
            List<Order>? orders = db.Orders.ToList();
            return orders;
        }

        public Order? GetOrderByID(int orderID)
        {
            Order? order = (from p in db.Orders where p.ID == orderID select p).First();
            return order;
        }

        public void UpdateOrderCustomer(int orderID, int newCustomerID)
        {
            Order? order = (from o in db.Orders where o.ID == orderID select o).First();
            if (order != null)
            {
                order.CustomerID = newCustomerID;
                db.SaveChanges();
            }
        }

        public void UpdateOrderPaymentMethod(int orderID, string newPaymentMethod)
        {
            Order? order = (from o in db.Orders where o.ID == orderID select o).First();
            if (order != null)
            {
                order.PaymentMethod = newPaymentMethod;
                db.SaveChanges();
            }
        }

        public void RemoveOrder(int orderID)
        {
            Order? order = (from p in db.Orders where p.ID == orderID select p).First();
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }
    }
}
