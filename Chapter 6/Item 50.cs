using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Timers;

namespace MECS.Chapter6.Item50
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ImutablePerson p1 = new ImutablePerson("Alex", "");
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("{0} in {1}",e.Message,e.TargetSite.DeclaringType.ToString().Split('+').Last());
            }

            try
            {
                MutablePerson p1 = new MutablePerson("", "");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("{0} in {1}", e.Message, e.TargetSite.DeclaringType.ToString().Split('+').Last());
            }


            Console.ReadKey();
        }

        /// <summary>
        /// Imutable PErson class with Validation and explicit fields
        /// </summary>
        class ImutablePerson
        {
            public ImutablePerson(string first,string last)
            {
                FirstName = first;
                LastName = last;
            }

            private string _FirstName;
            private string _LastName;
            public string FirstName
            {
                get { return _FirstName; }
                private set
                {
                    if (string.IsNullOrEmpty(value))
                        throw new ArgumentException("First name can't be null or empty");
                    _FirstName = value;
                }
            }

            public string LastName
            {
                get { return _LastName; }
                private set
                {
                    if (string.IsNullOrEmpty(value))
                        throw new ArgumentException("Last name can't be null or empty");
                    _LastName = value;
                }
            }
        }

        /// <summary>
        /// Mutable Person Class with out validation on implicit fields
        /// </summary>
        class MutablePerson
        {
            public MutablePerson(string first="", string last="")
            {
                FirstName = first;
                LastName = last;
            }

            
            public string FirstName
            {
                get;
                set;
            }

            public string LastName
            {
                get;
                set;
            }

        }
   }

}
