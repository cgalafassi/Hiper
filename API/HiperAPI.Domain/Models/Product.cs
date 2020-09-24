using System.ComponentModel.DataAnnotations;

namespace HiperAPI.Domain.Models
{
    public class Product : Base
    {
        [Required]
        public int? ClientBDId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Value { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
