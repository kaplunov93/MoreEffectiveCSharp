using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MECS.Chapter4.Item34
{
    static class Program
    {
        static void Main(string[] args)
        {
            //List<int> ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<double> ints = new List<double> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ints.All(x=> { Console.Write("{0} ", x); return true; });
            Console.WriteLine("\n");
            var changed = ints.Change(x=>x*5);
            changed.All(x => { Console.Write("{0} ", x); return true; });
            Console.WriteLine("\n");
            changed = changed.Change(x=>(x+5)*5/10);
            changed.All(x => { Console.Write("{0} ", x); return true; });

            Console.ReadKey();
        }
        /// <summary>
        /// Change input sequence by changing function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">This input sequence</param>
        /// <param name="transform">Function that speak how change sequence</param>
        /// <returns></returns>
        static IEnumerable<T> Change<T>(this IEnumerable<T> sequence,Func<T,T> changer)
        {
            foreach (var s in sequence)
                yield return changer(s);
        }


    }


}
