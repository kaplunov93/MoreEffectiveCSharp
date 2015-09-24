using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter4.Item29
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            for (int i = 0; i < 10; i++)
                customers.Add(new Customer(order: DateTime.Now-TimeSpan.FromDays(i)));
            customers.PrintAll();
            DateTime from = DateTime.Now - TimeSpan.FromDays(6);
            DateTime to = DateTime.Now - TimeSpan.FromDays(3);
            Console.WriteLine("--- from {0} to {1} ---",from.ToShortDateString(),to.ToShortDateString());
            customers.PrintForTime(from, to);

            Console.ReadKey();
        }
    }

    public class Customer
    {
        public Customer(string first="ALex",string last="Kaplunov",DateTime order=new DateTime())
        {
            FirstName = first;
            LastName = last;
            LastOrder = order;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name
        {
            get { return string.Format("{0} {1}",FirstName,LastName); }
        }

        public DateTime LastOrder { get; set; }

        public override string ToString()
        {
            return string.Format("Customer: {0}, Last Order: {1}",Name,LastOrder.ToShortDateString());
        }
    }

    public static class CustomerExtensions
    {
        public static void PrintAll (this IEnumerable<Customer> customers)
        {
            foreach (var c in customers)
                Console.WriteLine(c.ToString());
        }

        public static IEnumerable<Customer> GetForTime(this IEnumerable<Customer> customers, DateTime from, DateTime to)
        {
            return from c in customers where c.LastOrder > @from & c.LastOrder < @to select c;
        }

        public static void PrintForTime(this IEnumerable<Customer> customers, DateTime from,DateTime to)
        {
            customers.GetForTime(from, to).PrintAll();
        }

        /// etc...
    }
}
