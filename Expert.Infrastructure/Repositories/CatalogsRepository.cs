using Expert.Core.Abstractions;
using Expert.Core.Interfaces.IRepositories;
using Expert.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Infrastructure.Repositories
{
    public class CatalogsRepository : BaseRepository<int, Catalog, MediaContext>, ICatalogsRepository
    {
        public CatalogsRepository(MediaContext context) : base(context) { }
    }
}
