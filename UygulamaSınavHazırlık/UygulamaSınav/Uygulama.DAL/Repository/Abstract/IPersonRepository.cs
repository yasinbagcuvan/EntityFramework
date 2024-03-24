using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uygulama.DAL.Repository.Abstract
{
    public interface IPersonRepository
    {
        Person FindUser(string email, string password);
        Person FindUser(string Email);
    }
}
