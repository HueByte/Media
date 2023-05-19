using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Core.Exceptions
{
    public class FriendlyException : Exception
    {
        public FriendlyException(string message) : base(message) { }
    }
}
