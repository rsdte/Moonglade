using System.ComponentModel.DataAnnotations;

namespace Moonglade.Domain
{
    public class RoleResourceEntity : EntityBase
    {
        [Required]
        public int RoleId { get; set; }

        [Required]
        public int ResourceId { get; set; }
    }
}
