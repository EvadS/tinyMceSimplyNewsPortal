using SimplyNewsPortal.Additional;
using SimplyNewsPortal.ConcreteRepository;
using SimplyNewsPortal.Models;
using SimplyNewsPortal.ViewModel;
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
        SQLBookRepository db;
        
        public HomeController(){
            db = new SQLBookRepository();        
        }

        BlogsContext context = new BlogsContext();

        public ActionResult List(int? page,string  category, int pageSize = 5)
        {
            int currentPage = page ?? 1;

            currentPage = (currentPage < 1) ? 1 : currentPage;
            var query = context.BlogPosts.OrderBy(c => c.Title);
            var list = query.Skip((currentPage-1) * pageSize).Take(pageSize).ToList();

            var totalPages = context.BlogPosts.Count();

            var pager = new Pager(totalPages,currentPage, pageSize);

            var viewModel = new IndexViewModel
            {
                BlogPosts = list,
                Pager = pager
            };

            return View(viewModel);           
        }

        
        // GET: /Home/
         public ActionResult Index()
        {

            var list = db.GetBlogList();
            return View(list);
        }

        // асинхронный метод
        //public async Task<ActionResult> BookList()
        //{
        //    IEnumerable<BlogPost> books = await context.BlogPosts.ToListAsync();
        //    ViewBag.Books = books;
        //    return View("Index");
        //}

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
                    db.Create(blogPost);
                    db.Save();

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
          
            db.Delete(id);
            db.Save();
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var blogPost =  context.BlogPosts.Find(id);
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
