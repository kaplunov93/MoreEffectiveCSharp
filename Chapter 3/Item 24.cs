using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter3.Item24
{
    class Program
    {
        public delegate int Mydelegate(object args);
        /// <summary>
        /// No problems in derived class
        /// </summary>
        public event Mydelegate GoodEvent;
        /// <summary>
        /// Have a problems where doing derived class from based class, You must to write Raise method to event
        /// </summary>
        public virtual event Mydelegate BadEvent;

        static void Main(string[] args)
        {
            

            Console.ReadKey();
        }
        
    }
}
