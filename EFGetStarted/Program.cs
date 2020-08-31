using System;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting EF Test");
            // Get a new instance of the DB context
            BloggingContext db = new BloggingContext();

            // Perform our actions via the context
            // Console.WriteLine("Adding a post...");
            // db.Add(new Post {Title = "Post Title", Content="This is some content!"});
            // db.Add(new Post {Title = "2nd Post Title", Content="This is some MORE content!"});

            // // Remember to SaveChanges() if any changes made
            // db.SaveChanges();

            // Filter/Where Look up a record in the dbset
            Console.WriteLine("Fetching a post...");
            Post post = db.Posts.SingleOrDefault(i => i.PostId == 1);
            Console.WriteLine($"Id: {post.PostId}\nTitle: {post.Title}\n{post.Content}");


            // Delete a post
            Console.WriteLine("Deleting a post...");
            db.Remove(post);
            db.SaveChanges(); // commit delete

            // Update a post
            post = db.Posts.SingleOrDefault(i => i.PostId == 5); 
            // update the post
            post.Title = "Here is the new title!!!!!";
            db.SaveChanges();
            Console.WriteLine($"Id: {post.PostId}\nTitle: {post.Title}\n{post.Content}");            
        }
    }
}
