using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LINQtoCSV;

namespace PackagingAndDelivery.Models
{
    public class Item
    {
        public string ItemType { get; set; }
        public int Packaging { get; set; }
        public int Delivery { get; set; }
    }
}
