using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter3.Item20
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<string> strs = new List<string> { "q","qw","qwe"};
            int total = 0;
            Console.WriteLine("Sum of numbers = {0}",Sum(ints,total,(i,tot)=>tot+i));
            total = 0;
            Console.WriteLine("Sum of strings length = {0}", Sum(strs, total, (i, tot) => tot + i.Length));

            Console.ReadKey();
        }

        static TResult Sum<T,TResult>(IEnumerable<T> objs,TResult total, Func<T, TResult, TResult> method)
        {
            foreach (T obj in objs)
                total = method(obj, total);
            return total;
        }


    }
}
