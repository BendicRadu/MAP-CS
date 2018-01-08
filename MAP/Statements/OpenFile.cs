using MAP.Exceptions;
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
    class OpenFile : Istmt
    {

        string var_file_id;
        string filename;

        public OpenFile(string var_file_id, string filename)
        {
            this.var_file_id = var_file_id;
            this.filename = filename;
        }

        public void execute(PrgState state)
        {

            ImyDict<int, Tuple<string, StreamReader>> fileTable = state.getFileTable();
            ImyDict<string, int> symTable = state.getSymTable();
		
		    try {
                if (fileTable.isInTuple(this.filename))
                    {
                        throw new StmtException("File allready opened");
                    }
            } catch (Exception e1) {
                throw new StmtException("Statement \"" + this.ToString() + "\" encountered a dictionary exception: " + e1.Message);
            }
            StreamReader buffReader;		
		    try {
                    buffReader = new StreamReader(filename);
                } catch (FileNotFoundException) {
                    throw new StmtException("File not found \"" + filename + "\"");
                }

            Tuple<string, StreamReader> entry = new Tuple<string, StreamReader>(filename, buffReader);
		    int id = fileTable.generateId();
            fileTable.add(id, entry);
		    symTable.add(var_file_id, id);
	}

    public override string ToString()
    {
        return "openFile(" + var_file_id + ", " + "\"" + filename + "\")";
    }

}
}
