using MAP.Statements;
using MAP.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Model
{
    public class PrgState
    {
        ImyStack<Istmt> stk;
        ImyDict<string, int> sym;
        ImyDict<int, Tuple<string, StreamReader>> file;
        ImyList<int> output;

        public PrgState(ImyStack<Istmt> stk, ImyDict<string, int> sym, ImyList<int> output, ImyDict<int, Tuple<string, StreamReader>> file)
        {
            this.stk = stk;
            this.sym = sym;
            this.output = output;
            this.file = file;
        }

        public ImyStack<Istmt> getExeStack()
        {
            return this.stk;
        }

        public ImyDict<string, int> getSymTable()
        {
            return this.sym;
        }
        public ImyList<int> getOutput()
        {
            return this.output;
        }

        public ImyDict<int, Tuple<string, StreamReader>> getFileTable()
        {
            return this.file;
        }


        public void oneStep()
        {
            Istmt s = stk.pop();
            s.execute(this);
        }

        public override string ToString()
        {
            string str = "";
            str += this.stk.ToString();
            str += this.sym.ToString();
            str += this.file.ToString();
            str += this.output.ToString();
            str += "\n";
            return str;
        }

        public bool stackIsEmpty()
        {
            return stk.isEmpty();
        }

    }
}
