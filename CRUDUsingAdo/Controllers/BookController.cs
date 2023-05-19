using CRUDUsingAdo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsingAdo.Controllers
{
    public class BookController : Controller
    {
        private readonly IConfiguration _configuration;
        private BookCRUD db;
        public BookController(IConfiguration configuration)
        {
            _configuration = configuration;
            db=new BookCRUD(_configuration);
        }

        // GET: BookController
        public ActionResult Index()
        {
            var list=db.GetBooks();
            return View(list);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var b=db.GetBookById(id);
            return View(b);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                int result = db.AddBook(book);
                if(result > 0)
                return RedirectToAction(nameof(Index));
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var b=db.GetBookById(id);
            return View(b);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            try
            {
                int result = db.EditBook(book);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var b= db.GetBookById(id);
            return View(b);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = db.DeleteBook(id);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
