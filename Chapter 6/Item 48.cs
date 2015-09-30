using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter6.Item48
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t Don't DO THIS\n");

            D d = new D("Hello World from class D");

            Console.WriteLine("\n\tYOU CAN DO THIS");

            D1 d1 = new D1("Hello World from class D");

            Console.ReadKey();
        }

        class B
        {
            public B()
            {
                Console.WriteLine("---Working Base Class Cnsturctor---");
                VFunc();
            }

            public virtual void VFunc()
            {
                Console.WriteLine("COnstructed in Class B");
            }
        }

        class D:B
        {
            private string message = "Constructed in Class D";
            public D(string msg)
            {
                Console.WriteLine("\n---Working Derived Class Cnsturctor---");
                message = msg;
                VFunc();
            }

            public override void VFunc()
            {
                Console.WriteLine(message);
            }
        }

        abstract class B1
        {
            public B1()
            {
                
            }

            public abstract void VFunc();
            
        }

        class D1 : B1
        {
            private string message = "Constructed in Class D";
            public D1(string msg)
            {
                Console.WriteLine("\n---Working Derived Class Cnsturctor---");
                message = msg;
                VFunc();
            }

            public override void VFunc()
            {
                Console.WriteLine(message);
            }
        }
    }

}
