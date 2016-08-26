using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Models;
using BusinessLogic.IocComponents;

namespace MVCSamples.Controllers
{
    public class SamplesController : Controller
    {
        private BuyMoriaContext db = new BuyMoriaContext();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //  For this demo I need the ability to turn on or off 
            //  extended validation classes...this will run for each req
            //  and tell the validation framework to either use
            //  a fake null validator or a real one which checks out position
            //  entry to make sure it is already in the DB
            switch (filterContext.ActionDescriptor.ActionName)
            {
                case "Create":
                    //  no special validation
                    NInjectKernel.Current.UseNullValidator = true;
                    break;
                case "CreateWithSimpleValidation":
                    //  simple NInject validation
                    NInjectKernel.Current.UseNullValidator = false;
                    break;
                case "CreateWithCombobox":
                    // Combobox doesn't let users choose out of range values
                    //  so no validation here
                    NInjectKernel.Current.UseNullValidator = true;
                    break;
                case "CreateWithAutocomplete":
                    //  auto complete does not limit choices to those shown
                    //  Validation still required
                    NInjectKernel.Current.UseNullValidator = false;
                    break;
                default:
                    NInjectKernel.Current.UseNullValidator = false;
                    break;
            }
            base.OnActionExecuting(filterContext);
        }
        //
        // GET: /Samples/

        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        //
        // GET: /Samples/Details/5

        public ActionResult Details(int id = 0)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // GET: /Samples/Create

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }


        public ActionResult CreateWithSimpleValidation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateWithSimpleValidation(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }


        public ActionResult CreateWithCombobox()
        {
            var choices = db.Employees.Select(e => new SelectListItem()
            {
                Value = e.Position,
                Text = e.Position
            }).Distinct();
            ViewBag.PositionChoices = choices;
            return View();
        }
        [HttpPost]
        public ActionResult CreateWithCombobox(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }


        public ActionResult CreateWithAutocomplete()
        {
            var choices = db.Employees.Select(e => new SelectListItem()
            {
                Value = e.Position,
                Text = e.Position
            }).Distinct();
            ViewBag.PositionChoices = choices;
            return View();
        }
        [HttpPost]
        public ActionResult CreateWithAutocomplete(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        //
        // GET: /Samples/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //
        // GET: /Samples/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}