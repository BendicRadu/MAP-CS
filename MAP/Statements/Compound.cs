using MAP.Model;
using MAP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Statements
{
    class Compound : Istmt
    {

        Istmt first;
        Istmt second;

        public Compound(Istmt first, Istmt second)
        {
            this.first = first;
            this.second = second;
        }

      
        public override string ToString()
        {
            return "" + first.ToString() + " ; " + second.ToString() + "";
        }

        public void execute(PrgState state)
        {
            ImyStack<Istmt> stk = state.getExeStack();
            stk.push(second);
            stk.push(first);
        }
    }
}
