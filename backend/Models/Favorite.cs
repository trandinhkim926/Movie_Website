using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("Favorites")]
    public class Favorite
    {
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("movie_id")]
        public int MovieId { get; set; }

        [Column("added_at")]
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie? Movie { get; set; }
    }
}
