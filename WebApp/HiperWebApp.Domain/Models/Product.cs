using System.ComponentModel.DataAnnotations;

namespace HiperWebApp.Domain.Models
{
    public class Product : Base
    {
        [Required]
        [Display(Name = "Nome do Produto")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Value { get; set; }
        [Required]
        [Display(Name = "Estoque")]
        public int Quantity { get; set; }

        public bool IsEquals(Product productApi)
        {
            return (Id.Equals(productApi.Id) 
                    && Name.Equals(productApi.Name) 
                    && Value.Equals(productApi.Value) 
                    && Quantity.Equals(productApi.Quantity));
        }
    }
}
