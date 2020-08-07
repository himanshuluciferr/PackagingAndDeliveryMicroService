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
        private readonly IOptions<CSV> appSettings;
        public GetPackagingDeliveryChargeController(IOptions<CSV> app)
        {
            appSettings = app;
        }
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(GetPackagingDeliveryChargeController));
        [HttpGet]
        [ActionName("GetPackagingDeliveryCharge")]
        
        public dynamic GetPackagingDeliveryCharge(string item, int count)
        {
            _log4net.Info("GetPackagingDeliveryCharge() called");
            int Charge = 0;
           
            if (count <= 0)
            {
                return BadRequest("Invalid Count");
            }
            /*
            else if(item.Trim().ToUpper() == appSettings.Value.ItemType1.ToUpper())
            {
                Charge = appSettings.Value.Packaging1 + appSettings.Value.Delivery1;
            }
            else if (item.Trim().ToUpper() == appSettings.Value.ItemType2.ToUpper())
            {
                Charge = appSettings.Value.Packaging2 + appSettings.Value.Delivery2;
            }
            
            return Charge*count;
            */
            var CSVFile = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true
            };
            
            var CSV = new CsvContext();
            var Charges = from values in CSV.Read<Item>(appSettings.Value.Path, CSVFile)
                          where (values.ItemType.Trim().ToUpper() == item.ToUpper())
                          select new
                          {
                              DeliveryCharge = values.Delivery,
                              PackagingCharge = values.Packaging
                          };
            var Fee = Charges.Select(charge => charge.DeliveryCharge + charge.PackagingCharge).ToList();
            foreach (int value in Fee)
            {
                Charge += value;
            }
            return Charge * count;
        }
    }
}
