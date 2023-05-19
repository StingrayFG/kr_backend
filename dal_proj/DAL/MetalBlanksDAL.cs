using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kr_lib;

#nullable enable

namespace dal_proj.DAL
{
    public class MetalBlanksDAL
    {
        ApplicationContext db = new ApplicationContext();

        public void AddMetalBlank(MetalBlank metalBlank)
        {
            db.MetalBlanks.Add(metalBlank);
            db.SaveChanges();
        }

        public int GetLastID()
        {
            int? id = db.MetalBlanks.Max(mb => mb.ID);
            if (id == null) { return 1; }
            else { return (int)id; }
        }

        public List<MetalBlank>? GetMetalBlanks()
        {
            List<MetalBlank>? metalBlanks = db.MetalBlanks.ToList();
            return metalBlanks;
        }

        public MetalBlank? GetMetalBlankByID(int metalBlankID)
        {
            MetalBlank? metalBlank = (from mb in db.MetalBlanks where mb.ID == metalBlankID select mb).First();
            return metalBlank;
        }

        public List<MetalBlank>? GetMetalBlanksByMaterial(string name)
        {
            List<MetalBlank>? metalBlanks = (from mb in db.MetalBlanks where mb.Material.Contains(name) select mb).ToList();
            return metalBlanks;
        }

        public void UpdateMetalBlankCount(int metalBlankID,int count)
        {
            MetalBlank? metalBlank = (from mb in db.MetalBlanks where mb.ID == metalBlankID select mb).First();
            if (metalBlank != null)
            {
                metalBlank.Count = count;
            }
        }

        public void UpdateMetalBlankPricePerKG(int metalBlankID, decimal newPriceOf1kg)
        {
            MetalBlank? metalBlank = (from mb in db.MetalBlanks where mb.ID == metalBlankID select mb).First();
            if (metalBlank != null)
            {
                metalBlank.PriceOf1kg = newPriceOf1kg;
                db.SaveChanges();
            }
        }

        public void UpdateMetalBlankPrice(int metalBlankID, decimal newPrice)
        {
            MetalBlank? metalBlank = (from mb in db.MetalBlanks where mb.ID == metalBlankID select mb).First();
            if (metalBlank != null)
            {
                metalBlank.Price = newPrice;
                db.SaveChanges();
            }
        }

        public void RemoveMetalBlank(int metalBlankID)
        {
            MetalBlank? metalBlank = (from p in db.MetalBlanks where p.ID == metalBlankID select p).First();
            if (metalBlank != null)
            {
                db.MetalBlanks.Remove(metalBlank);
                db.SaveChanges();
            }
        }
    }
}
