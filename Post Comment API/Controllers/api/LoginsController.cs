using Post_Comment_API.Models;
using Post_Comment_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Post_Comment_API.Controllers.api
{
    [RoutePrefix("api/Logins")]
    public class LoginsController : ApiController
    {
        LoginRepository logrepo = new LoginRepository();

        [Route("")/*, BasicAuthentication*/]
        public IHttpActionResult Get()
        {
            return Ok(logrepo.GetAll());

        }
        [Route("")]
        public IHttpActionResult Post(Login log)
        {
            logrepo.Insert(log);
            return Created("/api/Logins/" + log.Lid, log);
        }
    }
}
