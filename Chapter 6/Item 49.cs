using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Timers;

namespace MECS.Chapter6.Item49
{
    static class Program
    {
        static void Main(string[] args)
        {

            DateTime now = DateTime.Now;
            LargeMatrix m = new LargeMatrix();
            WeakReference w = new WeakReference(m);
            m = null;

            DateTime now1 = DateTime.Now;
            Console.WriteLine((now1-now).TotalSeconds);
            
            now = DateTime.Now;
            m = w.Target as LargeMatrix;
            if (m == null)
                m = new LargeMatrix();
            now1 = DateTime.Now;
            Console.WriteLine((now1 - now).TotalSeconds);
            
            Console.ReadKey();
        }

        class LargeMatrix
        {
            public int[,] matrix;

            public LargeMatrix()
            {
                matrix = new int[1000, 1000];
            }
        }
        
    }

}
