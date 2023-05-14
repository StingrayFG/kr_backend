using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;
using kr_lib;
using bll_proj.Adapters;

namespace bll_proj.BLL
{
    [System.ComponentModel.DataObject]
    public class MetalBlanksBLL
    {
        private MetalBlanksTableAdapter Adapter = new MetalBlanksTableAdapter();

        [System.ComponentModel.DataObjectMethod
        (System.ComponentModel.DataObjectMethodType.Select, true)]

        public void AddMetalBlankByPricePerKG(string material, Vector3 dimensions, double density, decimal priceOf1kg)
        {
            double volume = dimensions.X * dimensions.Y * dimensions.Z;
            double weight = volume * density;

            Adapter.AddMetalBlank(new MetalBlank
            {
                ID = Adapter.GetLastID() + 1,
                Material = material,
                Width = dimensions.X,
                Height = dimensions.Y,
                Length = dimensions.Z,
                Density = density,
                Weight = weight,
                PriceOf1kg = priceOf1kg,
                Price = priceOf1kg * (decimal)weight
            });
        }

        public void AddMetalBlankByPrice(string material, Vector3 dimensions, double density, decimal price)
        {
            double volume = dimensions.X * dimensions.Y * dimensions.Z;
            double weight = volume * density;

            Adapter.AddMetalBlank(new MetalBlank
            {
                ID = Adapter.GetLastID() + 1,
                Material = material,
                Width = dimensions.X,
                Height = dimensions.Y,
                Length = dimensions.Z,
                Density = density,
                Weight = weight,
                Price = price
            });
        }

        public List<MetalBlank> GetMetalBlanks()
        {
            return Adapter.GetMetalBlanks();
        }

        public Catalog GetMetalBlanksInCards()
        {
            List<MetalBlank> blanks = Adapter.GetMetalBlanks();

            List<ProductCard> res = new List<ProductCard>();

            foreach (MetalBlank blank in blanks)
            {
                ProductCard card = res.Where(c => c.Material == blank.Material && c.Type == blank.Type).FirstOrDefault();
                if (card != default(ProductCard))
                {
                    card.MetalBlanks.Add(blank);
                }
                else
                {
                    card = new ProductCard();
                    card.Material = blank.Material;
                    card.Type = blank.Type;
                    card.MetalBlanks = new List<MetalBlank>();
                    card.MetalBlanks.Add(blank);
                    res.Add(card);
                }

            }

            return new Catalog(res);

        }

        public MetalBlank GetMetalBlankByID(int metalBlankID)
        {
            return Adapter.GetMetalBlankByID(metalBlankID);
        }

        public List<MetalBlank> GetMetalBlanksByMaterial(string name)
        {
            return Adapter.GetMetalBlanksByMaterial(name);
        }

        public void UpdateMetalBlankCount(int metalBlankID, int count)
        {
            Adapter.UpdateMetalBlankCount(metalBlankID, count);
        }

        public void UpdateMetalBlankPricePerKG(int metalBlankID, decimal newPriceOf1kg)
        {
            Adapter.UpdateMetalBlankPricePerKG(metalBlankID, newPriceOf1kg);

            double weight = Adapter.GetMetalBlankByID(metalBlankID).Weight;

            Adapter.UpdateMetalBlankPrice(metalBlankID, (decimal)weight * newPriceOf1kg);
        }

        public void UpdateMetalBlankPrice(int metalBlankID, decimal newPrice)
        {
            Adapter.UpdateMetalBlankPrice(metalBlankID, newPrice);

            double weight = Adapter.GetMetalBlankByID(metalBlankID).Weight;

            Adapter.UpdateMetalBlankPricePerKG(metalBlankID, newPrice / (decimal)weight);
        }

        public void RemoveMetalBlank(int metalBlankID)
        {
            Adapter.RemoveMetalBlank(metalBlankID);
        }
    }
}

