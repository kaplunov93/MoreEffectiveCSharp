using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter5.Item37
{
    class Program
    {
        static void Main(string[] args)
        {
            var allNums = AllNumbers();
            //Good
            var smallNums = allNums.Take(10);

            foreach (var i in smallNums)
                Console.Write("{0} ",i);
            Console.WriteLine("\n");

            //Bad
            smallNums = from n in allNums where n < 10 select n;

            foreach (var i in smallNums)
                Console.Write("{0} ", i);
            Console.WriteLine("\n");

            Console.ReadKey();
        }

        static IEnumerable<int> AllNumbers()
        {
            for (int i = 0; i <= int.MaxValue; i++)
                yield return i;
        }
    }
}
