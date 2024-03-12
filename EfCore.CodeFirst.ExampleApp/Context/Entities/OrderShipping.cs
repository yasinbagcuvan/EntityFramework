using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.CodeFirst.ExampleApp.Context.Entities
{
    public class OrderShipping
    {
        public int OrderId { get; set; }
        public int ShippingId { get; set; }
        public int SppingStatus { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime EstimatedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public Order Order { get; set; }
        public Shipping Shipping { get; set; }
    }
}
