using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter5.Item40
{
    static class Program
    {
        static void Main(string[] args)
        {
            List<string> strs = new List<string> {"q","qw","qwe"};

            foreach (var n in strs.Work(3,Method1,Method2,Method3))
                Console.WriteLine(n);
            foreach (var n in strs.Work(1,(n)=>from m in n select m.Length.ToString()))
                Console.WriteLine(n);

            Console.ReadKey();
        }

        public static IEnumerable<string> Method1(IEnumerable<string> input)
        {
            return from n in input select n;
        }

        public static IEnumerable<string> Method2(IEnumerable<string> input)
        {
            return from n in input select n+" "+n;
        }

        public static IEnumerable<string> Method3(IEnumerable<string> input)
        {
            return from n in input where n.Length>4 select n;
        }

        /// <summary>
        /// DOing work on IEnumerable type of string
        /// </summary>
        /// <param name="datas"> Input IEnumerable</param>
        /// <param name="count">Count of Functions</param>
        /// <param name="method1">Function 1</param>
        /// <param name="method2">Function 2</param>
        /// <param name="method3">Function 3</param>
        /// <returns></returns>
        public static IEnumerable<string> Work(this IEnumerable<string> datas,
            int count,
            Func<IEnumerable<string>, IEnumerable<string>> method1,
            Func<IEnumerable<string>, IEnumerable<string>> method2=null,
            Func<IEnumerable<string>, IEnumerable<string>> method3=null)
        {
            if (count == 1)
                return method1(datas);
            if (count == 2 && method2 != null)
                return method2(method1(datas));
            if (count == 2 && method2 != null)
                return method1(method1(datas));
            if(count==3 && method2 == null && method3 == null)
                return method1(method1(method1(datas)));
            if (count == 3 && method2 != null && method3 == null)
                return method1(method2(method1(datas)));
            return method3(method2(method1(datas)));

        }
    }
}
