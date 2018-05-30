using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinService
{
    [RoutePrefix("api/Test/")]
    public class TestController: ApiController
    {
        [HttpGet]
        [Route("get")]
        public IHttpActionResult Get()
        {
            return Ok(new List<string>() {"test1", "test2"});
        }
    }
}
