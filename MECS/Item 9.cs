using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter1.Item9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int> { 3, 2, 1, 5, 4, 7, 2, 0, 5, 9 };
            Tuple<int, int> minmax = MinMax(ints);
            Console.WriteLine("Min= {0}, Max= {1}",minmax.Item1,minmax.Item2);

            Console.ReadKey();
        }

        public static Tuple<T,T> MinMax<T>(IEnumerable<T> objs) where T :IComparable
        {
            T min=objs.First();
            T max=objs.First();
            foreach(T obj in objs)
            {
                if (obj.CompareTo(min)<0)
                    min = obj;
                if (obj.CompareTo(max) > 0)
                    max = obj;
            }
            return new Tuple<T, T>(min, max);
        }

    }
}
