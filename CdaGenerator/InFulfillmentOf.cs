using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdaGenerator
{
    public class InFulfillmentOf
    {
        public string OidOrders { get; set; }

        public string OrderId { get; set; }

        public InFulfillmentOf()
        {
            
        }

        public InFulfillmentOf(string oidOrders, string orderId)
        {
            OidOrders = oidOrders;
            OrderId = orderId;
        }
    }
}
