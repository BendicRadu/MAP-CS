using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Utils
{
    public interface ImyDict<Tkey, T>
    {

        void add(Tkey key, T value);
        T get(Tkey key);
        void remove(Tkey key);
        bool isInTuple(string name);
        int generateId();
    }
}
