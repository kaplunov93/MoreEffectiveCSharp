using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MECS.Chapter2.Item15
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker();

            //worker.BadDoWork();
            worker.DoWork();

            Console.ReadKey();
        }

        class Worker
        {
            public event EventHandler<EventArgs> RaiseProgress;
            private object syncHandle = new object();
            private int progressCounter = 0;
            
            public int Progress
            {
                get
                {
                    lock (syncHandle)
                        return progressCounter;
                }
            }

            public void BadDoWork()
            {
                for(int count=0;count<100;count++)
                {
                    lock(syncHandle)
                    {
                        System.Threading.Thread.Sleep(100);
                        progressCounter++;
                        if (RaiseProgress != null)
                            RaiseProgress(this, EventArgs.Empty);
                    }
                }
            }

            static void engine_RaiseProgress(object sender, EventArgs e)
            {
                Worker engine = sender as Worker;
                if (engine != null)
                    Console.WriteLine(engine.Progress);
            }

            public void DoWork()
            {
                for (int count = 0; count < 100; count++)
                {
                    lock (syncHandle)
                    {
                        System.Threading.Thread.Sleep(100);
                        progressCounter++;
                    }
                    if (RaiseProgress != null)
                        RaiseProgress(this, EventArgs.Empty);
                }
            }
        }
    }
}
