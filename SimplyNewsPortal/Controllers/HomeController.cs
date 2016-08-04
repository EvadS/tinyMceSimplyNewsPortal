using SimplyNewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SimplyNewsPortal.Controllers
{
    public class HomeController : Controller
    {

        BlogsContext context = new BlogsContext();

        public ActionResult List()
        {
            string[] words = { "apple", "strawberry", "grape", "peach", "banana" };
            return View(words.AsEnumerable());
        }
        // GET: /Home/
        public ActionResult Index()
        {
            var list = context.BlogPosts.ToList();
            return View(list);
        }

        // асинхронный метод
        public async Task<ActionResult> BookList()
        {
            IEnumerable<BlogPost> books = await context.BlogPosts.ToListAsync();
            ViewBag.Books = books;
            return View("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BlogPost blogPost)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    context.BlogPosts.Add(blogPost);
                    context.SaveChanges();

                    return RedirectToAction("index", "Home");
                }
                catch (Exception ex)
                {
                    //error msg for failed edit in XML file
                    ModelState.AddModelError("", "Error editing record. " + ex.Message);
                }

                // return HttpNotFound();
            }

            ViewBag.Message = "Запрос не прошел валидацию";
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            BlogPost b = context.BlogPosts.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPost b = context.BlogPosts.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            context.BlogPosts.Remove(b);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var blogPost = context.BlogPosts.Find(id);
            if (blogPost != null)
            {
                return View(blogPost);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(BlogPost blogPost)
        {
            if (blogPost.Tags.Length < 2)
            {
                ModelState.AddModelError("Name", "Недопустимая длина тега");
            }

            if (TryUpdateModel(blogPost))
            {
                context.Entry(blogPost).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Во время редактирования возникли ошибки";
                return View(blogPost);
            }
        }


        [HttpPost]
        public JsonResult CreateNews(string Tags, DateTime PostedOn, string Content, string Title)
        {
            if (string.IsNullOrEmpty(Tags))
            {
                ModelState.AddModelError("Tags", "Некорректный тег");
            }
            if (!ModelState.IsValid)
            {
              
            }
            try
            {
                var blogPost = new BlogPost();
                blogPost.Title = Title;
                blogPost.Tags = Tags;
                blogPost.PostedOn = PostedOn;
                blogPost.Content = Content;

                context.BlogPosts.Add(blogPost);
                context.SaveChanges();


                return Json(new { resultMessage = "Ваш комментарий добавлен успешно!" });
            }
            catch (Exception ex)
            {
                //error msg for failed edit in XML file
                ModelState.AddModelError("", "Error editing record. " + ex.Message);
                return Json(new { resultMessage = "произошла ошибка в процессе добавления" });
            }


            // System.Threading.Thread.Sleep(5000);  /*simulating slow connection*/


        }



    }
}
