using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("WatchHistory")]
    public class WatchHistory
    {
        [Key]
        [Column("history_id")]
        public int HistoryId { get; set; }

        [Required]
        [Column("profile_id")]
        public int ProfileId { get; set; }

        [Required]
        [Column("movie_id")]
        public int MovieId { get; set; }

        [Column("watched_at")]
        public DateTime WatchedAt { get; set; } = DateTime.UtcNow;

        [Column("progress")]
        public int Progress { get; set; } // Giây hoặc phần trăm

        // Navigation Properties
        [ForeignKey(nameof(ProfileId))]
        public Profile? Profile { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie? Movie { get; set; }
    }
}
