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
    //[RoutePrefix("api/Comments")]
    public class CommentsController : ApiController
    {
        //CommentRepository commrepo = new CommentRepository();

        //[Route("")/*, BasicAuthentication*/]
        //public IHttpActionResult Get()
        //{
        //    return Ok(commrepo.GetAll());

        //}
        //[Route("{id}")]
        //public IHttpActionResult Get(int id)
        //{
        //    var comment = commrepo.Get(id);
        //    if (comment == null)
        //    {
        //        return StatusCode(HttpStatusCode.NoContent);
        //    }
        //    return Ok(comment);
        //}

        //[Route("")]
        //public IHttpActionResult Post(Comment comment)
        //{
        //    commrepo.Insert(comment);
        //    return Created("/api/Comments" + comment.CommentId, comment);
        //}
        //[Route("{id}")]
        //public IHttpActionResult Put([FromUri] int id, [FromBody] Comment comment)
        //{
        //    comment.CommentId = id;
        //    commrepo.Update(comment);
        //    return Ok(comment);
        //}
        //[Route("{id}")]
        //public IHttpActionResult Delete(int id)
        //{
            
        //    commrepo.Delete(id);
        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        
    }
}
