using MAP.Exceptions;
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
    class If : Istmt
    {

        Exp e;
        Istmt thenS;
        Istmt elseS;

        public If(Exp e, Istmt t, Istmt el)
        {
            this.e = e;
            this.thenS = t;
            this.elseS = el;
        }

        public override string ToString()
        {
            return "IF (" + e.ToString() + ") THEN " + thenS.ToString() + " ELSE " + elseS.ToString();
        }
        
        public void execute(PrgState state)
        {

            ImyStack<Istmt> stk = state.getExeStack();
            ImyDict<string, int> symTable = state.getSymTable();
         		
		try {
                if (e.eval(symTable) != 0)
                {
                    stk.push(thenS);
                }
                else
                {
                    stk.push(elseS);
                }
                
            } catch (ExpException) {
                throw new StmtException("Id in \"" + this.ToString() + "\" statement has no value asociated with it");
            }

        }

    }
}
