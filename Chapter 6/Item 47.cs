using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter6.Item47
{
    static class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
                new Product("MotherBoard",50),
                new Product("CPU",600,5),
                new Product("Ram",100)
            };

            Console.WriteLine("\t---PRODUCTS---");
            products.All(i=> { Console.WriteLine(i.ToString()); return true; });
            Console.WriteLine("\t--------------");

            Console.WriteLine("\tSum = {0}$",Sum(products));

            //Console.WriteLine("\tSum = {0}$", Sum(products[0],products[2]));

            Console.ReadKey();
        }

        public class Product
        {
            private string _Name;
            private decimal _Price;
            private int _Discount;
            public string Name { get; }
            public int Discount { get; }

            public Product(string name="", decimal price=0, int discount = 0)
            {
                _Name = name;
                _Price = price;
                _Discount = discount;
            }

            public override string ToString()
            {
                if(_Discount!=0)
                    return string.Format("Name: {0}, Price: {1}$ (include {2}% discount)", _Name, PriceWithDiscount,_Discount);
                return string.Format("Name: {0}, Price: {1}$",_Name,PriceWithDiscount);
            }

            public decimal PriceWithDiscount
            {
                get
                {
                    return (_Price - (_Price * (_Discount / 100M)));
                }
            }
        }

        public static decimal Sum(params Product[] products)
        {
            decimal sum = 0;
            for (int i = 0; i < products.Length; i++)
                sum += products[i].PriceWithDiscount;
            return sum;
        }
    }
    
}
