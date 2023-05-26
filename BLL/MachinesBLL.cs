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
    public class MachinesBLL
    {
        private MachinesAdapter Adapter;

        public MachinesBLL()
        {
            Adapter = new MachinesAdapter();
        }

        public MachinesBLL(MachinesAdapter adapter)
        {
            Adapter = adapter;
        }

        [System.ComponentModel.DataObjectMethod
        (System.ComponentModel.DataObjectMethodType.Select, true)]

        public void AddMachine(string model, Vector3 maxDimensions, double processingTimeOf1mm3, decimal priceOfProcessing1mm3)
        {
            Adapter.AddMachine(new Machine
            {
                ID = Adapter.GetLastID() + 1,
                Model = model,
                MaxWidth = maxDimensions.X,
                MaxHeight = maxDimensions.Y,
                MaxLength = maxDimensions.Z,
                ProcessingTimeOf1mm3 = processingTimeOf1mm3,
                PriceOfProcessing1mm3 = priceOfProcessing1mm3
            }); ;
        }

        public List<Machine> GetMachines()
        {
            return Adapter.GetMachines();
        }

        public Machine GetMachineByID(int machineID)
        {
            return Adapter.GetMachineByID(machineID);
        }

        public List<Machine> GetMachinesByModel(string model)
        {
            return Adapter.GetMachinesByModel(model);
        }

        public void UpdateMachineProcessingPrice(int machineID, decimal newPriceOfProcessing)
        {
            Adapter.UpdateMachineProcessingPrice(machineID, newPriceOfProcessing);
        }

        public void RemoveMachine(int machineID)
        {
            Adapter.RemoveMachine(machineID);
        }
    }
}
