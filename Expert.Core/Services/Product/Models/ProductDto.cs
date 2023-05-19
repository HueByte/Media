using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Core.Services.Product.Models
{
    public class ProductDto
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? Description { get; set; }
        public decimal Price { get; set; } = default!;
    }
}
