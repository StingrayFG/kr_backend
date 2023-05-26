using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bll_proj.Adapters;
using kr_lib;

namespace bll_proj.BLL
{
    [System.ComponentModel.DataObject]
    public class PartsBLL
    {
        private PartsAdapter Adapter;
        private MetalBlanksAdapter MetalBlankAdapter;
        private MachinesAdapter MachineAdapter;

        public PartsBLL()
        {
            Adapter = new PartsAdapter();
            MetalBlankAdapter = new MetalBlanksAdapter();
            MachineAdapter = new MachinesAdapter();
        }

        public PartsBLL(PartsAdapter adapter, MetalBlanksAdapter metalBlankAdapter, MachinesAdapter machineAdapter)
        {
            Adapter = adapter;
            MetalBlankAdapter = metalBlankAdapter;
            MachineAdapter = machineAdapter;
        }

        [System.ComponentModel.DataObjectMethod
        (System.ComponentModel.DataObjectMethodType.Select, true)]

        public void AddPart(string name, double partVolume, int metalBlankID, int machineID)
        {
            MetalBlank usedMetalBlank = MetalBlankAdapter.GetMetalBlankByID(metalBlankID);
            Machine usedMachine = MachineAdapter.GetMachineByID(machineID);

            double processedVolume = usedMetalBlank.Width * usedMetalBlank.Height * usedMetalBlank.Length - partVolume;

            decimal totalPrice = usedMetalBlank.Price * usedMachine.PriceOfProcessing1mm3;

            Adapter.AddPart(new Part
            {
                ID = Adapter.GetLastID() + 1,
                Name = name,
                Volume = partVolume,
                TotalPrice = totalPrice,
                MachineID = machineID,
                MetalBlankID = metalBlankID
            });
        }

        public List<Part> GetParts()
        {
            return Adapter.GetParts();
        }

        public Part GetPartByID(int partID)
        {
            return Adapter.GetPartByID(partID);
        }

        public List<Part> GetPartsByName(string name)
        {
            return Adapter.GetPartsByName(name);
        }

        public void UpdatePartName(int partID, string newName)
        {
            Adapter.UpdatePartName(partID, newName);
        }

        public void RemovePart(int partID)
        {
            Adapter.RemovePart(partID);
        }
    }
}
