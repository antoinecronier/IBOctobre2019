using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetModule1.Models;

namespace AspNetModule1.Controllers
{
    [RoutePrefix("Employees")]
    public class EmployeesController : Controller
    {
        private ProjectDb db = new ProjectDb();

        // GET: Employees
        [HttpGet]
        [Route("Index")]
        public async Task<ActionResult> Index()
        {
            return View(await db.Employees.ToListAsync());
        }

        // GET: Employees/Details/5
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.Projects = db.Projects.ToList();
            return View();
        }

        // POST: Employees/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmployeeId,Lastname,Firstname")] Employee employee, int[] projectsIds)
        {
            if (ModelState.IsValid)
            {
                if (projectsIds != null)
                {
                    foreach (var id in projectsIds)
                    {
                        employee.Projects.Add(db.Projects.Find(id));
                    }
                }
                
                db.Employees.Add(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        [Route("Edit")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EmployeeId,Lastname,Firstname")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult GetList()
        {
            return PartialView("~/Views/Shared/Employees/_EmployeeList.cshtml", db.Employees.ToList());
        }

        [ChildActionOnly]
        public ActionResult GetListByTitle(int projectId)
        {
            return PartialView("~/Views/Shared/Employees/_EmployeeList.cshtml", 
                db.Projects.Include(x => x.Employees).First(p => p.ProjectId == projectId).Employees);
        }

        public async Task<ActionResult> ListEmployees(string projectRef)
        {
            return View("Index", (await db.Projects.Include(x => x.Employees).FirstAsync(x => x.Title.Equals(projectRef))).Employees);
        }

        public ActionResult FindEmployees(string nom)
        {
            ActionResult result = null;
            List<Employee> employees = db.Employees.Where(x => x.Lastname.Equals(nom)).ToList();
            if (employees.Count == 1)
            {
                result = View("Details", employees.ElementAt(0));
            }
            else
            {
                if (employees.Count == 0)
                {
                    employees = db.Employees.Where(x => x.Lastname.Contains(nom)).ToList();
                }
                result = View("Listing", employees);
            }
            
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
