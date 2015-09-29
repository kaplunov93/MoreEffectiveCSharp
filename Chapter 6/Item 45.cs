using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter6.Item45
{
    static class Program
    {
        static void Main(string[] args)
        {
            int? j= default(int?);
            int i = default(int);

            try
            {
                i = (int) j;
            }
            catch 
            {
                Console.WriteLine("Oops Can't convert int? to int ");
            }

            try
            {
                string s = ((object) j).ToString();
                Console.WriteLine(s);
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("Oops");
            }


            Console.ReadKey();
        }                
    }
}
