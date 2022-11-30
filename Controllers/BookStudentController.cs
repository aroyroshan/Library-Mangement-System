using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMgmts.Controllers
{
    public class BookStudentController : Controller
    {
        private LibraryContext db = new LibraryContext();


        // GET: BookStudent
        public ActionResult Index()
        {
            IList<SdtBookMapping> AllBookStudent = GetData();
            return View(AllBookStudent);
        }
        public ActionResult Insert()
        {
            ViewBag.BookId = new SelectList(db.BookStudent, "Id", "BookTitle");
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name");
            ViewBag.Books = db.BookStudent;
            return View();
        }
        public ActionResult SaveData(SdtBookMapping BookStudent)
        {
            db.BookStudentMapping.Add(BookStudent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [NonAction]
        private IList<SdtBookMapping> GetData()
        {
            IList<SdtBookMapping> result = db.BookStudentMapping.Include("Book").Include("Student").ToList();
            return (result);
        }
        public ActionResult DeleteData(int Id)
        {
            SdtBookMapping Book = db.BookStudentMapping.Where(a => a.Id == Id).FirstOrDefault();
            db.BookStudentMapping.Remove(Book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            SdtBookMapping Book = db.BookStudentMapping.Where(a => a.Id == id).FirstOrDefault();
            
            return View(Book);
        }
        public ActionResult UpdateData(SdtBookMapping Book)
        {
            SdtBookMapping result = db.BookStudentMapping.Where(a => a.Id == Book.Id).FirstOrDefault();

            db.BookStudentMapping.Attach(result);
            result.BookId = Book.BookId;
            result.StudentId = Book.StudentId;
            result.IssueDate = Book.IssueDate;
            result.ReturnDate = Book.ReturnDate;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}