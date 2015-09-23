using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MECS.Chapter3.Item25
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker my = new Worker();
            my.TryDoWork(); //Good
            my.DoWork();    //Worth

            Console.ReadKey();
        }

        class Worker
        {
            public bool TryDoWork()
            {
                if (!TestCondition())
                    return false;
                Work(); // maybe throw exception
                return true;
            }

            private bool TestCondition()
            {
                //test parameters & etc...
                return true;
            }

            public void DoWork()
            {
                Work(); // will throw exception
            }
            private void Work()
            {
                Thread.Sleep(100);
            }

        }

    }
}
