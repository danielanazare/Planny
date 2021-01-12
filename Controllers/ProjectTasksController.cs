using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Planny.Models;

namespace Planny.Controllers
{
    public class ProjectTasksController : Controller
    {
        // GET: ProjectTasks
        
        private ApplicationDbContext _context;


        public ProjectTasksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var projectTasks = _context.ProjectTasks.Include(t=>t.UserJourney);

            return View(projectTasks);
        }



        public ActionResult Details(int id)
        {
            var projectTask = _context.ProjectTasks.Include(t => t.UserJourney)
                .Include(t=>t.UserJourney.Sprint)
                .Include(t=>t.UserJourney.Sprint.Release)
                .Include(t=>t.UserJourney.Sprint.Release.Project)
                .SingleOrDefault(p => p.Id == id);
            if (projectTask == null)
            {
                return HttpNotFound();
            }

            return View(projectTask);
        }
    }
}

