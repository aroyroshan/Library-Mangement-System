using LibraryMgmts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMgmts.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        private LibraryContext db = new LibraryContext();

        // GET: Student
        public ActionResult SdtIndex()
        {
            if (Session["UserName"] != null)
            {
                IList<StudentEntity> AllStudent = GetData();
                return View(AllStudent);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }
        public ActionResult SdtInsert()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        [HttpPost]
        public ActionResult Insert(StudentEntity student)
        {
            if (!string.IsNullOrWhiteSpace(student.Name) && !string.IsNullOrWhiteSpace(student.PhoneNumber))
            {
                db.Student.Add(student);
                db.SaveChanges();
                return RedirectToAction("SdtIndex");
            }
            else
            {
                ViewBag.error = "Error Find!!";
                return View();
            }
        }

        public ActionResult SdtUpdate(int Id)
        {
            if (Session["UserName"] != null)
            {
                StudentEntity Student = db.Student.Where(a => a.Id == Id).FirstOrDefault();
                return View(Student);

            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        [HttpPost]
        public ActionResult Update(StudentEntity Student)
        {
            StudentEntity result = db.Student.Where(a => a.Id == Student.Id).FirstOrDefault();

            {
                db.Student.Attach(result);
                result.Name = Student.Name;
                result.PhoneNumber = Student.PhoneNumber;
                result.Address = Student.Address;
                result.Department = Student.Department;
                result.gmail = Student.gmail;
                result.Session = Student.Session;
                db.SaveChanges();
                return RedirectToAction("SdtIndex");
            }
        }

        [HttpGet]
        public ActionResult SdtDelete(int id)
        {
            StudentEntity student = db.Student.Where(a => a.Id == id).FirstOrDefault();
            return View(student);
        }


        [HttpPost]
        public ActionResult DeleteData(int id)
        {
            StudentEntity student = db.Student.Where(a => a.Id == id)
                                        .FirstOrDefault();

            db.Student.Remove(student);
            db.SaveChanges();
            return RedirectToAction("SdtIndex");
        }

        [NonAction]
        private IList<StudentEntity> GetData()
        {

            IList<StudentEntity> result = db.Student.ToList();
            return result;

        }
    }
}