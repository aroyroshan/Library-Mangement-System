using LibraryMgmts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMgmts.Controllers
{
    public class BookController : Controller
    {
        private LibraryContext db = new LibraryContext();
        // GET: Book
        public ActionResult Index()
        {
            IList<BookEntity> AllBook = GetData();
            return View(AllBook);
        }

        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(BookEntity Book)
        {
            if (!string.IsNullOrWhiteSpace(Book.BookTitle) && !string.IsNullOrWhiteSpace(Book.Author))
            {
                db.BookStudent.Add(Book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "find Error";
                return View();
            }
        }
        public ActionResult Update(int Id)
        {
            BookEntity Book = db.BookStudent.Where(a => a.Id == Id).FirstOrDefault();
            return View(Book);
        }
        public ActionResult Update(BookEntity Book)
        {
            BookEntity result = db.BookStudent.Where(a => a.Id == Book.Id).FirstOrDefault();
            if (result != null)
            {
                db.BookStudent.Attach(result);
                result.BookTitle = Book.BookTitle;
                result.Author = Book.Author;
                result.InStock = Book.InStock;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(Book);
            }

        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            BookEntity Book = db.BookStudent.Where(a => a.Id == Id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult DeleteData(int id)
        {
            BookEntity Book = db.BookStudent.Where(a => a.Id == id).FirstOrDefault();
            db.BookStudent.Remove(Book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        private IList<BookEntity> GetData()
        {
            IList<BookEntity> result = db.BookStudent.ToList();

            return result;
        }
    }

  
}