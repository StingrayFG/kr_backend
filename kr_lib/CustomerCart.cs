using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace kr_lib
{
    public class CustomerCart
    {
        public CustomerCart()
        {
            metalBlanks = new List<MetalBlank>();
            parts = new List<Part>();
        }

        public int CustomerID { get; set; }

        public decimal TotalPrice { get; set; }

        public List<MetalBlank> metalBlanks { get; set; }

        public List<Part> parts { get; set; }
    }
}
