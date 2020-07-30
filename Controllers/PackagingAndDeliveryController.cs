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
            if(item.Equals("Integral"))
            {
                charges = 100 + 200;
            }
            else if(item.Equals("Accessory"))
            {
                charges = 50 + 100;
            }
            else
            {
                return BadRequest("Not a valid item or count");
            }
            return charges*count;
        }
    }
}
