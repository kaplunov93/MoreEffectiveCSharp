using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter4.Item28
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 25;
            int b = 20;
            Console.WriteLine("A < B ? {0}",a.Less(b));
            Console.WriteLine("A > B ? {0}",a.Greater(b));
            Console.WriteLine("A = B ? {0}",a.Equal(b));


            Console.ReadKey();
        }
    }

    public static class IComparableExtMethods 
    {
        public static bool Less<T>(this T left,T right) where T : IComparable<T>
        {
            if (left.CompareTo(right) < 0)
                return true;
            return false;
        }

        public static bool Greater<T>(this T left, T right) where T : IComparable<T>
        {
            if (left.CompareTo(right) > 0)
                return true;
            return false;
        }

        public static bool Equal<T>(this T left, T right) where T : IComparable<T>
        {
            if (left.CompareTo(right) == 0)
                return true;
            return false;
        }
    }
}
