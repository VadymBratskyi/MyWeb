using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCA.Domain
{
    public class Employee : IdentityEntity
    {
        public virtual Contact People { get; set; }
        public virtual List<EmployeePosition> Positions { get; set; } 
    }
}
