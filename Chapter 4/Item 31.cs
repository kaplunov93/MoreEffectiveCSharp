using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MECS.Chapter4.Item31
{
    class Program
    {
        static void Main(string[] args)
        {
            var point = new { X = 1, Y=2 };
            for (int i = 2; i < 6; i++)
            {
                Console.WriteLine("{0} Point: X= {1}, Y= {2}",i-1,point.X,point.Y);
                point=Transform(point,x => new { X=x.X*2, Y=x.Y*2});
            }

            Console.ReadKey();
        }

        static T Transform<T>(T x,Func<T,T> trnsformator)
        {
            return trnsformator(x);
        }
    }


}
