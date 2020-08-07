using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackagingAndDelivery.Models;
using LINQtoCSV;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PackagingAndDelivery.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetPackagingDeliveryChargeController : ControllerBase
    {
        private IConfiguration configuration;
        public GetPackagingDeliveryChargeController(IConfiguration config)
        {
            configuration = config;
        }
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(GetPackagingDeliveryChargeController));
        [HttpGet]
        [ActionName("GetPackagingDeliveryCharge")]
        
        public dynamic GetPackagingDeliveryCharge(string item, int count)
        {
            _log4net.Info("GetPackagingDeliveryCharge() called");
            int Charges = 0;
            if (count <= 0)
            {
                return BadRequest("Invalid quantity");
            }
            else if(item.Trim().ToUpper() == "INTEGRAL")
            {
                Charges = 300;
            }
            else if(item.Trim().ToUpper() == "ACCESSORY")
            {
                Charges = 150;
            }
            return Charges * count;
        }
    }
}
