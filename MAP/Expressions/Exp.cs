using MAP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Expressions
{
    abstract class Exp
    {
        abstract public int eval(ImyDict<string, int> sym);
    }
}
