using System.ComponentModel.DataAnnotations;
using SCA.Domain.Interfaces;

namespace SCA.Domain
{
    public class NamedEntity : IdentityEntity, IDeletable
    {
        [Required]
        [MaxLength(1000)]
        public virtual string Name { get; set; }

        public virtual bool IsDeleted { get; set; }
    }
}
