using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExploreCalifornia.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExploreCalifornia.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        [Route("")]
        // GET: /<controller>/
        public IActionResult Index()
        {
            var posts = new[]
            {
                new Post
                {
                    Title = "My 1st blog post",
                    Posted = DateTime.Now,
                    Author = "Jess Chadwick",
                    Body = "This is a great blog post, don't you think?"
                },
                new Post
                {
                    Title = "My 2nd blog post",
                    Posted = DateTime.Now.AddSeconds(400),
                    Author = "Ptlomeo",
                    Body = "BULLSHIT!! MowFucker!!"
                },
        };
            // return new ContentResult { Content = "Blog posts" };
            return View(posts);
        }

        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var post = new Post
            {
                Title = "My blog post",
                Posted = DateTime.Now,
                Author = "Jess Chadwick",
                Body = "This is a great blog post, don't you think?"
            };
            
            // return new ContentResult { Content = string.Format("Year: {0}; Month: {1}; Key: {2}", year, month, key) };
            return View(post);
        }

        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("create")]
        public IActionResult Create([Bind("Title", "Body")] Post post)
        {
            if (!ModelState.IsValid)
                return View();

            post.Author = User.Identity.Name;
            post.Posted = DateTime.Now;

            return View();
        }
    }
}
