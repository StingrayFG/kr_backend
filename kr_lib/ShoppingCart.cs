using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace kr_lib
{
    public class ShoppingCart
    {
        [Key]
        public int ID { get; set; }

        public int Count { get; set; }
        public decimal Price { get; set; }

        public bool isPartProcessed { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

#nullable enable
        public int? OrderID { get; set; }
        public Order? Order { get; set; }
#nullable disable

        public int PartID { get; set; }
        //public Part Part { get; set; }
    }
}
