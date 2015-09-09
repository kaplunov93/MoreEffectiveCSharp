using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MECS.Chapter1.Item4
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person> { new Person(), new Person("Aliona", "Kaplunova") };

            XMLSerializer<List<Person>>.SaveToFile("./persons.xml", persons);

            PrintList(XMLSerializer<List<Person>>.LoadFromFile("./persons.xml"));

            Console.ReadKey();
        }

        //Generic method like universal function for all lists in this example
        public static void PrintList<T>(IList<T> objs)
        {
            foreach (T obj in objs)
                Console.WriteLine(obj.ToString());
        }

         static class XMLSerializer<T>
        {
            private static XmlSerializer factory;

            public static T LoadFromFile(string filePath)
            {
                if (File.Exists(filePath))
                {
                    using (XmlReader inputStream = XmlReader.Create(
                    filePath))
                    {
                        return ReadFromStream(inputStream);
                    }
                }
                return default(T);
            }
            public static void SaveToFile(string filePath, T data)
            {
                using (XmlWriter writer = XmlWriter.Create(filePath))
                {
                    AddToStream(writer, data);
                }
            }
            public static void AddToStream(System.Xml.XmlWriter outputStream, T data)
            {
                if (factory == null)
                    factory = new XmlSerializer(typeof(T));
                factory.Serialize(outputStream, data);
            }
            public static T ReadFromStream(System.Xml.XmlReader inputStream)
            {
                if (factory == null)
                    factory = new XmlSerializer(typeof(T));
                T rVal = (T)factory.Deserialize(inputStream);
                return rVal;
            }
        }

        [Serializable]
        public class Person
        {
            public string FN { get; set; }
            public string LN { get; set; }

            private Person() { }

            public Person(string fn = "Alex", string ln = "Kaplunov")
            {
                FN = fn;
                LN = ln;
            }
            public override string ToString()
            {
                return string.Format("First Name: {0}, Last Name: {1}", FN, LN);
            }
        }
    }
}
