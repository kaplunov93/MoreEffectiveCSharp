using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter5.Item39
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> workers = new List<Employee>
            {
                new Employee("vasia","pupkin",2000,2),
                new Employee("vasia","fedorov",2000,3),
                new Employee("vasia","ivanov",2000,5),
                new Employee("vasia","volkov",2000,10),
                new Employee("vasia","durov",22000,22),
                new Employee("vasia","vetkin",2000,30),
                new Employee("vasia","chrushov",2000,13),
                new Employee("petia","pupkin",4000,1),
            };
            Console.WriteLine("\tBefore Update");
            foreach (var w in workers)
                Console.WriteLine(w.ToString());

            var update = workers.Change(x=> { x.salary *= 1.05M; return x; }, x=>x.WorkAge>10&&x.salary<4000).ToList();
            workers = update;

            Console.WriteLine("\n\tAfter Update");
            foreach (var w in workers)
                Console.WriteLine(w.ToString());

            
            Console.ReadKey();
        }

    }

    static class EmployeeExt
    {
        static public IEnumerable<Employee> Change(this IEnumerable<Employee> e,Func<Employee,Employee> what, Func<Employee, bool> predicate)
        {
            var ch = (from s in e where predicate(s) select what(s)).ToList();
            var unch = (from s in e where !predicate(s) select s).ToList();
            ch.AddRange(unch);
            return ch;
        }
    }


    class Employee
    {
        public Employee(string first, string last, decimal sal, int workage)
        {
            FirstName = first;
            LastName = last;
            salary = sal;
            WorkAge = workage;
        }

        public override string ToString()
        {
            return string.Format("Name: {0},\tSalary: {1},\tWork Age: {2}", Name, salary, WorkAge);
        }
        private string FirstName;
        private string LastName;
        public string Name
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        public decimal salary
        {
            get;
            set;
        }

        public int WorkAge
        {
            get;
            set;
        }
    }
}
