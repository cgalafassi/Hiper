using System.ComponentModel.DataAnnotations;

namespace HiperAPI.Domain.Models
{
    public class Product : Base
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Value { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
