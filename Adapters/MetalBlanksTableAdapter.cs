using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dal_proj.DAL;
using kr_lib;

#nullable enable

namespace bll_proj.Adapters
{
    public class MetalBlanksTableAdapter
    {
        private MetalBlanksTableDAL DAL = new MetalBlanksTableDAL();

        public void AddMetalBlank(MetalBlank metalBlank)
        {
            DAL.AddMetalBlank(metalBlank);
        }

        public int GetLastID()
        {
            return DAL.GetLastID();
        }

        public List<MetalBlank>? GetMetalBlanks()
        {
            return DAL.GetMetalBlanks();
        }

        public MetalBlank? GetMetalBlankByID(int metalBlankID)
        {
            return DAL.GetMetalBlankByID(metalBlankID);
        }

        public List<MetalBlank>? GetMetalBlanksByMaterial(string name)
        {
            return DAL.GetMetalBlanksByMaterial(name);
        }

        public void UpdateMetalBlankCount(int metalBlankID, int count)
        {
            DAL.UpdateMetalBlankCount(metalBlankID, count);
        }

        public void UpdateMetalBlankPricePerKG(int metalBlankID, decimal newPriceOf1kg)
        {
            DAL.UpdateMetalBlankPrice(metalBlankID, newPriceOf1kg);
        }

        public void UpdateMetalBlankPrice(int metalBlankID, decimal newPrice)
        {
            DAL.UpdateMetalBlankPrice(metalBlankID, newPrice);
        }

        public void RemoveMetalBlank(int metalBlankID)
        {
            DAL.RemoveMetalBlank(metalBlankID);
        }
    }
}
