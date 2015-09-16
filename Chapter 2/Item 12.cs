using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MECS.Chapter2.Item12
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> threads = new List<int>();
            int works = 20;
            int k = works-1;
            for(int i=0; i< works; i++ )
             {
                BackgroundWorker BgWorker = new BackgroundWorker();
                int n = i;
                 BgWorker.DoWork += new DoWorkEventHandler(
                   (s, e) =>
                   {
                       Debug.WriteLine("Work {1} in thread {0}", Thread.CurrentThread.ManagedThreadId, n);
                       if (!threads.Contains(Thread.CurrentThread.ManagedThreadId)) threads.Add(Thread.CurrentThread.ManagedThreadId);
                   });
                BgWorker.RunWorkerAsync();
                BgWorker.RunWorkerCompleted += (s, e) => k--;
            } 
            
            Console.WriteLine("Main thread {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Wait...");
            while (k > 0) { }
            Console.WriteLine("Count of Backgtround threads = {0}",threads.Count);

            Console.ReadKey();
        }
    }
}
