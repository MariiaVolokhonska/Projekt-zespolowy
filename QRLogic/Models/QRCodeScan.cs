using System.ComponentModel.DataAnnotations;

namespace GroupProject.Models
{
    public class QrCodeScan
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public bool IsUsed { get; set; }
        [Range(10,500)]
        public int? Points { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
