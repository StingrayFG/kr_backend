using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bll_proj.Adapters;
using kr_lib;

namespace bll_proj.BLL
{
    [System.ComponentModel.DataObject]
    public class OrdersBLL
    {
        private OrdersAdapter Adapter;
        private ShoppingCartsAdapter ShoppingCartAdapter;

        public OrdersBLL()
        {
            Adapter = new OrdersAdapter();
            ShoppingCartAdapter = new ShoppingCartsAdapter();
        }

        public OrdersBLL(OrdersAdapter adapter, ShoppingCartsAdapter shoppingCartAdapter)
        {
            Adapter = adapter;
            ShoppingCartAdapter = shoppingCartAdapter;
        }

        [System.ComponentModel.DataObjectMethod
        (System.ComponentModel.DataObjectMethodType.Select, true)]

        public void AddOrder(int customerID, string paymentMethod)
        {
            List<ShoppingCart> cartsInOrder = ShoppingCartAdapter.GetCurrentCart(customerID);  

            decimal cartsTotalPrice = 0;
            int orderID = Adapter.GetLastID() + 1;

            foreach (ShoppingCart cart in cartsInOrder)
            {
                cartsTotalPrice += cart.Price;   
                ShoppingCartAdapter.UpdateSCOrderID(cart.ID, orderID);
            }

            Adapter.AddOrder(new Order
            {
                ID = orderID,
                CustomerID = customerID,
                OrderCreationDate = DateTime.Now,
                Price = cartsTotalPrice,
                PaymentMethod = paymentMethod
            });

        }

        public List<Order> GetOrders()
        {
            return Adapter.GetOrders();
        }

        public Order GetOrderByID(int orderID)
        {
            return Adapter.GetOrderByID(orderID);
        }

        public void UpdateOrderCustomer(int orderID, int newCustomerID)
        {
            Adapter.UpdateOrderCustomer(orderID, newCustomerID);
        }

        public void UpdateOrderPaymentMethod(int orderID, string newPaymentMethod)
        {
            Adapter.UpdateOrderPaymentMethod(orderID, newPaymentMethod);
        }

        public void RemoveOrder(int orderID)
        {
            Adapter.RemoveOrder(orderID);
        }
    }
}
