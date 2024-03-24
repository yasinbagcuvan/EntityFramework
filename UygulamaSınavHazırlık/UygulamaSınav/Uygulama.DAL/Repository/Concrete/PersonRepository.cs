using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uygulama.DAL.Repository.Abstract;

namespace Uygulama.DAL.Repository.Concrete
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DiyetDbContext db) : base(db)
        {

        }
        public Person FindUser(string Email, string Password)
        {
            return entities.Where(p => p.Email == Email && p.Password == Password).SingleOrDefault();
        }
        public Person FindUser(string Email)
        {
            return entities.Where(p => p.Email == Email).SingleOrDefault();
        }

    }
}
