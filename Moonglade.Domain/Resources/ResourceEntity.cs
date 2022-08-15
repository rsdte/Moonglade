using System.ComponentModel.DataAnnotations;

namespace Moonglade.Domain
{
    public enum ResourceType : byte
    {
        Menu = 0,       // 不可点击
        MenuItem,   // 可点击
        Button,     // 按钮
    }

    public class ResourceEntity : EntityBase
    {
        [Required]
        public string DisplayName { get; set; }

        public string? Description { get; set; }

        public string? Url { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; } = 0;
    }
}
