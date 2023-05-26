using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bll_proj.Adapters;
using kr_lib;

namespace bll_proj.BLL
{
    [System.ComponentModel.DataObject]
    public class ShoppingCartsBLL
    {
        private ShoppingCartsAdapter Adapter = new ShoppingCartsAdapter();
        private PartsAdapter PartAdapter = new PartsAdapter();
        private MetalBlanksAdapter MetalBlankAdapter = new MetalBlanksAdapter();

        public ShoppingCartsBLL()
        {
            Adapter = new ShoppingCartsAdapter();
            PartAdapter = new PartsAdapter();
            MetalBlankAdapter = new MetalBlanksAdapter();
        }

        public ShoppingCartsBLL(ShoppingCartsAdapter adapter, PartsAdapter partAdapter, MetalBlanksAdapter metalBlankAdapter)
        {
            Adapter = adapter;
            PartAdapter = partAdapter;
            MetalBlankAdapter = metalBlankAdapter;
        }

        [System.ComponentModel.DataObjectMethod
        (System.ComponentModel.DataObjectMethodType.Select, true)]

        public void AddShoppingCart(int customerID, int partID, int partCount, bool isProcessed)
        {
            ShoppingCart cart = Adapter.GetSCByCustomerAndPart(customerID, partID, isProcessed);
            if (cart == default(ShoppingCart)) 
            {
                decimal partPrice = 0;

                if (isProcessed == false)
                { partPrice = MetalBlankAdapter.GetMetalBlankByID(partID).Price; }
                else if (isProcessed == true)
                { partPrice = PartAdapter.GetPartByID(partID).TotalPrice; }
    

                Adapter.AddShoppingCart(new ShoppingCart
                {
                    ID = Adapter.GetLastID() + 1,
                    Count = partCount,
                    Price = partPrice,
                    CustomerID = customerID,
                    PartID = partID,
                    isPartProcessed = isProcessed
                });
            }  
            else if(cart.OrderID == null)
            {
                Adapter.UpdateSCPartCount(cart.ID, cart.Count + partCount);
            }
        }

        public List<ShoppingCart> GetShoppingCarts()
        {
            return Adapter.GetShoppingCarts();
        }
        public CustomerCart GetCurrentCart(int customerID)
        {
            List<ShoppingCart> customerCarts = Adapter.GetCurrentCart(customerID);

            CustomerCart res = new CustomerCart();

            res.CustomerID = customerID;

            foreach (ShoppingCart cart in customerCarts) 
            {
                if (cart.isPartProcessed == false)
                {
                    MetalBlank mb = MetalBlankAdapter.GetMetalBlankByID(cart.PartID);   
                    if (mb != null)
                    {
                        mb.Count = cart.Count;
                        res.TotalPrice += mb.Price * mb.Count;
                        res.metalBlanks.Add(mb);
                    }
                }
                else if (cart.isPartProcessed == true)
                {
                    Part p = PartAdapter.GetPartByID(cart.PartID);
                    if (p != null)
                    {
                        res.TotalPrice += p.TotalPrice;
                        res.parts.Add(p);
                    }
                }
            }
            return res;
        }

        public List<ShoppingCart>? GetSCByCustomerID(int customerID)
        {
            return Adapter.GetSCByCustomerID(customerID);
        }

        public ShoppingCart? GetSCByCustomerAndPart(int customerID, int partID, bool isProcessed)
        {
            return Adapter.GetSCByCustomerAndPart(customerID, partID, isProcessed);
        }

        public List<ShoppingCart>? GetSCByOrderID(int orderID)
        {
            return Adapter.GetSCByOrderID(orderID);
        }

        public ShoppingCart GetSCByOrderAndPartIDs(int orderID, int partID, bool isProcessed)
        {
            return Adapter.GetSCByOrderAndPartIDs(orderID, partID, isProcessed);
        }

        public ShoppingCart GetShoppingCart(int cartID)
        {
            return Adapter.GetShoppingCart(cartID);
        }

        // UPDATING BY ORDER ID AND PART ID

        public void UpdateSCPartByOrderID(int orderID, int partID, bool isProcessed, int newPartID, bool newIsProcessed)
        {
            Adapter.UpdateSCPartByOrderID(orderID, partID, isProcessed, newPartID, newIsProcessed);
        }

        public void UpdateSCPartCountByOrderID(int orderID, int partID, int count)
        {
            Adapter.UpdateSCPartCountByOrderID(orderID, partID, count);
        }

        public void UpdateSCPriceByOrderID(int orderID, int partID, decimal newPrice)
        {
            Adapter.UpdateSCPriceByOrderID(orderID, partID, newPrice);
        }

        // UPDATING BY SHOPPING CART ID

        public void UpdateSCOrderID(int cartID, int newOrderID)
        {
            Adapter.UpdateSCOrderID(cartID, newOrderID);
        }

        public void UpdateSCPart(int cartID, int newPartID)
        {
            int count = Adapter.GetShoppingCart(cartID).Count;
            int partID = Adapter.GetShoppingCart(cartID).PartID;
            decimal partPrice = PartAdapter.GetPartByID(partID).TotalPrice;

            Adapter.UpdateSCPart(cartID, newPartID);
            Adapter.UpdateSCPrice(cartID, partPrice * count);
        }

        public void UpdateSCPartCount(int cartID, int newCount)
        {
            int partID = Adapter.GetShoppingCart(cartID).PartID;
            decimal partPrice = PartAdapter.GetPartByID(partID).TotalPrice;

            Adapter.UpdateSCPartCount(cartID, newCount);
            Adapter.UpdateSCPrice(cartID, partPrice * newCount);
        }

        public void UpdateSCPrice(int cartID, int partID, int newPrice)
        {
            Adapter.UpdateSCPrice(cartID, newPrice);
        }

        public void RemoveShoppingCart(int cartID)
        {
            Adapter.RemoveShoppingCart(cartID);
        }
        public void RemoveByCustomerAndPart(int customerID, int partID, bool isProcessed)
        {
            Adapter.RemoveByCustomerAndPart(customerID, partID, isProcessed);
        }
    }
}
