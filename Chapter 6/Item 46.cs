using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter6.Item46
{
    static class Program
    {
        static void Main(string[] args)
        {
            Person my = new Person();
            Console.WriteLine(my.ToString());
            my.Change("Vasia","Pupkin");
            Console.WriteLine(my.ToString());

            Console.ReadKey();
        }
    }

    public partial class Person
    {
        public Person(string first="Alex",string last="Kaplunov")
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
