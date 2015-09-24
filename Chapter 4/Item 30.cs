using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MECS.Chapter4.Item30
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i=0;i<4;i++)
            {
                var x = RandomNum();
                Console.WriteLine("Type: {0}, Value: {1}",x.GetType().Name,x);
                Thread.Sleep(100);
            }

            Console.ReadKey();
        }

        static object RandomNum()
        {
            var x =new Random().Next(1,8);
            if (x == 1)
                return(double) new Random().Next(100) * 100 / 6;
            if (x == 2)
                return (int) new Random().Next(200) * 100 / 6;
            if (x == 3)
                return (float) new Random().Next(300) * 100 / 6;
            if (x == 4)
                return (short) new Random().Next(400) * 100 / 6;
            return null;
        }
    }

    
}
