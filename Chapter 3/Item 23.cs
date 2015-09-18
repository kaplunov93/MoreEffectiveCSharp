using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter3.Item23
{
    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> decs = new List<decimal> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            BankAccounts first = new BankAccounts();

            first.on_add += n => Console.WriteLine("First add {0}",n);

            first +=20;

            BankAccounts second = new BankAccounts();
            second.on_add += n => Console.WriteLine("Second add {0}", n);
            second += decs;
            first += second;

            Console.WriteLine("Sum of first = {0}", first.Sum());
            Console.WriteLine("Sum of both = {0}", new BankAccounts().Add(first).Add(second).Sum());
            Console.WriteLine("first: {0}", first.ToString());

            Console.ReadKey();
        }

        class BankAccounts
        {
            private List<decimal> money;
            public List<decimal> Money
            {
                get { return money; }
                set { }
            }

            public delegate void money_add(decimal m);

            public event money_add on_add;

            public BankAccounts(List<decimal> mon = null)
            {
                if (mon == null)
                    money = new List<decimal>();
                else
                    money = mon;
            }

            public static BankAccounts operator +(BankAccounts my, decimal right)
            {
                my.Add(right);
                return my;
            }

            public static BankAccounts operator +(BankAccounts my, IEnumerable<decimal> mon)
            {
                my.AddRange(mon);
                return my;
            }

            public static BankAccounts operator +(BankAccounts my, BankAccounts right)
            {
                return my.Add(right);
            }

            public void Add(decimal mon)
            {
                money.Add(mon);
                try
                { on_add(mon); }
                catch { }
            }

            public BankAccounts AddRange(IEnumerable<decimal> mon)
            {
                foreach (decimal i in mon)
                    Add(i);
                return this; 
            }

            public BankAccounts Add(BankAccounts mon)
            {
                return AddRange(mon.Money);
            }

            public decimal Sum()
            {
                decimal total = 0;
                foreach (decimal m in money)
                    total += m;
                return total;
            }

            public override string ToString()
            {
                StringBuilder str = new StringBuilder();
                foreach (decimal i in money)
                    str.AppendFormat("{0} ",i);
                return str.ToString();
            }
        }


    }
}
