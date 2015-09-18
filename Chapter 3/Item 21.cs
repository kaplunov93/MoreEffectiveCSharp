using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter3.Item21
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.ReadKey();
        }

        static class BadUtilies
        {
            static T Sum<T>(T left,T right)
            {
                return left/*+right*/;
            }

            static T Max<T>(T left, T right) where T : IComparable<T>
            {
                if (left.CompareTo(right) > 0)
                    return left;
                return right;
            }

            //etc.....
        }

        static class GoodUtilites
        {
            static int Sum(int left,int right)
            {
                return left + right;
            }

            static double Sum(double left, double right)
            {
                return left + right;
            }

            static int Max(int left, int right)
            {
                return Math.Max(left, right);
            }

            static double Max(double left, double right)
            {
                return Math.Max(left, right);
            }

            //etc....
        }


    }
}
