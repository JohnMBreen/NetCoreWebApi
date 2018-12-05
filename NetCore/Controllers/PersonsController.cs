using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NetCore.DataModels;
using NetCore.Http;
using NetCore.Interfaces;

namespace NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {

        private readonly IWebApi webApiCall;
        public PersonsController(IWebApi webApiCall)
        {
            this.webApiCall = webApiCall;
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<IEnumerable<PersonItem>> GetAsync()
        {

            var data = await this.webApiCall.GetPersons();

            if (data != null)
            {
                return data.Select(item => new PersonItem { FirstName = item.GivenName, LastName = item.FamilyName, Age = item.Age, Address = item.Address });
            }

            return null;

        }

        // GET: api/Persons/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "Not Implemented";
        }

        // POST: api/Persons
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Persons/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
