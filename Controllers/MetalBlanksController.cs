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
    [Route("metalblanks")]
    [ApiExplorerSettings(GroupName = "metalblanks")]
    public class MetalBlanksController : Controller
    {

        MetalBlanksBLL BLL = new MetalBlanksBLL();

        [HttpPut]
        [Route("add_by_price_per_kg")]
        public void AddMetalBlankByPricePerKG(string material, Vector3 dimensions, double density, decimal priceOf1kg)
        {
            BLL.AddMetalBlankByPricePerKG(material, dimensions, density, priceOf1kg);
        }

        [HttpPut]
        [Route("add_by_price")]
        public void AddMetalBlankByPrice(string material, Vector3 dimensions, double density, decimal price)
        {
            BLL.AddMetalBlankByPrice(material, dimensions, density, price);
        }

        [HttpGet]
        [Route("get_all")]
        public List<MetalBlank> GetMetalBlanks()
        {
            return BLL.GetMetalBlanks();
        }

        [HttpGet]
        [Route("get_cards")]
        public Catalog GetMetalBlanksInCards()
        {
            return BLL.GetMetalBlanksInCards();
        }

        [HttpGet]
        [Route("get_by_id")]
        public MetalBlank GetMetalBlankByID(int metalBlankID)
        {
            return BLL.GetMetalBlankByID(metalBlankID);
        }

        [HttpGet]
        [Route("get_by_material")]
        public List<MetalBlank> GetMetalBlanksByMaterial(string name)
        {
            return BLL.GetMetalBlanksByMaterial(name);
        }

        [HttpPatch]
        [Route("patch_count")]
        public void UpdateMetalBlankCount(int metalBlankID, int count)
        {
            BLL.UpdateMetalBlankCount(metalBlankID, count);
        }

        [HttpPatch]
        [Route("patch_price_per_kg")]
        public void UpdateMetalBlankPricePerKG(int metalBlankID, decimal newPriceOf1kg)
        {
            BLL.UpdateMetalBlankPricePerKG(metalBlankID, newPriceOf1kg);
        }

        [HttpPatch]
        [Route("patch_price")]
        public void UpdateMetalBlankPrice(int metalBlankID, decimal newPrice)
        {
            BLL.UpdateMetalBlankPrice(metalBlankID, newPrice);
        }

        [HttpDelete]
        [Route("delete_by_id")]
        public void RemoveMetalBlank(int metalBlankID)
        {
            BLL.RemoveMetalBlank(metalBlankID);
        }

    }
}
