using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUD.Controllers
{
    public class HomeController : Controller
    {
        MYCRUDDBContext _context = new MYCRUDDBContext();    
        public ActionResult Index()
        {
            var listofData = _context.Students.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student model)
        {
            _context.Students.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Sucessfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Students.Where(x => x.StudentID == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]

        public ActionResult Edit(Student model)
        {
            var data = _context.Students.Where(x => x.StudentID == model.StudentID).FirstOrDefault();
            if(data != null)
            {
                data.StudentCity = model.StudentCity;
                data.StudentName = model.StudentName;
                data.StudentFees = model.StudentFees;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        public ActionResult Detail(int id) 
        {
            var data = _context.Students.Where(x => x.StudentID == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = _context.Students.Where(x => x.StudentID == id).FirstOrDefault();
            _context.Students.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record Delete Sucessfully";
            return RedirectToAction("Index");
        }









    }
}