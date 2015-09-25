using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter5.Item36
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var table = from a in ints
                        from b in ints
                        select new {A=a,B=b,S=a*b };
            foreach (var c in table)
                Console.WriteLine("{0}\t{1}\t{2}",c.A,c.B,c.S);

            Console.ReadKey();
        }
    }
}
