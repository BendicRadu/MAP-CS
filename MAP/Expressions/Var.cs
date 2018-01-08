using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAP.Utils;
using MAP.Exceptions;

namespace MAP.Expressions
{
    class Var : Exp
    {
        string name;
           
        public Var(string name)
        {
            this.name = name;
        }

        public override int eval(ImyDict<string, int> sym)
        {
            try
            {
                return sym.get(name);
            }
            catch (Exception){
                throw new ExpException("Variable " + name + " is not in the sym table\n");
            }
        }

        public override string ToString()
        {
            return name;
        }

    }
}
