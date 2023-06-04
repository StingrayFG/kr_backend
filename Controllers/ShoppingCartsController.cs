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
    [Route("shoppingcarts")]
    [ApiExplorerSettings(GroupName = "shoppingcarts")]
    public class ShoppingCartsController : Controller
    {

        ShoppingCartsBLL BLL = new ShoppingCartsBLL();

        [HttpPut]
        [Route("add")]
        public void AddShoppingCart(int customerID, int partID, int partCount, bool isProcessed)
        {
            BLL.AddShoppingCart(customerID, partID, partCount, isProcessed);
        }

        [HttpGet]
        [Route("get_all")]
        public List<ShoppingCart> GetShoppingCarts()
        {
            return BLL.GetShoppingCarts();
        }

        [HttpGet]
        [Route("get_current_cart")]
        public CustomerCart GetCurrentCart(int customerID)
        {
            return BLL.GetCurrentCart(customerID);
        }

        [HttpGet]
        [Route("get_by_customer_id")]
        public List<ShoppingCart>? GetSCByCustomerID(int customerID)
        {
            return BLL.GetSCByCustomerID(customerID);
        }

        [HttpGet]
        [Route("get_by_customer_and_part")]
        public ShoppingCart? GetSCByCustomerAndPart(int customerID, int partID, bool isProcessed)
        {
            return BLL.GetSCByCustomerAndPart(customerID, partID, isProcessed);
        }

        [HttpGet]
        [Route("get_by_order_id")]
        public List<ShoppingCart>? GetSCByOrderID(int orderID)
        {
            return BLL.GetSCByOrderID(orderID);
        }

        [HttpGet]
        [Route("get_by_order_and_part")]
        public ShoppingCart GetSCByOrderAndPartIDs(int orderID, int partID, bool isProcessed)
        {
            return BLL.GetSCByOrderAndPartIDs(orderID, partID, isProcessed);
        }

        [HttpGet]
        [Route("get_by_cart_id")]
        public ShoppingCart GetShoppingCart(int cartID)
        {
            return BLL.GetShoppingCart(cartID);
        }

        // UPDATING BY ORDER ID AND PART ID

        [HttpPatch]
        [Route("patch_part_by_order_and_part_ids")]
        public void UpdateSCPartByOrderID(int orderID, int partID, bool isProcessed, int newPartID, bool newIsProcessed)
        {
            BLL.UpdateSCPartByOrderID(orderID, partID, isProcessed, newPartID, newIsProcessed);
        }

        [HttpPatch]
        [Route("patch_count_by_order_and_part_ids")]
        public void UpdateSCPartCountByOrderID(int orderID, int partID, int count)
        {
            BLL.UpdateSCPartCountByOrderID(orderID, partID, count);
        }

        [HttpPatch]
        [Route("patch_price_by_order_and_part_ids")]
        public void UpdateSCPriceByOrderID(int orderID, int partID, decimal newPrice)
        {
            BLL.UpdateSCPriceByOrderID(orderID, partID, newPrice);
        }

        // UPDATING BY SHOPPING CART ID

        [HttpPatch]
        [Route("patch_order_by_cart_id")]
        public void UpdateSCOrderID(int cartID, int newOrderID)
        {
            BLL.UpdateSCOrderID(cartID, newOrderID);
        }

        [HttpPatch]
        [Route("patch_part_by_cart_id")]
        public void UpdateSCPart(int cartID, int newPartID)
        {
            BLL.UpdateSCPart(cartID, newPartID);
        }

        [HttpPatch]
        [Route("patch_count_by_cart_id")]
        public void UpdateSCPartCount(int cartID, int newCount)
        {
            BLL.UpdateSCPartCount(cartID, newCount);
        }

        [HttpPatch]
        [Route("patch_price_by_cart_id")]
        public void UpdateSCPrice(int cartID, int partID, int newPrice)
        {
            BLL.UpdateSCPrice(cartID, partID, newPrice);
        }

        [HttpDelete]
        [Route("delete_by_id")]
        public void RemoveShoppingCart(int cartID)
        {
            BLL.RemoveShoppingCart(cartID);
        }

        [HttpDelete]
        [Route("delete_by_customer_and_part")]
        public void RemoveByCustomerAndPart(int customerID, int partID, bool isProcessed)
        {
            BLL.RemoveByCustomerAndPart(customerID, partID, isProcessed);
        }

    }
}
