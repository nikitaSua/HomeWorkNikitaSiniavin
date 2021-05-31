using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPpractice.HelpClasses
{
    public class NegativesNotAllowedException : ArgumentException
    {
        public NegativesNotAllowedException(string message)
        : base(message)
        { }
    }
}
