using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Utils
{
    class MyTDict : ImyDict<int, Tuple<string, StreamReader>>
    {

        int id = 0;
        Dictionary<int, Tuple<string, StreamReader>> dict;

        public MyTDict()
        {
            dict = new Dictionary<int, Tuple<string, StreamReader>>();
        }
        
        public void add(int key, Tuple<string, StreamReader> value)
        {
            dict.Add(key, value);
        }

        public int generateId()
        {
            this.id += 1;
            return this.id;
        }

        public Tuple<string, StreamReader> get(int key)
        {
            return dict[key];
        }

        public bool isInTuple(string name)
        {
            foreach ( var t in dict.Values)
            {
                if (name.Equals(t.Item1))
                {
                    return true;
                }
            }
            return false;
        }

        public void remove(int key)
        {
            this.dict.Remove(key);
        }


        public override string ToString()
        {
            string str = "File Table: \n";

            foreach (var item in dict)
            {
                str += item.Key.ToString() + " -> " + item.Value.Item1.ToString() + '\n';
            }

            str += '\n';

            return str;
        }

    }
}
