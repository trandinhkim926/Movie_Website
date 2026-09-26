using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("Seasons")]
    public class Season
    {
        [Key]
        [Column("season_id")]
        public int SeasonId { get; set; }

        [Required]
        [Column("movie_id")]
        public int MovieId { get; set; }

        [Column("season_number")]
        public int SeasonNumber { get; set; }

        [MaxLength(200)]
        [Column("title")]
        public string? Title { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("release_date")]
        public DateTime? ReleaseDate { get; set; }

        // Navigation Properties
        [ForeignKey(nameof(MovieId))]
        public Movie? Movie { get; set; }

        public ICollection<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
