using Expert.Core.Abstractions;
using Expert.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Core.Interfaces.IRepositories
{
    public interface IProductsRepository : IRepository<string, Product> { }
}
