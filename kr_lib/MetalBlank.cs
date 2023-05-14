using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace kr_lib
{
    public class MetalBlank
    {
        [Key]
        public int ID { get; set; }

        public string Material { get; set; }

        public string Type { get; set; }

        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }

        public double Density { get; set; }
        public double Weight { get; set; }

        public int Count { get; set; }

        public decimal PriceOf1kg { get; set; }
        public decimal Price { get; set; }

        public LinkedList<Part> Parts { get; set; }
    }
}
