using System.ComponentModel.DataAnnotations;

namespace QRLogic.Entities
{
    public class Service
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name{ get; set; }

    }
}
