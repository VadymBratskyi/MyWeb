using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCA.Domain.Interfaces;

namespace SCA.Domain
{
    public class Company : NamedEntity, IChangedBy, ICreatedBy, ICommented
    {
        public virtual Contact Owner { get; set; }
        public virtual Company Parent { get; set; }
        public virtual List<Contact> Employees { get; set; } 
    }
}
