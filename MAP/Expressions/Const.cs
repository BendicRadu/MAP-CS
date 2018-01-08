using MAP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Expressions
{
    class Const : Exp
    {

        int value;

        public Const(int value)
        {
            this.value = value;
        }
    
        public override int eval(ImyDict<string, int> symTable)
        {
            return value;
        }

        public override string ToString()
        {
            return value.ToString();
        }


    }
}
