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
    [RoutePrefix("api/Posts")]
    public class PostsController : ApiController
    {
        PostRepository postrepo = new PostRepository();

        [Route(""), BasicAuthentication]
        public IHttpActionResult Get()
        {
            return Ok(postrepo.GetAll());

        }
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var post = postrepo.Get(id);
            if (post == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(post);
            }
        }

        [Route("")]
        public IHttpActionResult Post(Post post)
        {
            postrepo.Insert(post);
            return Created("/api/Posts/" + post.PostId, post);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Post post)
        {
            post.PostId = id;
            postrepo.Update(post);
            return Ok(post);
        }
        [Route("{id}")]
        public IHttpActionResult Delete([FromUri] int id,[FromBody] int lid)
        {
            CommentRepository comrepo = new CommentRepository();
            var comm = comrepo.GetCommentsByPost(id);
           var userlist= postrepo.Get(lid);
            if (userlist.Lid == lid)
            {
                if (comm == null)
                {
                }
                else
                {
                    foreach (var item in comm)
                    {
                        comrepo.Delete(item.CommentId);
                    }
                }

                postrepo.Delete(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok();
            }
        }

        // /posts/{id}/comments   Read all comments for a post


        [Route("{id}/Comments")]
        public IHttpActionResult GetCommentsByPostId(int id)
        {
            CommentRepository comrepo = new CommentRepository();
            var comments = comrepo.GetCommentsByPost(id);
            if (comments.Count <=0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(comments);
            }
        }
        // /posts/{id}/comments/{id} Read one comment for a pos
        [Route("{pid}/Comments/{cid}")]
        public IHttpActionResult Get([FromUri]int pid, [FromUri]int cid)
        {
            CommentRepository comrepo = new CommentRepository();
            var comment = comrepo.GetSingleComment(pid, cid);
            if (comment.Count <= 0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(comment);
            }
        }

        [Route("{id}/Comments")]
        public IHttpActionResult Post([FromUri] int id, Comment comment)
        {
            CommentRepository comrepo = new CommentRepository();
            comment.PostId = id;
            comment.Lid = comment.Lid;

            comrepo.Insert(comment);
            return Created("/api/Posts/" + comment.PostId + "/Comments", comment);
        }

        [Route("{pid}/Comments/{cid}")]
        public IHttpActionResult Put([FromUri] int pid, [FromUri] int cid, Comment comment)
        {
            CommentRepository comrepo = new CommentRepository();
            comment.PostId = pid;
            comment.CommentId = cid;

            comrepo.Update(comment);
            return Ok(comment);
        }
        [Route("{pid}/Comments/{cid}")]
        public IHttpActionResult Deletecomment([FromUri] int pid,[FromUri] int cid)
        {
            CommentRepository comrepo = new CommentRepository();
            // var userlist = comrepo.Get(lid);
            //if (userlist.Lid == lid)
            //{
                comrepo.Delete(cid);
                return StatusCode(HttpStatusCode.NoContent);
            //}
            //else
            //{
            //    return Ok();
            //}
            
        }
    }
}
