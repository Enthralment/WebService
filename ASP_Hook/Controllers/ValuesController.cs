using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HookLib;
using Newtonsoft.Json;

namespace ASP_Hook.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        static string entryAddr;
        static Data[] data = new Data[7];
        static List<string> parts = new List<string>();


        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return parts;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return parts[id];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            entryAddr = value;
            entryAddr = Address.CorrectAddress(Address.AdressParts(value));
            parts.Add(entryAddr);
        }
        /*public void Post([FromBody]string[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                data[i].Title = value[i];
                data[i].Sub = "";
            }
            entryAddr = Address.CorrectAddress(Address.AdressParts(Address.CorrectAddress(data)));
            for (int i = 0; i < data.Length; i++)
            {
                parts.Add(entryAddr);
            }
        }*/

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            entryAddr = Address.CorrectAddress(Address.AdressParts(value));
            parts[id] = entryAddr;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            parts.RemoveAt(id);
        }
    }
}
