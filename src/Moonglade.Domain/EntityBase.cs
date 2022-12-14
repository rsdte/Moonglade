using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moonglade.Domain
{
    public abstract class EntityBase : IEntity<int>
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public bool Deleted { get; set; } = false;

        [Required]
        public DateTime CreatedTime { get; set; }

        [Required]
        public int CreatedUserId { get; set; }

        [Required]
        public DateTime UpdatedTime { get; set; } = DateTime.Now;

        [Required]
        public int UpdatedUserId { get; set; }
    }
}
