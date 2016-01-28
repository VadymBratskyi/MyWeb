using System;
using System.ComponentModel.DataAnnotations;

namespace SCA.Domain
{
    public class Currency : NamedEntity
    {
        [MaxLength(4)]
        public virtual string BankCode { get; set; }
    }
}
