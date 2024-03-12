using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.CodeFirst.ExampleApp.Context.Entities
{
    //[Keyless]
    public class Customer
    {
        [Key]
        public int CustomerNumber { get; set; } //Id int Primary Key Identity (1,1)
        
        [Column(TypeName = "nvarchar(25)")]
        //[MaxLength(25)]
        public string Name { get; set; }
        public string Surname {  get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateOnly BirthDate {  get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
