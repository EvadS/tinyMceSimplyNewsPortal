using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimplyNewsPortal.Models
{
    public class BlogsContext:DbContext
    {
        public BlogsContext()
            : base("BookContext")
    {}
        public DbSet<BlogPost> BlogPosts { get; set; } 
        public DbSet<User> Users { get; set; }
    }
}