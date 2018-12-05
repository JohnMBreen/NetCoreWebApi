using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.DataModels;

namespace NetCore.Helpers
{
    public static class PersonHelper
    {
        public static bool IsSame(this Person person, Person personToCheck)
        {
            return personToCheck.GivenName == person.GivenName && personToCheck.FamilyName == person.FamilyName && personToCheck.Age == person.Age && personToCheck.Address == person.Address;
        }
    }
}
