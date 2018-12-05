using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.DataModels;
using NetCore.Interfaces;

namespace NetCore.DataStorage
{
    public class PersonData : IDatabase
    {
        public List<Person> GetData()
        {
            return new List<Person>
            {
                new Person{GivenName = "John" , FamilyName = "Smith" , Age = 45, Address = "Wexford" },
                new Person{GivenName = "Jane" , FamilyName = "Doe" , Age = 44, Address = "Wicklow" }
            };

        }
    }
}
