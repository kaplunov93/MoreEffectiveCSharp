using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter5.Item41
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t ________________________");
            Console.WriteLine("\t|esc - for exit from loop|");
            Console.WriteLine("\t|________________________|");
            Console.Write("To START click any button (not esc):");
            var key = Console.ReadKey();
            Console.WriteLine("\n");
            while (key.Key != ConsoleKey.Escape)
            {
                Console.WriteLine("\t --- START LOOP ---");
                    foreach (var N in GenerateSequence())
                        Console.Write("{0} ", N);
                Console.WriteLine("\n\t --- END LOOP ---\n");
                key = Console.ReadKey();
            }
            Console.WriteLine("\n\t--- END ---");

            Console.ReadKey();
        }

        static IEnumerable<int> GenerateSequence()
        {
            var statistic = Statistic();
            Console.WriteLine("Statistic = {0}\n",statistic);
            IEnumerable<int> sequence = Generate(100);
            return (from n in sequence where n>statistic select n).ToList();
        }


        static double Statistic()
        {
            Random rand = new Random();
            var r = rand.Next(10,90);
            Console.WriteLine("Random for Statistic = {0}",r);
            IEnumerable<int> stat = Generate(r);
            return (from n in stat select n).Average();

        }

        static IEnumerable<int> Generate(int count=30, int num=0)
        {
            for (int i = num; i < num + count; i++)
                yield return i;
        }



    }
}
