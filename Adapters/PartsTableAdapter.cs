using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dal_proj.DAL;
using kr_lib;

#nullable enable

namespace bll_proj.Adapters
{
    public class PartsTableAdapter
    {
        private PartsTableDAL DAL = new PartsTableDAL();

        public void AddPart(Part part)
        {
            DAL.AddPart(part);
        }

        public int GetLastID()
        {
            return DAL.GetLastID();
        }

        public List<Part>? GetParts()
        {
            return DAL.GetParts();
        }

        public Part? GetPartByID(int partID)
        {
            return DAL.GetPartByID(partID);
        }

        public List<Part>? GetPartsByName(string name)
        {
            return DAL.GetPartsByName(name);
        }

        public void UpdatePartName(int partID, string newName)
        {
            DAL.UpdatePartName(partID, newName);
        }

        public void RemovePart(int partID)
        {
            DAL.RemovePart(partID);
        }
    }
}
