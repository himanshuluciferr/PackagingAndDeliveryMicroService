using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LINQtoCSV;

namespace PackagingAndDelivery.Models
{
    public class Item
    {
        public string ItemType1 { get; set; }
        public int Packaging1 { get; set; }
        public int Delivery1 { get; set; }
        public string ItemType2 { get; set; }
        public int Packaging2 { get; set; }
        public int Delivery2 { get; set; }
    }
}
