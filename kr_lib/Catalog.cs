using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace kr_lib
{
    public class Catalog
    {
        public Catalog(List<ProductCard> cards)
        {
            Cards = cards;
        }
        public List<ProductCard> Cards { get; set; }
    }
}
