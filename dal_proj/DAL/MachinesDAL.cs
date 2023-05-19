using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kr_lib;

#nullable enable

namespace dal_proj.DAL
{
    public class MachinesDAL
    {
        ApplicationContext db = new ApplicationContext();

        public void AddMachine(Machine machine)
        {
            db.Machines.Add(machine);
            db.SaveChanges();
        }

        public int GetLastID()
        {
            int? id = db.Machines.Max(mb => mb.ID);
            if (id == null) { return 1; }
            else { return (int)id; }
        }

        public List<Machine>? GetMachines()
        {
            List<Machine>? parts = db.Machines.ToList();
            return parts;
        }

        public Machine? GetMachineByID(int machineID)
        {
            Machine? part = (from p in db.Machines where p.ID == machineID select p).First();
            return part;
        }

        public List<Machine>? GetMachinesByModel(string model)
        {
            List<Machine>? parts = (from p in db.Machines where p.Model.Contains(model) select p).ToList();
            return parts;
        }

        public void UpdateMachineProcessingPrice(int machineID, decimal newPriceOfProcessing)
        {
            Machine? machine = (from m in db.Machines where m.ID == machineID select m).First();
            if (machine != null)
            {
                machine.PriceOfProcessing1mm3 = newPriceOfProcessing;
                db.SaveChanges();
            }
        }

        public void RemoveMachine(int machineID)
        {
            Machine? part = (from p in db.Machines where p.ID == machineID select p).First();
            if (part != null)
            {
                db.Machines.Remove(part);
                db.SaveChanges();
            }
        }
    }
}
