using Expert.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Core.Models
{
    public class Product : DbModel<string>
    {
        [Key]
        public override string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? Description { get; set; }
        public decimal Price { get; set; } = default!;

        public int CatalogId { get; set; }
        public Catalog Catalog { get; set; } = default!;

    }
}
