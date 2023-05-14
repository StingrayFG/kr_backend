using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dal_proj.DAL;
using kr_lib;

#nullable enable

namespace bll_proj.Adapters
{
    public class ShoppingCartsTableAdapter
    {
        private ShoppingCartsTableDAL DAL = new ShoppingCartsTableDAL();

        public void AddShoppingCart(ShoppingCart shoppingCart)
        {
            DAL.AddShoppingCart(shoppingCart);
        }

        public int GetLastID()
        {
            return DAL.GetLastID();
        }

        public List<ShoppingCart>? GetShoppingCarts()
        {
            return DAL.GetShoppingCarts();
        }

        public List<ShoppingCart>? GetCurrentCart(int customerID)
        {
            return DAL.GetCurrentCart(customerID);
        }

        public List<ShoppingCart>? GetSCByCustomerID(int customerID)
        {
            return DAL.GetSCByCustomerID(customerID);
        }

        public ShoppingCart? GetSCByCustomerAndPart(int customerID, int partID, bool isProcessed)
        {
            return DAL.GetSCByCustomerAndPart(customerID, partID, isProcessed);
        }

        public List<ShoppingCart>? GetSCByOrderID(int orderID)
        {
            return DAL.GetSCByOrderID(orderID);
        }

        public ShoppingCart? GetSCByOrderAndPartIDs(int orderID, int partID, bool isProcessed)
        {
            return DAL.GetSCByOrderAndPartIDs(orderID, partID, isProcessed);
        }

        public ShoppingCart? GetShoppingCart(int cartID)
        {
            return DAL.GetShoppingCart(cartID);
        }

        // UPDATING BY ORDER ID AND PART ID

        public void UpdateSCPartByOrderID(int orderID, int partID, bool isProcessed, int newPartID, bool newIsProcessed)
        {
            DAL.UpdateSCPartByOrderID(orderID, partID, isProcessed, newPartID, newIsProcessed);
        }

        public void UpdateSCPartCountByOrderID(int orderID, int partID, int newCount)
        {
            DAL.UpdateSCPartCountByOrderID(orderID, partID, newCount);
        }

        public void UpdateSCPriceByOrderID(int orderID, int partID, decimal newPrice)
        {
            DAL.UpdateSCPriceByOrderID(orderID, partID, newPrice);
        }

        // UPDATING BY SHOPPING CART ID

        public void UpdateSCOrderID(int cartID, int newOrderID)
        {
            DAL.UpdateSCOrderID(cartID, newOrderID);
        }

        public void UpdateSCPart(int cartID, int newPartID)
        {
            DAL.UpdateSCPart(cartID, newPartID);
        }

        public void UpdateSCPartCount(int cartID, int newCount)
        {
            DAL.UpdateSCPartCount(cartID, newCount);    
        }

        public void UpdateSCPrice(int cartID, decimal newPrice)
        {
            DAL.UpdateSCPrice(cartID, newPrice);
        }

        public void RemoveShoppingCart(int cartID)
        {
            DAL.RemoveShoppingCart(cartID);
        }

        public void RemoveByCustomerAndPart(int customerID, int partID, bool isProcessed)
        {
            DAL.RemoveByCustomerAndPart(customerID, partID, isProcessed);
        }
    }
}
