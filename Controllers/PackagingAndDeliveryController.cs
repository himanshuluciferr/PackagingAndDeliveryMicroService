using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PackagingAndDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagingAndDeliveryController : ControllerBase
    {
        [HttpGet]
        public dynamic GetPackagingDeliveryCharge(string? item = null, int? count = null)
        {
            int charges = 0;
            if (item.Equals(null) || count.Equals(null))
            {
                BadRequest("Input not valid");
            }
            else
            {
                if (item.Equals("Integral") && count>=0)
                {
                    charges = 100 + 200;
                }
                else if (item.Equals("Accessory") && count >= 0)
                {
                    charges = 50 + 100;
                }
                else
                {
                    return BadRequest("Not a valid item or count");
                }
            }
            return charges*count;
        }
    }
}
