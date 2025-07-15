using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRLogic.Entities
{
    public class QrCodeScan
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public bool IsUsed { get; set; }

        [Range(10,500)]
        public int? Points { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
