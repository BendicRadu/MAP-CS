using MAP.Controller;
using MAP.Exceptions;
using MAP.Expressions;
using MAP.Model;
using MAP.Statements;
using MAP.Utils;
using MAP.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MAP
{
    class Program
    {
        static void Main(string[] args)
        {

            ImyStack<Istmt> stk1 = new MyStack<Istmt>();
            ImyDict<string, int> s1 = new MyDict<string, int>();
            ImyList<int> o1 = new MyList<int>();
            ImyDict<int, Tuple<string, StreamReader>> f1 = new MyTDict();

            /*
            a = 2 - 2;
            If a Then v = 2 Else v = 3;
            Print(v)
            */

            Istmt stmt1 =

                new Compound(
                        new Assign("a", new Arith(new Const(2), new Const(2), 1)),
                        new Compound(
                                new If(new Var("a"), new Assign("v", new Const(2)), new Assign("v", new Const(3))),
                                new Print(new Var("v"))
                                )
                             );


            stk1.push(stmt1);
            PrgState state1 = new PrgState(stk1, s1, o1, f1);

            Ctrl ctr1 = new Ctrl(state1);

            ImyStack<Istmt> stk2 = new MyStack<Istmt>();
            ImyDict<string, int> s2 = new MyDict<string, int>();
            ImyList<int> o2 = new MyList<int>();
            ImyDict<int, Tuple<string, StreamReader>> f2 = new MyTDict();

            /*
            a = 2 - 2;
            If a Then v = 2 Else v = 3;
            Print(v)
            */

            Istmt stmt2 =

                new Compound(
                        new OpenFile("a", "C:\\Users\\Radu\\documents\\visual studio 2015\\Projects\\MAP\\MAP\\test.txt"),
                        new Compound(
                                new Read(new Var("a"), "v"),
                                new Compound(
                                    new Read(new Var("a"), "v"),
                                    new Print(new Var("v"))
                                )
                                )
                            );


            stk2.push(stmt2);
            PrgState state2 = new PrgState(stk2, s2, o2, f2);

            Ctrl ctr2 = new Ctrl(state2);

            TextMenu menu = new TextMenu();
            menu.addCommand(new ExitCommand("0", "Exit"));
            menu.addCommand(new RunExample("1", stmt1.ToString(), ctr1));
            menu.addCommand(new RunExample("2", stmt2.ToString(), ctr2));

            try
            {
                menu.show();
            }
            catch(EndException)
            {
                return;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }
    }
}
