using System;
using System.ComponentModel.DataAnnotations;

namespace SCA.Domain
{
    public class IdentityEntity
    {
        [Required]
        public virtual Guid Id { get; set; }
    }
}
