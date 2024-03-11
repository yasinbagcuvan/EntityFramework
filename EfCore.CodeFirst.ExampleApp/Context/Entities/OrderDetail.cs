using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.CodeFirst.ExampleApp.Context.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId {  get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice {  get; set; }
    }
}
