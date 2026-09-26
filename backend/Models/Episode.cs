using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("Episodes")]
    public class Episode
    {
        [Key]
        [Column("episode_id")]
        public int EpisodeId { get; set; }

        [Required]
        [Column("season_id")]
        public int SeasonId { get; set; }

        [Column("episode_number")]
        public int EpisodeNumber { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("description")]
        public string? Description { get; set; }

        [Column("duration")]
        public int? Duration { get; set; } // Số phút

        [MaxLength(500)]
        [Column("video_url")]
        public string? VideoUrl { get; set; }

        [Column("air_date")]
        public DateTime? AirDate { get; set; }

        // Navigation Properties
        [ForeignKey(nameof(SeasonId))]
        public Season? Season { get; set; }
    }
}
