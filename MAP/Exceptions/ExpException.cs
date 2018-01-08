using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Exceptions
{

    public class ExpException : Exception
    {
        public ExpException(string message) : base(message) { }   
    }

    public class StmtException : Exception
    {
        public StmtException(string message) : base(message) { }
    }

    public class EndException : Exception
    {
        public EndException(string message) : base(message) { }
    }
}
