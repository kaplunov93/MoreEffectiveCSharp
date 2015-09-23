using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MECS.Chapter3.Item27
{
    class Program
    {
        static void Main(string[] args)
        {
            OutClass my1 = new OutClass(); // flag=true
            OutClass my2 = new OutClass(false);

            my1.SomeWork();
            my2.SomeWork();

            Console.ReadKey();
        }

        interface IClasses
        {
            void SomeWork();
        }

        class InerClass1 : IClasses
        {
            public void SomeWork()
            {
                Console.WriteLine("Work Inner Class 1");
            }
        }

        class InerClass2 : IClasses
        {
            public void SomeWork()
            {
                Console.WriteLine("Work Inner Class 2");
            }
        }

        class OutClass
        {
            private IClasses impl;

            public OutClass(bool flag=true)
            {
                if (flag)
                    impl = new InerClass1();
                else
                    impl = new InerClass2();
            }

            public void SomeWork()
            {
                impl.SomeWork();
            }
        }

    }
}
