using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace kr_lib
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        public DateTime OrderCreationDate { get; set; }
        public decimal Price { get; set; }
        public string PaymentMethod { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public LinkedList<ShoppingCart> ShoppingCarts { get; set; }
    }
}
