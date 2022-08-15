using System.ComponentModel.DataAnnotations;

namespace Moonglade.Domain.RoleResources
{
    public class RoleResourceEntity : EntityBase
    {
        [Required]
        public int RoleId { get; set; }

        [Required]
        public int ResourceId { get; set; }
    }
}
