using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter5.Item43
{
    static class Program
    {
        static void Main(string[] args)
        {
            //IEnumerable<int> ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            IEnumerable<int> ints = new List<int> { 1 };

            //IEnumerable<int> ints = new List<int> ();

            if (ints.Empty())
                Console.WriteLine("Empty Sequence");
            else
                Console.WriteLine("Sequence with items");

            if (ints.HaveMoreThanOne())
                Console.WriteLine("Sequence Have more then one item");
            else
                Console.WriteLine("Sequence have one or zero items");

            if (ints.HaveOneItem())
                Console.WriteLine("Sequence Have one item");
            else
                Console.WriteLine("Sequence have more then one or zero items");



            Console.ReadKey();
        }

        static bool HaveOneItem<T>(this IEnumerable<T> sequence)
        {
            bool flag = false;
            if (!sequence.Empty())
            {
                flag = true;
                try
                {
                    sequence.Single();
                }
                catch
                {
                    flag = false;
                }
            }
            return flag;
        }

        static bool HaveMoreThanOne<T>(this IEnumerable<T> sequence)
        {
            bool flag = false;
            if (!sequence.Empty())
            {
                try
                {
                    sequence.Single();
                }
                catch
                {
                    flag = true;
                }
            }
            return flag;

        }

        static bool Empty<T>(this IEnumerable<T> sequence)
        {
            bool flag = false;
            try
            {
                sequence.First();
            }
            catch
            {
                flag = true;
            }
            return flag;

        }
    }
}
