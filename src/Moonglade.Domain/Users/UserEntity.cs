using System.ComponentModel.DataAnnotations;

namespace Moonglade.Domain
{
    public class UserEntity : EntityBase
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}