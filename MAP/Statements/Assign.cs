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
    class Assign : Istmt
    {
        private string id;
        private Exp e;

        public Assign(string id, Exp e)
        {
            this.id = id;
            this.e = e;
        }

        public override string ToString()
        {
            return "" + id + " = " + e.ToString();
        }

       
        public void execute(PrgState state)
        {

            ImyDict<string, int> symTable = state.getSymTable();
          
        int val;
		try {
			val = e.eval(symTable);
			symTable.add(id, val);

		} catch (ExpException e) {
			throw new StmtException("Statement \"" + this.ToString() + "\": " + e.Message);
		}
	}

    }
}
