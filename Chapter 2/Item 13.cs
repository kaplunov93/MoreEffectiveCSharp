﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MECS.Chapter2.Item13
{
    class Program
    {
        static void Main(string[] args)
        {
            Person per = new Person();

            Parallel.For(1, 8,
                (i, s) =>
                {
                    if (i % 2 == 0)
                    {
                        per.First = per.Name;
                        Console.WriteLine("Loop {0} Write",i);
                    }
                    else
                    {
                        Console.WriteLine("Loop {0} Read {1}", i, per.Name);
                    }
                });

            Console.ReadKey();
        }

        class Person
        {
            private string _First,_Last;
            object Locker=new object();
            public string Name
            {
                get
                {
                    lock(Locker)
                    return string.Format("{0} {1}",_First,_Last);
                }
            }

            public string First
            {
                set
                {
                    lock(Locker)
                        _First = value;
                }
            }

            public string Last
            {
                set
                {
                    lock (Locker) 
                        _Last = value;
                }
            }

            public Person(string first="Vasia",string last="Pupkin")
            {
                _First = first;
                _Last = last;
            }

        }
    }
}
