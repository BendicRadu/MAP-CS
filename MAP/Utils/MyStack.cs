using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Utils
{
    class MyStack<T> : ImyStack<T>
    {

        Stack<T> stack;

        public MyStack()
        {
            stack = new Stack<T>();
        }

        public bool isEmpty()
        {
            return stack.Count == 0;
        }

        public T pop()
        {
            return stack.Pop();
        }

        public void push(T elem)
        {
            stack.Push(elem);
        }

        public override string ToString()
        {
            string str = "";

            str += "Stack: \n";
            
            foreach (T elem in stack.ToArray())
            {
                str += elem.ToString() + '\n';
            }


            str += '\n';
      
            return str;
        }
    }
}
