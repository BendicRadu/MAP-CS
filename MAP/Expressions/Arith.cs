using MAP.Exceptions;
using MAP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Expressions
{
    class Arith : Exp
    {


        Exp e1;
        Exp e2;
        int op; // 0=+, 1=-, 2=*, 3=/ 

        public Arith(Exp e1, Exp e2, int op)
        {
            this.e1 = e1;
            this.e2 = e2;
            this.op = op;
        }


        public override int eval(ImyDict<string, int> symTable)
        {
		
            if( op == 0 ){
                return e1.eval(symTable) + e2.eval(symTable);
            }
		
		    if ( op == 1 ){
                return e1.eval(symTable) - e2.eval(symTable);
            }
		
		    if ( op == 2 ){
                return e1.eval(symTable) * e2.eval(symTable);
            }
		
		    if ( op == 3 ){

                if (e2.eval(symTable) == 0)
                {
                    throw new ExpException("Expression " + this.ToString() + " is invalid (Division by 0)");
                }

                return e1.eval(symTable) / e2.eval(symTable);
            }
		
		return 0;
        }

        public override string ToString()
        {
            char[] opList = { '+', '-', '*', '/' };
            return "" + e1.ToString() + " " + opList[op] + " " + e2.ToString();
        }


    }
}
