using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using NetCore.DataModels;
using NetCore.Interfaces;

namespace NetCore.Http
{
    public class WebApiCall : IWebApi
    {
        public async Task<IEnumerable<Person>> GetPersons()
        {
            System.Net.Http.HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri("http://localhost:16118/");
            client1.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            System.Net.Http.HttpResponseMessage response = client1.GetAsync("api/person").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<IEnumerable<Person>>();
                return data;
            }
            else
            {
                //Something has gone wrong, handle it here
                return null;
            }

        }
    }
}
