using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kr_lib;

#nullable enable

namespace dal_proj.DAL
{
    public class PartsDAL
    {
        ApplicationContext db = new ApplicationContext();

        public void AddPart(Part part)
        {
            db.Parts.Add(part);
            db.SaveChanges();
        }

        public int GetLastID()
        {
            int? id = db.Parts.Max(mb => mb.ID);
            if (id == null) { return 1; }
            else { return (int)id; }
        }

        public List<Part>? GetParts()
        {
            List<Part>? parts = db.Parts.ToList();
            return parts;
        }

        public Part? GetPartByID(int partID)
        {
            Part? part = (from p in db.Parts where p.ID == partID select p).First();
            return part;
        }

        public List<Part>? GetPartsByName(string name)
        {
            List<Part>? parts = (from p in db.Parts where p.Name.Contains(name) select p).ToList();
            return parts;
        }

        public void UpdatePartName(int partID, string newName)
        {
            Part? part = (from p in db.Parts where p.ID == partID select p).First();
            if (part != null)
            {
                part.Name = newName;
                db.SaveChanges();
            }
        }

        public void RemovePart(int partID)
        {
            Part? part = (from p in db.Parts where p.ID == partID select p).First();
            if (part != null)
            {
                db.Parts.Remove(part);
                db.SaveChanges();
            }
        }
    }
}
