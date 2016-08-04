using SimplyNewsPortal.Models;
using SimplyNewsPortal.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimplyNewsPortal.ConcreteRepository
{
    public class SQLBookRepository : IRepository<BlogPost>
    {
        private BlogsContext db;

        public SQLBookRepository()
        {
            this.db = new BlogsContext();
        }

        public IEnumerable<BlogPost> GetBlogList()
        {
            return db.BlogPosts;
        }

        public IEnumerable<BlogPost> GetBlogList(int pageSkip,int pageTake)
        {
            return db.BlogPosts;
        }

        public BlogPost GetBlog(int id)
        {
            return db.BlogPosts.Find(id);
        }

        public void Create(BlogPost book)
        {
            db.BlogPosts.Add(book);
        }

        public void Update(BlogPost book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            BlogPost book = db.BlogPosts.Find(id);
            if (book != null)
                db.BlogPosts.Remove(book);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

      
    }
}