using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace kr_lib
{
    public class Part
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public double Volume { get; set; }
        public decimal TotalPrice { get; set; }

        public int MetalBlankID { get; set; }
        public MetalBlank MetalBlank { get; set; }

        public int MachineID { get; set; }
        public Machine Machine { get; set; }

        public LinkedList<ShoppingCart> ShoppingCarts { get; set; }
    }
}
