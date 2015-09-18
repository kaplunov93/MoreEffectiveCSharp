using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter3.Item19
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            foreach (int i in CreateSquence<int>(100,i=>1+i*5))
                Console.Write("{0} ", i);

            Console.WriteLine();

            Console.ReadKey();
        }

        static IEnumerable<T> CreateSquence<T>(int count,Func<int,T> method)
        {
            IList<T> list = new List<T>(count);
            for (int i = 0; i < count; i++)
                list.Add(method(i));
            return list;
        }

        
    }
}
