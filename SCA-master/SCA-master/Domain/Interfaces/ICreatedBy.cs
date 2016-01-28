using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCA.Domain.Interfaces
{
    public interface ICreatedBy : ICreated
    {
        SystemUser CreatedBy { get; set; }
    }
}
