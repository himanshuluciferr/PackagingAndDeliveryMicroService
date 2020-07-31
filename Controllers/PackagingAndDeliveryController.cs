using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackagingAndDelivery.Models;

namespace PackagingAndDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagingAndDeliveryController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PackagingAndDeliveryController));
        [HttpGet]
        public dynamic GetPackagingDeliveryCharge(string item, int count)
        {
            _log4net.Info("GetPackagingDeliveryCharge() called");
            int charges = 0;
            if (item == null || count <= 0)
            {
                return BadRequest("Input not valid");
            }
            else
            {
                if (item.Equals("Integral"))
                {
                    charges = 300;
                }
                else if (item.Equals("Accessory"))
                {
                    charges = 150;
                }
                else
                {
                    return BadRequest("Not a valid item");
                }
            }
            return charges*count;
        }
    }
}
