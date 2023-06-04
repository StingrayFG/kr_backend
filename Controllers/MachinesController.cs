using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;
using bll_proj.BLL;
using kr_lib;

namespace bll_proj.Controllers
{
    [ApiController]
    [Route("machines")]
    [ApiExplorerSettings(GroupName = "machines")]
    public class MachinesController : Controller
    {

        private MachinesBLL BLL = new MachinesBLL();

        [HttpPut]
        [Route("add")]
        public void AddMachine(string model, Vector3 maxDimensions, double processingTimeOf1mm3, decimal priceOfProcessing1mm3)
        {
            BLL.AddMachine(model, maxDimensions, processingTimeOf1mm3, priceOfProcessing1mm3);
        }

        [HttpGet]
        [Route("get_all")]
        public List<Machine> GetMachines()
        {
            return BLL.GetMachines();
        }

        [HttpGet]
        [Route("get_by_id")]
        public Machine GetMachineByID(int machineID)
        {
            return BLL.GetMachineByID(machineID);
        }

        [HttpGet]
        [Route("get_by_model")]
        public List<Machine> GetMachinesByModel(string model)
        {
            return BLL.GetMachinesByModel(model);
        }

        [HttpPatch]
        [Route("patch_processing_price")]
        public void UpdateMachineProcessingPrice(int machineID, decimal newPriceOfProcessing)
        {
            BLL.UpdateMachineProcessingPrice(machineID, newPriceOfProcessing);
        }

        [HttpDelete]
        [Route("delete_by_id")]
        public void RemoveMachine(int machineID)
        {
            BLL.RemoveMachine(machineID);
        }

    }
}
