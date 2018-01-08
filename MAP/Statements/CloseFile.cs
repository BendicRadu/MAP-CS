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
    class CloseFile
    {

        Exp exp_file_id;

        public CloseFile(Exp exp_file_id)
        {
            this.exp_file_id = exp_file_id;
        }

        public PrgState execute(PrgState state)
        {


            ImyDict<String, int> symTable = state.getSymTable();
            ImyDict<int, Tuple<String, StreamReader>> fileTable = state.getFileTable();
    
        int v;
        StreamReader buffReader;
		
		try {
			v = exp_file_id.eval(symTable);
		} catch (ExpException e) {
			throw new StmtException("Expression \"" + exp_file_id + "\" in statement + \"" + this.ToString() + "\" is invalid: " + e.Message);
		}
		
		try {
                buffReader = fileTable.get(v).Item2;
                buffReader.Close();
			    fileTable.remove(v);
			
		} catch (Exception ) {
			throw new StmtException("File does not exist or hasn't been open");
		}
		
		return null;	
	}
	
    public override string ToString()
{
    return "closeRFile(" + exp_file_id.ToString() + ")";
}
	
    }
}
