using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using NetCore.DataModels;
using NetCore.Interfaces;

namespace NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IDatabase database;
        public PersonController(IDatabase database)
        {
            this.database = database;
        }

        // GET api/person
        [HttpGet]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously, could use await Task.Task.CompletedTask
        public async Task<ActionResult<IEnumerable<Person>>> GetAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return this.database.GetData();
        }

        // GET api/perosn/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "not implemented";
        }

        // POST api/person
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/person/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/person/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
