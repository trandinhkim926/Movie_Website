using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column("password_hash")]
        public string PasswordHash { get; set; } = string.Empty;

        [MaxLength(500)]
        [Column("avatar_url")]
        public string? AvatarUrl { get; set; }

        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        [MaxLength(20)]
        [Column("gender")]
        public string? Gender { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public ICollection<Profile> Profiles { get; set; } = new List<Profile>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
