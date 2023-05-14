using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace kr_lib
{
    public class ProductCard
    {
        public string Material { get; set; }
        public string Type { get; set; }

        public List<MetalBlank> MetalBlanks { get; set; }
    }
}
