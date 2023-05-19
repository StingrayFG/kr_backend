using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kr_lib;

#nullable enable

namespace dal_proj.DAL
{
    public class ShoppingCartsDAL
    {
        ApplicationContext db = new ApplicationContext();

        public void AddShoppingCart(ShoppingCart shoppingCart)
        {
            db.ShoppingCarts.Add(shoppingCart);
            db.SaveChanges();
        }

        public int GetLastID()
        {
            int? id = db.ShoppingCarts.Max(mb => mb.ID);
            if (id == null) { return 1; }
            else { return (int)id; }
        }

        public List<ShoppingCart>? GetShoppingCarts()
        {
            List<ShoppingCart>? shoppingCarts = db.ShoppingCarts.ToList();
            return shoppingCarts;
        }

        public List<ShoppingCart>? GetCurrentCart(int customerID)
        {
            List<ShoppingCart>? shoppingCarts = (from sc in db.ShoppingCarts where ((sc.CustomerID == customerID) && (sc.OrderID == null)) select sc).ToList();
            return shoppingCarts;
        }

        public List<ShoppingCart>? GetSCByCustomerID(int customerID)
        {
            List<ShoppingCart>? shoppingCarts = (from sc in db.ShoppingCarts where ((sc.CustomerID == customerID) && (sc.OrderID == null)) select sc).ToList();
            return shoppingCarts;
        }

        public ShoppingCart? GetSCByCustomerAndPart(int customerID, int partID, bool isProcessed)
        {
            ShoppingCart? shoppingCart = (from sc in db.ShoppingCarts where ((sc.CustomerID == customerID) && (sc.PartID == partID) && (sc.isPartProcessed == isProcessed)) select sc).FirstOrDefault();
            return shoppingCart;
        }

        public List<ShoppingCart>? GetSCByOrderID(int orderID)
        {
            List<ShoppingCart>? shoppingCarts = (from sc in db.ShoppingCarts where sc.OrderID == orderID select sc).ToList();
            return shoppingCarts;
        }

        public ShoppingCart? GetSCByOrderAndPartIDs(int orderID, int partID, bool isProcessed)
        {
            ShoppingCart? shoppingCart = (from sc in db.ShoppingCarts where ((sc.OrderID == orderID) && (sc.PartID == partID) && (sc.isPartProcessed == isProcessed)) select sc).FirstOrDefault();
            return shoppingCart;
        }

        public ShoppingCart? GetShoppingCart(int cartID)
        {
            ShoppingCart? shoppingCarts = (from sc in db.ShoppingCarts where sc.ID == cartID select sc).FirstOrDefault();
            return shoppingCarts;
        }


        // UPDATING BY ORDER ID AND PART ID

        public void UpdateSCPartByOrderID(int orderID, int partID, bool isProcessed, int newPartID, bool newIsProcessed)
        {
            ShoppingCart? shoppingCart = (from sc in db.ShoppingCarts where sc.OrderID == orderID && sc.PartID == partID && sc.isPartProcessed == isProcessed select sc).FirstOrDefault();
            if (shoppingCart != null)
            {
                shoppingCart.PartID = newPartID;
                shoppingCart.isPartProcessed = newIsProcessed;
                db.SaveChanges();
            }
        }

        public void UpdateSCPartCountByOrderID(int orderID, int partID, int newCount)
        {
            ShoppingCart? shoppingCart = (from sc in db.ShoppingCarts where sc.OrderID == orderID && sc.PartID == partID select sc).First();
            if (shoppingCart != null)
            {
                shoppingCart.Count = newCount;
                db.SaveChanges();
            }
        }

        public void UpdateSCPriceByOrderID(int orderID, int partID, decimal newPrice)
        {
            ShoppingCart? shoppingCart = (from sc in db.ShoppingCarts where sc.OrderID == orderID && sc.PartID == partID select sc).First();
            if (shoppingCart != null)
            {
                shoppingCart.Price = newPrice;
                db.SaveChanges();
            }
        }

        // UPDATING BY SHOPPING CART ID

        public void UpdateSCOrderID(int cartID, int newOrderID)
        {
            ShoppingCart? shoppingCart = (from sc in db.ShoppingCarts where sc.ID == cartID select sc).First();
            if (shoppingCart != null)
            {
                shoppingCart.OrderID = newOrderID;
                db.SaveChanges();
            }
        }

        public void UpdateSCPart(int cartID, int newPartID)
        {
            ShoppingCart? shoppingCart = (from sc in db.ShoppingCarts where sc.ID == cartID select sc).First();
            if (shoppingCart != null)
            {
                shoppingCart.PartID = newPartID;
                db.SaveChanges();
            }
        }

        public void UpdateSCPartCount(int cartID, int newCount)
        {
            ShoppingCart? shoppingCart = (from sc in db.ShoppingCarts where sc.ID == cartID select sc).First();
            if (shoppingCart != null)
            {
                shoppingCart.Count = newCount;
                db.SaveChanges();
            }
        }

        public void UpdateSCPrice(int cartID, decimal newPrice)
        {
            ShoppingCart? shoppingCart = (from sc in db.ShoppingCarts where sc.ID == cartID select sc).First();
            if (shoppingCart != null)
            {
                shoppingCart.Price = newPrice;
                db.SaveChanges();
            }
        }

        public void RemoveShoppingCart(int cartID)
        {
            ShoppingCart? shoppingCart = (from p in db.ShoppingCarts where p.ID == cartID select p).First();
            if (shoppingCart != null)
            {
                db.ShoppingCarts.Remove(shoppingCart);
                db.SaveChanges();
            }
        }

        public void RemoveByCustomerAndPart(int customerID, int partID, bool isProcessed)
        {
            ShoppingCart? shoppingCart = (from p in db.ShoppingCarts where ((p.CustomerID == customerID) && (p.PartID == partID) && (p.isPartProcessed == isProcessed)) select p).First();
            if (shoppingCart != null)
            {
                db.ShoppingCarts.Remove(shoppingCart);
                db.SaveChanges();
            }
        }
    }
}
