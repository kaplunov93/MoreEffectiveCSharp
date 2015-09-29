using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS.Chapter6.Item46
{
    public partial class Person
    {
        public void Change(string first,string last)
        {
            FirstName = first;
            LastName = last;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}",FirstName,LastName);
        }
    }
}
