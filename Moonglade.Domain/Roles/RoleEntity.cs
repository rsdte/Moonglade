using System.ComponentModel.DataAnnotations;

namespace Moonglade.Domain
{
    public class RoleEntity : EntityBase
    {
        [Required]
        public string Name { get; set; }
    }
}
