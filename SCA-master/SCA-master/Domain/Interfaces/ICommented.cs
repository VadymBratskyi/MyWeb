using System.ComponentModel.DataAnnotations;

namespace SCA.Domain.Interfaces
{
    public interface ICommented
    {
        [MaxLength(700)]
        string Comment { get; set; }
    }
}
