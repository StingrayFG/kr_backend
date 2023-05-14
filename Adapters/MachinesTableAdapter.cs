using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dal_proj.DAL;
using kr_lib;

#nullable enable

namespace bll_proj.Adapters
{
    public class MachinesTableAdapter
    {
        private MachinesTableDAL DAL = new MachinesTableDAL();

        public void AddMachine(Machine machine)
        {
            DAL.AddMachine(machine);
        }

        public int GetLastID()
        {
            return DAL.GetLastID();
        }

        public List<Machine>? GetMachines()
        {
            return DAL.GetMachines();
        }

        public Machine? GetMachineByID(int machineID)
        {
            return DAL.GetMachineByID(machineID);
        }

        public List<Machine>? GetMachinesByModel(string model)
        {
            return DAL.GetMachinesByModel(model);
        }

        public void UpdateMachineProcessingPrice(int machineID, decimal newPriceOfProcessing)
        {
            DAL.UpdateMachineProcessingPrice(machineID, newPriceOfProcessing);
        }

        public void RemoveMachine(int machineID)
        {
            DAL.RemoveMachine(machineID);
        }
    }
}
