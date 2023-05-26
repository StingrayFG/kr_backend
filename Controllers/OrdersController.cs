using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;
using bll_proj.BLL;
using kr_lib;

namespace bll_proj.Controllers
{
    [ApiController]
    [Route("orders")]
    [ApiExplorerSettings(GroupName = "orders")]
    public class OrdersController : Controller
    {

        OrdersBLL BLL;

        public OrdersController()
        {
            BLL = new OrdersBLL();
        }

        public OrdersController(OrdersBLL bll)
        {
            BLL = bll;
        }

        [HttpPut]
        [Route("add")]
        public void AddOrder(int customerID, string paymentMethod)
        {
            BLL.AddOrder(customerID, paymentMethod);
        }

        [HttpGet]
        [Route("get_all")]
        public List<Order> GetOrders()
        {
            return BLL.GetOrders();
        }

        [HttpGet]
        [Route("get_by_id")]
        public Order GetOrderByID(int orderID)
        {
            return BLL.GetOrderByID(orderID);
        }

        [HttpPatch]
        [Route("patch_customer")]
        public void UpdateOrderCustomer(int orderID, int newCustomerID)
        {
            BLL.UpdateOrderCustomer(orderID, newCustomerID);
        }

        [HttpPatch]
        [Route("patch_payment_method")]
        public void UpdateOrderPaymentMethod(int orderID, string newPaymentMethod)
        {
            BLL.UpdateOrderPaymentMethod(orderID, newPaymentMethod);
        }

        [HttpDelete]
        [Route("delete_by_id")]
        public void RemoveOrder(int orderID)
        {
            BLL.RemoveOrder(orderID);
        }

    }
}
