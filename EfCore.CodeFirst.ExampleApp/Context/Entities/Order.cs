using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.CodeFirst.ExampleApp.Context.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderCode {  get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId {  get; set; }
        public DateTime OrderTime {  get; set; }
    }
}
