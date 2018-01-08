using MAP.Expressions;
using MAP.Model;
using MAP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Statements
{
    class Print : Istmt
    {
        Exp e;

        public Print(Exp e)
        {
            this.e = e;
        }

        public void execute(PrgState state)
        {
            ImyList <int> output = state.getOutput();
            ImyDict<String, int> symTable = state.getSymTable();

            output.add(e.eval(symTable));
        }

        public override string ToString()
        {
            return "print(" + e.ToString() + ")";
        }



    }
}
