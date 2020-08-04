using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackagingAndDelivery.Models;
using LINQtoCSV;
using PackagingAndDelivery.Repository;

namespace PackagingAndDelivery.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetPackagingDeliveryChargeController : ControllerBase
    {
        public ICharges _context;
        public GetPackagingDeliveryChargeController(ICharges context)
        {
            this._context = context;
        }
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(GetPackagingDeliveryChargeController));
        [HttpGet]
        [ActionName("GetPackagingDeliveryCharge")]

        public dynamic GetPackagingDeliveryCharge(string item, int count)
        {
            _log4net.Info("GetPackagingDeliveryCharge() called");
            dynamic charges = _context.GetPackagingDeliveryCharge(item, count);
            if (charges == -1)
            {
                return BadRequest("Count not valid"); 
            }
            else
            {
                return charges;
            }
        }
        
    }
}
