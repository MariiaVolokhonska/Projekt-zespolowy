using System.ComponentModel.DataAnnotations;

namespace QRLogic.Entities
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name{ get; set; }
        [Required]
        public int PointPrice { get; set; }
        public string? ImageUrl { get; set; }

    }
}
