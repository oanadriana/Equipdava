using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Equipdava.DB.Entities
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(30)]
        public string Model { get; set; }

        [ForeignKey("ResourceTypeId")]
        public ResourceType ResourceType { get; set; }
        public int ResourceTypeId { get; set; }

        [Required]
        public bool IsAllocated { get; set; }
    }
}
