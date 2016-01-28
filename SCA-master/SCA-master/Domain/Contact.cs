using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCA.Domain.Interfaces;

namespace SCA.Domain
{
    public class Contact : NamedEntity, ICreatedBy, IChangedBy, ICommented
    {
        public virtual List<string> Telephones { get; set; }
        public virtual string Email { get; set; }
        public virtual Contact Parent { get; set; }
        public virtual Employee Executor { get; set; }
    }
}
