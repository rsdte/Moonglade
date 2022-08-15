using System.ComponentModel.DataAnnotations;

namespace Moonglade.Domain
{
    public abstract class EntityBase : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Deleted { get; set; } = false;

        [Required]
        public DateTime CreateTime { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime UpdatedTime { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedUserId { get; set; }
    }
}
