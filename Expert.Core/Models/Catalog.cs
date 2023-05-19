using Expert.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Core.Models
{
    public class Catalog : DbModel<int>
    {
        [Key]
        public override int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
