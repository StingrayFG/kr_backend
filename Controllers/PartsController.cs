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
    [Route("parts")]
    [ApiExplorerSettings(GroupName = "parts")]
    public class PartsController : Controller
    {

        PartsBLL BLL = new PartsBLL();

        public PartsController()
        {
            BLL = new PartsBLL();
        }

        public PartsController(PartsBLL bll)
        {
            BLL = bll;
        }

        [HttpPut]
        [Route("add")]
        public void AddPart(string name, double partVolume, int metalBlankID, int machineID)
        {
            BLL.AddPart(name, partVolume, metalBlankID, machineID);
        }

        [HttpGet]
        [Route("get_all")]
        public List<Part> GetParts()
        {
            return BLL.GetParts();
        }

        [HttpGet]
        [Route("get_by_id")]
        public Part GetPartByID(int partID)
        {
            return BLL.GetPartByID(partID);
        }

        [HttpGet]
        [Route("get_by_name")]
        public List<Part> GetPartsByName(string name)
        {
            return BLL.GetPartsByName(name);
        }

        [HttpPatch]
        [Route("patch_name")]
        public void UpdatePartName(int partID, string newName)
        {
            BLL.UpdatePartName(partID, newName);
        }

        [HttpDelete]
        [Route("delete_by_id")]
        public void RemovePart(int partID)
        {
            BLL.RemovePart(partID);
        }

    }
}
