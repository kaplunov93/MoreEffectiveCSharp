using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter1.Item2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strs = new List<string> { "sdfsd", "sfgfhj", "3ertttw" };
            List<int> ints = new List<int> { 1, 2, 3, 4, 5 };
            List<Person> persons = new List<Person> { new Person(), new Person("Aliona", "Kaplunova") };

            PrintList(strs);
            //PrintList(ints); // Oh no, now our method can't work with int because we have constraint, T like class;
            PrintList(persons);

            Console.ReadKey();
        }

        //Generic method like universal function for all lists where type is class in this example
        public static void PrintList<T>(IList<T> objs) where T :class
        {
            foreach (T obj in objs)
                Console.WriteLine(obj.ToString());
        }

        class Person
        {
            private string FN;
            private string LN;

            public Person(string fn = "Alex", string ln = "Kaplunov")
            {
                FN = fn;
                LN = ln;
            }
            public override string ToString()
            {
                return string.Format("First Name: {0}, Last Name: {1}", FN, LN);
            }
        }
    }
}
