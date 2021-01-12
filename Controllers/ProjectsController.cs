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
        // GET: Projects
        public ActionResult Index()
        {
            var projects = GetProjects();

            return View(projects);
        }

        public IEnumerable<Project> GetProjects()
        {
            return  new List<Project>
            {
                new Project() { Id = 1, Name = "Proiect 1"},
                new Project() { Id = 2, Name = "Project 2"}
            };
        }

        public ActionResult Details(int id)
        {
            var project = GetProjects().SingleOrDefault(p => p.Id == id);
            if (project == null)
            {
                return HttpNotFound();
            }

            return View(project);
        }
    }
}