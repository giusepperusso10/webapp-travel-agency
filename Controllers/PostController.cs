using Microsoft.AspNetCore.Mvc;
using NetCore_01.Data;
using NetCore_01.Models;
using NetCore_01.Utils;
using System.ComponentModel.DataAnnotations;

namespace NetCore_01.Controllers
{
    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult Index(string SearchString)
        {
            

            List<Post> posts = new List<Post>();


            using (BlogContext db = new BlogContext())
            {

                // LOGICA PER RICERCARE I POST CHE CONTENGONO NEL TIUOLO O NELLA DESCRIZIONE LA STRINGA DI RICERCA
                if (SearchString != null)
                {
                    posts = db.Posts.Where(post => post.Title.Contains(SearchString) || post.Description.Contains(SearchString)).ToList<Post>();
                } else
                {
                    posts = db.Posts.ToList<Post>();
                } 
            }

            return View("HomePage", posts);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            using (BlogContext db = new BlogContext())
            {
                try
                {
                    Post postFound = db.Posts
                         .Where(post => post.Id == id)
                         .First();

                    return View("Details", postFound);

                } catch (InvalidOperationException ex)
                {
                    return NotFound("Il post con id " + id + " non è stato trovato");
                } catch (Exception ex)
                {
                    return BadRequest();
                }    
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("FormPost");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post nuovoPost)
        {
            if (!ModelState.IsValid)
            {
                return View("FormPost", nuovoPost);
            }

            using(BlogContext db = new BlogContext())
            {
                Post postToCreate = new Post(nuovoPost.Title, nuovoPost.Description, nuovoPost.Image, nuovoPost.Price);

                db.Posts.Add(postToCreate);
                db.SaveChanges();  
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Post postToEdit = null;

            using (BlogContext db = new BlogContext())
            {
                postToEdit = db.Posts
                     .Where(post => post.Id == id)
                     .FirstOrDefault();

            }

            if (postToEdit == null)
            {
                return NotFound();
            } else
            {
                return View("Update", postToEdit);
            }

        }

        [HttpPost]
        public IActionResult Update(int id, Post model)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", model);
            }

            Post postToEdit = null;

            using (BlogContext db = new BlogContext())
            {
                postToEdit = db.Posts
                     .Where(post => post.Id == id)
                     .FirstOrDefault();


                if (postToEdit != null)
                {
                    postToEdit.Title = model.Title;
                    postToEdit.Description = model.Description;
                    postToEdit.Image = model.Image;
                    postToEdit.Price = model.Price;


                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            using (BlogContext db = new BlogContext())
            {
                Post? postToDelete = db.Posts
                     .Where(post => post.Id == id)
                     .FirstOrDefault();

                if(postToDelete != null)
                {
                    db.Posts.Remove(postToDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Post");
                } else
                {
                    return NotFound();
                }
            }
        }

    }
}
