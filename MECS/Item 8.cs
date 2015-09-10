using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter1.Item8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int> { 1, 2, 3, 4, 5 };
            StringGenerator str = new StringGenerator();
            str.Add(ints);
            Console.WriteLine(str.ToString());

            Console.ReadKey();
        }

        public class StringGenerator
        {
            private StringBuilder str = new StringBuilder();
            
            public void Add<T>(IEnumerable<T> objs)
            {
                foreach (T obj in objs)
                {
                    if (str.Length > 0)
                        str.Append(", ");
                    str.Append("\"");
                    str.Append(obj.ToString());
                    str.Append("\"");
                }
            }

            public override string ToString()
            {
                return str.ToString();
            }
        }
        
    }
}
