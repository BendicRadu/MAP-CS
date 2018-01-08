using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Utils
{
    public interface ImyStack<T>
    {
        bool isEmpty();
        T pop();
        void push(T elem);
    }
}
