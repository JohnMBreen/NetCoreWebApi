using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Interfaces;

namespace NetCore.DataModels
{
    public class Person
    {
        public String GivenName { get; set; }
        public string FamilyName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

    }

}
