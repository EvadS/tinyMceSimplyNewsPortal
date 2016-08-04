using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimplyNewsPortal.Controllers
{
    public class BlogsController : ApiController
    {
        // GET api/blogs
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/blogs/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/blogs
        public void Post([FromBody]string value)
        {
        }

        // PUT api/blogs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/blogs/5
        public void Delete(int id)
        {
        }
    }
}
