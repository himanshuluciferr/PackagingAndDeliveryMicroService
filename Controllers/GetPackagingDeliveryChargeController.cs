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

            if (count <= 0)
            {
                return BadRequest("Invalid Count");
            }
            else
            {

                List<Item> items = new List<Item>();
                try
                {
                    string path = configuration.GetValue<string>("Items:Path");
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] ItemList = line.Split(",");
                            items.Add(new Item() { ItemType = ItemList[0], Packaging = Convert.ToInt32(ItemList[1]), Delivery = Convert.ToInt32(ItemList[2]) });
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    return null;
                }
                int Charge = 0;
                var Charges = from values in items
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
}
