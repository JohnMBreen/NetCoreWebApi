using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.DataModels;

namespace NetCore.Interfaces
{
    public interface IWebApi
    {
        Task<IEnumerable<Person>> GetPersons();
    }
}
