using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityDemo.Models
{
    public class Voiture
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        [Required]
        [MaxLength(100)]
        public string Plate { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Hp { get; set; }

        
        [MaxLength(100)]
        public string? Color { get; set; }

        [NotMapped]
        public string? TheBiggestUselessProps { get; set; }

    }
}
