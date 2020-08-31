
using EFGetStartedMVC.Dao;
using EFGetStartedMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EFGetStartedMVC.Controllers
{
    public class RoutingAppController : Controller
    {
        private readonly RoutingAppDbContext _context;

        // In the constructor include service ref in constructor for the db context
        public RoutingAppController(RoutingAppDbContext context)
        {
            _context = context; // Our DB context
        }

         [HttpGet]
         public IActionResult ListPosts()
         {
            List<BlogPost> postList = _context.BlogPosts.ToList();
            string result = ""; // to hold the resulting string

            foreach (BlogPost item in postList)
            {
                result += ($"Post ID: {item.id}\nTitle: {item.title}\n{item.text}\n");
            }
            return Content(result);
         }

         [HttpPost]
         public IActionResult AddPost(string newTitle, string newText)
         {
             // longhand version of new instance
            //  BlogPost newPost = new BlogPost();
            //  newPost.text = newText;
            //  newPost.title = newTitle;

            // shorthand version
            BlogPost newPost = new BlogPost{
                title = newTitle,
                text = newText
            };

            // Use the dbcontext to store the new record in database
            _context.BlogPosts.Add(newPost);
            // since we made a change to database must commit it
            _context.SaveChanges();
            return Content($"Add a post: {newTitle}");
         }

         [HttpPut]
         public IActionResult ModifyPost(int id, string newTitle, string newText)
         {
            // Get the original item
            BlogPost modPost = _context.BlogPosts.Single(post => post.id == id);

            // Update it
            modPost.title = newTitle;
            modPost.text = newText;
            
            // Save results
            _context.SaveChanges();

             return Content($"Modified a post");
         }

         [HttpDelete]
         public IActionResult DeletePost(int id)
         {
            // Get the original item
            BlogPost modPost = _context.BlogPosts.Single(post => post.id == id);

            // Remove it
            _context.BlogPosts.Remove(modPost);

            // Save results
            _context.SaveChanges();

             return Content($"Delete a post");
         }

    }



}
