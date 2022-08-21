using System.ComponentModel.DataAnnotations;

namespace Moonglade.Domain
{
    public class UserRoleEntity : EntityBase
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}
