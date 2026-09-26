using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        [Column("movie_id")]
        public int MovieId { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("description")]
        public string? Description { get; set; }

        [Column("release_year")]
        public int? ReleaseYear { get; set; }

        [Column("duration")]
        public int? Duration { get; set; } // Số phút

        [MaxLength(20)]
        [Column("age_rating")]
        public string? AgeRating { get; set; }

        [MaxLength(500)]
        [Column("poster_url")]
        public string? PosterUrl { get; set; }

        [MaxLength(500)]
        [Column("trailer_url")]
        public string? TrailerUrl { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public ICollection<MovieCategory> MovieCategories { get; set; } = new List<MovieCategory>();
        public ICollection<Season> Seasons { get; set; } = new List<Season>();
        public ICollection<WatchHistory> WatchHistories { get; set; } = new List<WatchHistory>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
