using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Core.Abstractions;

public abstract class DbModel<TKey> where TKey : IConvertible
{
    public virtual TKey Id { get; set; } = default!;
}
