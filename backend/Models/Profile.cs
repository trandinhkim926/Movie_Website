using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("Profiles")]
    public class Profile
    {
        [Key]
        [Column("profile_id")]
        public int ProfileId { get; set; }

        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        [Column("avatar_url")]
        public string? AvatarUrl { get; set; }

        [Column("is_kid")]
        public bool IsKid { get; set; } = false;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public ICollection<WatchHistory> WatchHistories { get; set; } = new List<WatchHistory>();
    }
}
