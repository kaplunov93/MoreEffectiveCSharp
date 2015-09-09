using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter1.Item3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strs = new List<string> { "sdfsd", "sfgfhj", "3ertttw" };
            List<int> ints = new List<int> { 1, 2, 3, 4, 5 };
            IList<Person> persons = new List<Person> { new Person(), new Person("Aliona", "Kaplunova") };

            PrintList(strs);
            //PrintList(ints); // Oh no, now our method can't work with int because we have constraint, T like class;
            PrintList(persons);

            ReverseEnumerable<Person> invpersons = new ReverseEnumerable<Person>(persons);
            PrintList(invpersons.ToList());
            Console.ReadKey();
        }

        //Generic method like universal function for all lists where type is class in this example
        public static void PrintList<T>(IList<T> objs) where T : class
        {
            foreach (T obj in objs)
                Console.WriteLine(obj.ToString());
        }


        class Person
        {
            private string FN;
            private string LN;

            public Person(string fn = "Alex", string ln = "Kaplunov")
            {
                FN = fn;
                LN = ln;
            }
            
            public override string ToString()
            {
                return string.Format("First Name: {0},\tLast Name: {1}", FN, LN);
            }
            
        }

        public sealed class ReverseEnumerable<T> : IEnumerable<T>
        {
            private class ReverseEnumerator : IEnumerator<T>
            {
                int currentIndex;
                IList<T> collection;

                public IList<T> ToList()
                {
                    List<T> list = new List<T>();
                    while(MoveNext())
                    {
                        list.Add(Current);
                    }
                    return list;
                }

                public ReverseEnumerator(IList<T> srcCollection)
                {
                    collection = srcCollection;
                    currentIndex = collection.Count;
                }
                #region IEnumerator<T> Members
                public T Current
                {
                    get { return collection[currentIndex]; }
                }
                #endregion
                #region IDisposable Members
                public void Dispose()
                {
                    // No implementation needed.
                    // No protected Dispose() needed
                    // because this class is sealed.
                }
                #endregion
                #region IEnumerator Members
                object System.Collections.IEnumerator.Current
                {
                    get { return this.Current; }
                }
                public bool MoveNext()
                {
                    return --currentIndex >= 0;
                }
                public void Reset()
                {
                    currentIndex = collection.Count;
                }
                #endregion
            }
            IEnumerable<T> sourceSequence;
            IList<T> originalSequence;
            public ReverseEnumerable(IEnumerable<T> sequence)
            {
                sourceSequence = sequence;
            }
            #region IEnumerable<T> Members
            public IEnumerator<T> GetEnumerator()
            {
                // Create a copy of the original sequence,
                // so it can be reversed.
                if (originalSequence == null)
                {
                    originalSequence = new List<T>();
                    foreach (T item in sourceSequence)
                        originalSequence.Add(item);
                }
                return new ReverseEnumerator(originalSequence);
            }
            #endregion
            #region IEnumerable Members
            System.Collections.IEnumerator
            System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            #endregion
        }

        }
    }
