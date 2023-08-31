using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BOOKADONETMVC.Models;

namespace BOOKADONETMVC.Controllers
{
    
    
    public class BookController : Controller
    {

        private readonly IConfiguration configuration;
        public BookCRUD crud;

        public BookController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud=new BookCRUD(this.configuration);
        }
        // GET: BookController
        public ActionResult Index()
        {
            var model=crud.GetAllBooks();
            return View(model);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                int result=crud.AddBook(book);
                if (result == 1) 
                  return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
