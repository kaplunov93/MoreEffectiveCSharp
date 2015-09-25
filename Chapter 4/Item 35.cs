using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace MECS.Chapter4.Item35
{
    static class Program
    {
        static void Main(string[] args)
        {
            Person me = new Person();
            me.FirstName = "Alex";
            me.LastName = "Kaplunov";

            // Console.WriteLine(me.Format()); Oh no I can't do it
            Console.WriteLine("Console Output:");
            Console.WriteLine(PersonReport.FormatAsConsole(me));
            Console.WriteLine("\nXML Output:");
            Console.WriteLine(PersonReport.FormatAsXML(me));

            Console.ReadKey();
        }
        
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    static class PersonReport
    {
        public static string FormatAsConsole(Person p)
        {
            return string.Format("{0}\t{1}", p.FirstName, p.LastName);
        }

        public static string FormatAsXML(Person p)
        {
            return new XElement("Person",
                new XElement("FirstName", p.FirstName),
                new XElement("LastName", p.LastName)).ToString();
        }
    }

    static class ConsoleReport
    {
        public static string Format(this Person p)
        {
            return string.Format("{0}\t{1}",p.FirstName,p.LastName);
        }
    }

    static class XMLReport
    {
        public static string Format(this Person p)
        {
            return new XElement("Person",
                new XElement("FirstName",p.FirstName),
                new XElement("LastName",p.LastName)).ToString();
        }
    }


}
