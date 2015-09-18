using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter3.Item22
{
    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> decs = new List<decimal> { 1,2,3,4,5,6,7,8,9};
            BankAccounts first = new BankAccounts();
            BankAccounts second = new BankAccounts(decs);
            first += second;
            Console.WriteLine("Sum of first = {0}",first.Sum());
            Console.WriteLine("Sum of both = {0}",(first+second).Sum());

            Console.ReadKey();
        }

        class BankAccounts
        {
            private List<decimal> money;

            public BankAccounts(List<decimal> mon=null)
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

            public static BankAccounts operator +(BankAccounts my, BankAccounts right)
            {
                my.Add(right);
                return my;
            }

            public void Add(decimal mon)
            {
                money.Add(mon);
            }

            public void Add(BankAccounts mon)
            {
                money.AddRange(mon.money);
            }

            public decimal Sum()
            {
                decimal total = 0;
                foreach (decimal m in money)
                    total += m;
                return total;
            }
        }


    }
}
