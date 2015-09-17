using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter3.Item17
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int> {1,2,3,4,5,6,1,2,5,7,9 };
            Console.Write("Uniques:\t");
            foreach (int i in Unique(ints))
                Console.Write("{0}\t",i);
            Console.Write("\nSquares:\t");
            foreach (int i in Square(Unique(ints)))
                Console.Write("{0}\t", i);

            Console.ReadKey();
        }

        static IEnumerable<int> Square(IEnumerable<int> objs)
        {
            foreach (int obj in objs)
            {
                yield return obj * obj;
            }
        }

        static IEnumerable<T> Unique<T>(IEnumerable<T> objs)
        {
            List<T> uniq = new List<T>();
            foreach(T obj in objs)
            {
                if(!uniq.Contains(obj))
                {
                    uniq.Add(obj);
                    yield return obj;
                }
            }
        }
    }
}
