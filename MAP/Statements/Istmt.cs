using MAP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Statements
{
    public interface Istmt
    {
        void execute(PrgState state);
    }
}
