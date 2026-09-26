using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        public string? Description { get; set; }

        [MaxLength(500)]
        [Column("icon_url")]
        public string? IconUrl { get; set; }

        // Navigation Properties
        public ICollection<MovieCategory> MovieCategories { get; set; } = new List<MovieCategory>();
    }
}
