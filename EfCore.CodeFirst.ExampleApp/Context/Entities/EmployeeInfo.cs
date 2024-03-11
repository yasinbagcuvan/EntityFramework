using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.CodeFirst.ExampleApp.Context.Entities
{
    public class EmployeeInfo
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateOnly Birthdate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
