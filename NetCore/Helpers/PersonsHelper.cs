using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.DataModels;

namespace NetCore.Helpers
{
    public static class PersonsHelper
    {
        public static bool IsSame(this PersonItem person, Person personToCheck)
        {
            return personToCheck.GivenName == person.FirstName && personToCheck.FamilyName == person.LastName && personToCheck.Age == person.Age && personToCheck.Address == person.Address;
        }
    }
}
