using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackagingAndDelivery.Repository
{
    public interface ICharges
    {
        dynamic GetPackagingDeliveryCharge(string item, int count);
    }
}
