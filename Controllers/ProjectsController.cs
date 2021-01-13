using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Planny.Models;

namespace Planny.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext _context;

        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageProject)]
        public ActionResult New()
        {
            
            return View("ProjectForm");
        }

        [HttpPost]
        public ActionResult Save(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View("ProjectForm", project);
            }
            if (project.Id == 0)
            {
                _context.Projects.Add(project); //just in the memory
            }
            else
            {
                var projectInDb = _context.Projects.Single(p => p.Id == project.Id);
                projectInDb.Name = project.Name;
            }

            _context.SaveChanges(); //wraps changes in a transaction

            return RedirectToAction("Index", "Projects");
        }
        public ActionResult Edit(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (project == null)
                return HttpNotFound();
            return View("ProjectForm", project);
        }

        public ActionResult Index()
        {
            var projects = _context.Projects;
            if (User.IsInRole(RoleName.CanManageProject))
                return View(projects);
            
            return View("ReadOnlyList", projects);
        }

     

        public ActionResult Details(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (project == null)
            {
                return HttpNotFound();
            }

            return View(project);
        }

        public ActionResult Delete(int id)
        {
            var projectInDb = _context.Projects.SingleOrDefault(d => d.Id == id);

            if (projectInDb == null)
                return HttpNotFound();

            _context.Projects.Remove(projectInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Projects");
        }


    }
}