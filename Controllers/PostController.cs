using Microsoft.AspNetCore.Mvc;
using NetCore_01.Models;
using NetCore_01.Utils;
using System.ComponentModel.DataAnnotations;

namespace NetCore_01.Controllers
{
    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            List<Post> posts = PostData.GetPosts();

            return View("HomePage", posts);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Post postFound = GetPostById(id);

            if (postFound != null)
            {
                return View("Details", postFound);
            } else
            {
                return NotFound("Il post con id " + id + " non è stato trovato");
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

            Post nuovoPostConId = new Post(PostData.GetPosts().Count, nuovoPost.Title, nuovoPost.Description, nuovoPost.Image, nuovoPost.Price);

            // Il mio modello è corretto
            PostData.GetPosts().Add(nuovoPostConId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Post postToEdit = GetPostById(id);

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

            Post postOriginal = GetPostById(id);

            if(postOriginal != null)
            {
                postOriginal.Title = model.Title;
                postOriginal.Description = model.Description;
                postOriginal.Image = model.Image;
                postOriginal.Price = model.Price;

                return RedirectToAction("Index");
            } else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            int PostIndexToRemove = -1;

            List<Post> postList = PostData.GetPosts();

            for(int i = 0; i < postList.Count; i++)
            {
                if(postList[i].Id == id)
                {
                    PostIndexToRemove = i;
                }
            }

            if (PostIndexToRemove >= 0)
            {
                PostData.GetPosts().RemoveAt(PostIndexToRemove);

                return RedirectToAction("Index");
            } else
            {
                return NotFound();
            }
        }

        private Post GetPostById(int id)
        {
            Post postFound = null;

            foreach (Post post in PostData.GetPosts())
            {
                if (post.Id == id)
                {
                    postFound = post;
                    break;
                }
            }

            return postFound;
        }
    }
}
