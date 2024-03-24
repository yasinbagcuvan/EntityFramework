using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uygulama.DAL.Enums;

namespace Uygulama.DAL.Repository.Abstract
{
    public interface IEntity
    {
        int Id { get; set; }

        DateTime CreatedDate { get; set; }

        DateTime? UpdatedDate { get; set; }
        DateTime? DeletedDate { get; set; }

        Status Status { get; set; }
    }
}
