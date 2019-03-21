using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QZCHY.PanoramaQuzhou.API.Controllers
{
    [RoutePrefix("Default")]
    public class DefaultController : ApiController
    {
        /// <summary>
        /// hello world
        /// </summary>
        /// <returns></returns>
        [Route("HW")]
        [HttpGet]
        public IHttpActionResult HelloWorld()
        {
            return Ok("Helloworld");
        }
    }
}
