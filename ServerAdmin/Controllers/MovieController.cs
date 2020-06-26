using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerAdmin.Controllers
{
    [RoutePrefix("movie")]
    public class MovieController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok("Todo Piolin");
        }

        [Route("{movieName}")]
        public IHttpActionResult Get(string movieName)
        {
            return Ok("Todo Piolin queri");            
        }



    }
}
