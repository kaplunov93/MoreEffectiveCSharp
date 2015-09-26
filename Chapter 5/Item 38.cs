using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter5.Item38
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

            Console.WriteLine("\tWorkers wtih work age > 10");
            var oldWorkers = workers.Filter(X=>X.WorkAge>10);
            foreach (var i in oldWorkers)
                Console.WriteLine(i.ToString());

            Console.WriteLine("\n\tOld Workers wtih salary < 4000");
            var smallSalary = oldWorkers.Filter(x=>x.salary<4000);
            foreach (var i in smallSalary)
                Console.WriteLine(i.ToString());


            Console.ReadKey();
        }
        
    }

    static class EmployeeExt
    {
        static public IEnumerable<Employee> Filter(this IEnumerable<Employee> e,Func<Employee,bool> filter)
        {
            return from s in e where filter(s) select s;
        }
    }


    class Employee
    {
        public Employee(string first,string last, decimal sal,int workage)
        {
            FirstName = first;
            LastName = last;
            salary = sal;
            WorkAge = workage;
        }

        public override string ToString()
        {
            return string.Format("Name: {0},\tSalary: {1},\tWork Age: {2}",Name,salary,WorkAge);
        }
        private string FirstName;
        private string LastName;
        public string Name
        {
            get
            {
                return string.Format("{0} {1}",FirstName,LastName);
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
