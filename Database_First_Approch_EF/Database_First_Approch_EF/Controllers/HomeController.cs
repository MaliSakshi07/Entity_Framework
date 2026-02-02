using Database_First_Approch_EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Database_First_Approch_EF.Controllers
{
    public class HomeController : Controller
    {
        Employee_DAEFEntities1 db = new Employee_DAEFEntities1();
        public ActionResult Index()
        {
            var data = db.Employee_Details.ToList();
            return View(data);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee_Details e)
        {
           if(ModelState.IsValid == true)
            {
                db.Employee_Details.Add(e);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Data Inserted Successfully!!!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Data Not Inserted Successfully!!!')</script>";
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.Employee_Details.Where(model => model.Emp_id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Employee_Details e)
        {
            if(ModelState.IsValid == true)
            {
                db.Entry(e).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Data Updated Successfully!!!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateMessage"] = "<script>alert('Data Not Updated Successfully!!!')</script>";
                }
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var row = db.Employee_Details.Where(model => model.Emp_id == id).FirstOrDefault();
            return View(row);
        }

        public ActionResult Delete(int id)
        {
            var DeletedRow = db.Employee_Details.Where(model => model.Emp_id == id).FirstOrDefault();
            return View(DeletedRow);
        }
        [HttpPost]
        public ActionResult Delete(Employee_Details e)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(e).State = EntityState.Deleted;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["DeleteMessage"] = "<script>alert('Data Deleted Successfully!!!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateMessage"] = "<script>alert('Data Not Deleted Successfully!!!')</script>";
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}