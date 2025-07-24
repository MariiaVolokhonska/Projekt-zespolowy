using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRLogic.Entities
{
    public class Coupon
    {
        [Key]
        public string? Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Service")]
        public int ServiceId { get; set; }

        [Required]
        [MaxLength(10000)]
        public string QrCode { get; set; }

        [Required]
        public bool IsActivated { get; set; } = false;

        [Required]
        public bool IsUsed { get; set; } = false;

        public Service Service { get; set; }

    }
}
