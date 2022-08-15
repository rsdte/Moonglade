using System.ComponentModel.DataAnnotations;

namespace Moonglade.Domain.Roles
{
    public class RoleEntity : EntityBase
    {
        [Required]
        public string Name { get; set; }
    }
}
