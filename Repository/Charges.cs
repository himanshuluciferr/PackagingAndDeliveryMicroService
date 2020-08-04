using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackagingAndDelivery.Models;
using LINQtoCSV;

namespace PackagingAndDelivery.Repository
{
    public class Charges : ICharges
    {
        public dynamic GetPackagingDeliveryCharge(string item, int count)
        {
            if (count <= 0)
            {
                return -1;
            }
            var CSVFile = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true
            };
            int Charge = 0;
            var CSV = new CsvContext();
            var Charges = from values in CSV.Read<Item>(@"./Items.csv", CSVFile)
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
