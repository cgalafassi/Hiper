using HiperWebApp.Domain.Models;

using System.Collections.Generic;

namespace HiperWebApp.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
