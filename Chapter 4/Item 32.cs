using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MECS.Chapter4.Item32
{
    static class Program
    {
        static void Main(string[] args)
        {
            string str = "123,234,345,456,567,678,789,890";

            /*List<int> nums = str.ParseLine();
            nums.All((i) => { Console.WriteLine(i); return true; });*/

            List<string> strs = new List<string> { str,str,str};
            var x = from s in strs select s.ParseLine();
            foreach (var i in x)
            {
                i.All((z) => { Console.WriteLine(z); return true; });
                Console.WriteLine();
            }


            Console.ReadKey();
        }

        static public int DefaultParse(this string str)
        {
            int def = 0;
            int.TryParse(str, out def);
            return def;
        }

        static public List<int> ParseLine(this string str)
        {
            //List<string> strs = str.Split(',').ToList();
            List<int> ints = new List<int>();
            foreach (var s in str.Split(','))
                ints.Add(s.DefaultParse());
            return ints;
        }
        

        
    }


}
