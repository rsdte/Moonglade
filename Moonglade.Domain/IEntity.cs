using System.ComponentModel.DataAnnotations;

namespace Moonglade.Domain
{
    internal interface IEntity<T>
    {
        [Key]
        T Id { get; set; }
    }
}
