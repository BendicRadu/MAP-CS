using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Utils
{
    class MyDict<Tkey, T> : ImyDict<Tkey, T>
    {
        protected Dictionary<Tkey, T> dict;

        public MyDict()
        {
            dict = new Dictionary<Tkey, T>();
        }

        public void add(Tkey key, T value)
        {

            if (dict.ContainsKey(key)){
                dict.Remove(key);
            }

            dict.Add(key, value);
        }

        public int generateId()
        {
            throw new NotImplementedException();
        }

        public T get(Tkey key)
        {
            return dict[key];
        }

        public bool isInTuple(string name)
        {
            throw new NotImplementedException();
        }

        public void remove(Tkey key)
        {
            this.dict.Remove(key);
        }

        public override string ToString()
        {
            string str = "Sym Table: \n";

            foreach (var item in dict)
            {
                str += item.Key.ToString() + " -> " + item.Value.ToString() + '\n';
            }

            str += '\n';

            return str;
  
        }



    }
}
