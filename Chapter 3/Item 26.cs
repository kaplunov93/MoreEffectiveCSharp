using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MECS.Chapter3.Item26
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.ReadKey();
        }

        /// <summary>
        /// This class doing extra work in setters and getters
        /// </summary>
        class Bad
        {
            private string data;
            public string Data
            {
                get
                {
                    if (data == null)
                        data = LoadData();
                    return data;
                }
                set
                {
                    data = value;
                    SaveData(data);
                }
            }

            private void SaveData(string data)
            {
                //...Saving Data...
            }

            private string LoadData()
            {
                //...Loading Data...
                return "Some data";
            }
        }

        /// <summary>
        /// Nothing Extra Work in Properties, Extra Work in Methods
        /// </summary>
        class Good
        {
            public string Data
            {
                get;
                set;
            }

            public void LoadData()
            {
                //...Loading Data...
                Data = "Some Data";
            }

            public void SaveData()
            {
                //..Saving DAta...
            }
        }

    }
}
