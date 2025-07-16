using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRLogic.Entities
{
    public class UserPointsWallet
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public int AmountOfPoints { get; set; } = 0;
    }
}
