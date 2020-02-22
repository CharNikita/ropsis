using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_2
{
    interface IPerson
    {
        string Name { get; }
        string Patronomic { get; }
        string LastName { get; }
        DateTime BirthDate { get; }
        int Age { get; }
    }
}
