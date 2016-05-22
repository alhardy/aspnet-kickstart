using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.KickStart.Api.Controllers
{
    [Route("v1/sample")]
    public class SampleV1Controller : Controller
    {
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("error")]
        public void Error()
        {
            throw new Exception("Sample Error");
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "one", "two" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("id/{id}")]
        public IEnumerable<string> GetById(int id)
        {
            return new[] { "one", "two", "three" };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}