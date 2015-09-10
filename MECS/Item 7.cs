using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter1.Item7
{
    class Program
    {
        static void Main(string[] args)
        {
            IPrinter A = new Base();
            IPrinter B = new Derived();
            Print(A);
            Print(B);

            Console.ReadKey();
        }

        //Generic method like universal function for all lists in this example
        public static void Print<T>(T obj) where T :IPrinter
        {
            Console.Write("Prints:\t");
            obj.Print();
        }

        public interface IPrinter
        {
            void Print();
        }

        public class Base : IPrinter
        {
            public virtual void Print()
            {
                Console.WriteLine("Base");
            }
        }

        public class Derived : Base,IPrinter
        {
            public override void Print()
            {
                Console.WriteLine("Derived");
            }
        }
    }
}
