using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_01.Data;
using NetCore_01.Models;

namespace NetCore_01.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? search)
        {
            List<Post> posts = new List<Post>();
            using (BlogContext db = new BlogContext())
            {

                // LOGICA PER RICERCARE I POST CHE CONTENGONO NEL TIUOLO O NELLA DESCRIZIONE LA STRINGA DI RICERCA
                if (search != null && search != "")
                {
                    posts = db.Posts.Where(post => post.Title.Contains(search) || post.Description.Contains(search)).ToList<Post>();
                }
                else
                {
                    posts = db.Posts.ToList<Post>();
                }
            }

            return Ok(posts);
        }
    }
}
