using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Planny.Models;
using Planny.ViewModel;

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

        public ActionResult New()
        {
            var statuses = _context.Status.ToList();
            var priorities = _context.Priority.ToList();
            var userJourneys = _context.UserJourneys.ToList();
            var viewModel = new ProjectTaskFormViewModel
            {
                Statuses = statuses,
                Priorities = priorities,
                UserJourneys = userJourneys
            };
            return View("ProjectTaskForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(ProjectTask task)
        {
            _context.ProjectTasks.Add(task); //just in the memory
            _context.SaveChanges(); //wraps changes in a transaction

            return RedirectToAction("Index", "ProjectTasks");
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

