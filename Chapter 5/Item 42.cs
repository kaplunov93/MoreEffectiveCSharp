using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter5.Item42
{
    static class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = ints.Search(n=>n<4,n=>n*n);

            Console.WriteLine("Type of input\t{0},\nType of output\t{1}\n",ints.GetType().Name,result.GetType().Name);

            Console.Write("Input Sequence :\t");
            foreach (var n in ints)
                Console.Write("{0} ",n);
            Console.WriteLine("\n");

            Console.Write("Output Sequence :\t");
            foreach (var n in result)
                Console.Write("{0} ", n);
            Console.WriteLine("\n");

            Console.ReadKey();
        }

        static IQueryable<T> Search<T>(this IQueryable<T> sequence,Func<T,bool> predicate, Func<T,T> what)
        {
            return from s in sequence where predicate(s) select what(s);
        }

        static IQueryable<T> Search<T>(this IEnumerable<T> sequence, Func<T, bool> predicate, Func<T, T> what)
        {
            return sequence.AsQueryable().Search(predicate,what);
        }
    }
}
