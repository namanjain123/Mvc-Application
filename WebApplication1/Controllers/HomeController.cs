using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using static DataLibrarary.Logic.EmpProcess;
using DataLibrarary.Model;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        public ActionResult ViewEmployees()
        {
            ViewBag.Message = "Employee List";
            var data = Load<Emp>();
            List<Emp> employees = new List<Emp>();
            foreach(var row in data)
            {
                employees.Add(new Emp
                {
                    EmployeId = row.EmployeId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress,
                }) ;
            }
            return View(employees);
        }
        public ActionResult SignUp()
        {
            ViewBag.Message = "Employee SignUp";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Emp model)
        {
            //Validation
            if(ModelState.IsValid)
            {
                int recordCreated=CreateEmp(model.EmployeId,
                    model.FirstName,
                    model.LastName,
                    model.EmailAddress);

                return RedirectToAction("Index"); 
            }
            
            return View();
        }
    }
}