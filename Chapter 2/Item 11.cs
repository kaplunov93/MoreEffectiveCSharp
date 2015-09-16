using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MECS.Chapter2.Item11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ThreadPool Working in {0}", ThreadPoolThreads(10).ToString());
            Console.WriteLine("Manual Threads Working in {0}", ManualThreads(10).ToString());


            Console.ReadKey();
        }
        
        /// <summary>
        /// Thread Pool better than Manual Threads
        /// </summary>
        /// <param name="numThreads"></param>
        /// <returns></returns>
        private static double ThreadPoolThreads(int numThreads)
        {
            Stopwatch start = new Stopwatch();
            using (AutoResetEvent e = new AutoResetEvent(false))
            {
                int workerThreads = numThreads;
                start.Start();
                for (int thread = 0; thread < numThreads; thread++)
                    System.Threading.ThreadPool.QueueUserWorkItem(
                    (x) =>
                    {
                        for (int i = 0;    i < 10; i++)
                        {
                            if (i % numThreads == thread)
                            {
                                double answer = Hero.FindRoot(i);
                            }
                        }
                        if (Interlocked.Decrement(
                            ref workerThreads) == 0)
                        {
                            e.Set();
                        }
                    });
                    e.WaitOne();
                    start.Stop();
                    return start.ElapsedMilliseconds;
            }
        }

        private static double ManualThreads(int numThreads)
        {
            Stopwatch start = new Stopwatch();
            using (AutoResetEvent e = new AutoResetEvent(false))
            {
                int workerThreads = numThreads;
                start.Start();
                for (int thread = 0; thread < numThreads; thread++)
                {
                    System.Threading.Thread t = new Thread(
                    () =>
                    {
                        for (int i = 0;i < 10; i++)
                        {
                            if (i % numThreads == thread)
                            {
                                double answer = Hero.FindRoot(i);
                            }
                        }
                        if (Interlocked.Decrement(ref workerThreads) == 0)
                        {
                            e.Set();
                        }
                    });
                    t.Start();
                }
                e.WaitOne();
                start.Stop();
                return start.ElapsedMilliseconds;
            }
        }

        public static class Hero
        {
            private const double TOLERANCE = 1.0E-8;
            public static double FindRoot(double number)
            {
                double guess = 1;
                double error = Math.Abs(guess * guess - number);
                while (error > TOLERANCE)
                {
                    guess = (number / guess + guess) / 2.0;
                    error = Math.Abs(guess * guess - number);
                }
                return guess;
            }
        }
        
    }
}
