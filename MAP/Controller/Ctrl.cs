using MAP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Controller
    {
        public class Ctrl
        {

        public PrgState state;
        public string fileName;

        public Ctrl(PrgState state)
        {
        this.state = state;
        }

        public void setLogFile(string name)
        {
            string path = "C:\\Users\\Radu\\documents\\visual studio 2015\\Projects\\MAP\\MAP\\Controller";
            this.fileName = path + "\\" + name + ".txt";
        }    

        public void oneStep()
        {
            state.oneStep();
        }

        public void allStep()
        {

            while (!state.stackIsEmpty())
            {
                logToFile();
                oneStep();
            }

            logToFile();
        }


        public void logToFile()
        {


            using (var outputFile = new StreamWriter(fileName, true))
            {
               
                outputFile.WriteLine(state.ToString());
            }
        }


        public override string ToString()
        {
            return state.ToString();
        }

        }
    }

