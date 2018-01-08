using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Utils
{
    class MyList<T> : ImyList<T>
    {

        List<T> lst;

        public MyList()
        {
            lst = new List<T>();
        }

        public void add(T elem)
        {
            lst.Add(elem);
        }

        public override string ToString()
        {
            string str = "Output: \n";

            foreach (T elem in lst)
            {
                str += elem.ToString() + "\n";
            }

            str += '\n';

            return str;
        }
    }
}
