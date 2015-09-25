using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MECS.Chapter4.Item33
{
    static class Program
    {
        static void Main(string[] args)
        {
            // BAD IDEA YOU HAVE SURPRISED VALUES
            int index = 0;
            Func<IEnumerable<int>> sequence = () => Generate<int>(10,()=>index++);
            foreach (var n in sequence())
                Console.Write("{0} ",n);
            Console.WriteLine("\n");

            index = 30;
            foreach (var n in sequence())
                Console.Write("{0} ", n);
            Console.WriteLine("\n");

            index = 100;
            foreach (var n in sequence())
                Console.Write("{0} ", n);
            Console.WriteLine("\n");

            //---***---END---***---

            // THIS IS BETTER, WE KNOW WE HAVE!
            Func<IEnumerable<int>> sequence1 = () => Generate<int>(10,1, (x) => x++);
            foreach (var n in sequence1())
                Console.Write("{0} ", n);
            Console.WriteLine("\n");
            //___***___END___***___

            Console.ReadKey();
        }

        static IEnumerable<T> Generate<T>(int count,Func<T> method)
        {
            for (int i = 0; i < count; i++)
                yield return method();
        }

        static IEnumerable<T> Generate<T>(int count,int num, Func<int,T> method)
        {
            for (int i = num; i < num+count; i++)
                yield return method(i);
        }


    }


}
