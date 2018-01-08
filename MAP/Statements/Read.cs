using MAP.Exceptions;
using MAP.Expressions;
using MAP.Model;
using MAP.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Statements
{
    class Read : Istmt
    {

        public Exp exp_file_id;
        public string var_name;

        public Read(Exp exp_file_id, string var_name)
        {
            this.exp_file_id = exp_file_id;
            this.var_name = var_name;
        }

       
        public void execute(PrgState state) 
        {

            ImyDict<string, int> symTable = state.getSymTable();
            ImyDict<int, Tuple<string, StreamReader>> fileTable = state.getFileTable();

            int v;
            StreamReader buffReader;
		
		    try {
			    v = exp_file_id.eval(symTable);
		    } catch (ExpException e) {
			    throw new StmtException("Expression \"" + exp_file_id + "\" in statement + \"" + this.ToString() + "\" is invalid: " + e.Message);
		    }
		
		    try {
			    buffReader = fileTable.get(v).Item2;
		    } catch (Exception) {
			    throw new StmtException("File does not exist or hasn't been open \"" + exp_file_id.ToString() + "\"");
		    }
		
		    try {
			    string readValue = buffReader.ReadLine();

                int value;
			
			    if(readValue == null){
				    value = 0;
			    }
			    else{
                    Int32.TryParse(readValue, out value);
			    }
			
			    symTable.add(var_name, value);
			
		    } catch (IOException e2) {
			    throw new StmtException("Statement \"" + this.ToString() + "\" encountered an exception: " + e2.Message);
		    }
		
	    }

    public override string ToString()
{
    return "readFile(" + exp_file_id + ", " + var_name + ")";
}
    }
}
