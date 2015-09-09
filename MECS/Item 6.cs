using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter1.Item6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strs = new List<string> { "sdfsd", "sfgfhj", "3ertttw" };
            List<int> ints = new List<int> { 1, 2, 3, 4, 5 };
            List<Person> persons = new List<Person> { new Person(), new Person("Aliona", "Kaplunova") };

            PrintList(strs);
            PrintList(ints);
            PrintList(persons);

            persons = DoSomething(persons, (x) => { x.Add(new Person()); return x; });
            ints = DoSomething(ints, (x) => { x.Reverse(); return x; });
            strs = DoSomething(strs, (x) => { for (int i=0;i<x.Count; i++) x[i] += " Changed"; return x; });

            PrintList(strs);
            PrintList(ints);
            PrintList(persons);

            Console.ReadKey();
        }

        //Generic method like universal function for all lists in this example
        public static void PrintList<T>(IList<T> objs)
        {
            foreach (T obj in objs)
                Console.WriteLine(obj.ToString());
        }

        public static T DoSomething<T>(T obj,Func<T,T> func)
        {
            return func(obj);
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
