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
        public dynamic GetPackagingDeliveryCharge(string item, int count)
        {
            int charges = 0;
            if (item == null || count < 0)
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
