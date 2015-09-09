using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter1.Item5
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.ReadKey();
        }

        interface IEngine
        {
            void DoWork();
        }

        //Better to use dispose out from generic class
        class EngineDriver<T> where T :IEngine
        {
            private T driver;
            public EngineDriver(T driver)
            {
                this.driver = driver;
            }
            public void GetThingsDone()
            {
                driver.DoWork();
            }
        }

        sealed class BadEngineDriver<T> : IDisposable where T : IEngine, new()
        {
            private T driver;

            public void GetThingsDone()
            {
                if (driver == null)
                    driver = new T();
                driver.DoWork();
            }

            public void Dispose()
            {
                IDisposable resource = driver as IDisposable;
                if (resource != null)
                {
                    resource.Dispose();
                }
            }
        }

    }
}
