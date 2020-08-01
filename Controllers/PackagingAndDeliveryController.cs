using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackagingAndDelivery.Models;
using LINQtoCSV;

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
            if(count <= 0)
            {
                return BadRequest("Count not valid");
            }
            var CSVFile = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true
            };
            int Charge = 0;
            var CSV = new CsvContext();
            var Charges = from values in CSV.Read<Item>(@"./Items.csv", CSVFile)
                          where (values.ItemType == item)
                          select new
                          {
                              DeliveryCharge = values.Delivery,
                              PackagingCharge = values.Packaging
                          };
            var Fee = Charges.Select(x => x.DeliveryCharge + x.PackagingCharge).ToList();
            foreach(int value in Fee)
            {
                Charge += value;
            }
            return Charge * count;
        }
    }
}
