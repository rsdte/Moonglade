using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Moonglade.Domain
{
    public class RoleEntity : EntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required, DefaultValue(0)]
        public int SortNum { get; set; }
    }
}
