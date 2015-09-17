using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter3.Item18
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            foreach (int i in Change(ints, i => i * i))
                Console.Write("{0} ",i);

            Console.WriteLine();

            foreach (int i in EachN(ints,2))
                Console.Write("{0} ", i);

            Console.WriteLine();

            foreach (int i in Filter(ints, i=>i%2!=0))
                Console.Write("{0} ", i);

            Console.ReadKey();
        }

        static IEnumerable<T> Filter<T>(IEnumerable<T> objs,Predicate<T> pred)
        {
            foreach (T obj in objs)
            {
                if (pred(obj))
                    yield return obj;
            }
        }

        static IEnumerable<T> EachN<T>(IEnumerable<T> objs, int n)
        {
            int count = 0;
            foreach (T obj in objs)
            {
                if(++count%n==0)
                    yield return obj;
            }
        }

        static IEnumerable<T> Change<T>(IEnumerable<T> objs, Func<T,T> method)
        {
            foreach (T obj in objs)
            {
                yield return method(obj);
            }
        }

        
    }
}
