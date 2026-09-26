using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("MovieCategories")]
    public class MovieCategory
    {
        [Column("movie_id")]
        public int MovieId { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }

        // Navigation Properties
        [ForeignKey(nameof(MovieId))]
        public Movie? Movie { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
    }
}
