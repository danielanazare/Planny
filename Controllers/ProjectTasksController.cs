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
            var userJourneys = _context.UserJourneys.ToList();
            var statuses = _context.Status.ToList();
            var priorities = _context.Priority.ToList();

            var viewModel = new ProjectTaskFormViewModel
            {
                UserJourneys = userJourneys,
                Statuses = statuses,
                Priorities = priorities
            };
            return View("ProjectTaskForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(ProjectTask projectTask)
        {

            if (projectTask.Id == 0)
            {
                _context.ProjectTasks.Add(projectTask); //just in the memory
            }
            else
            {
                var projectTaskInDb = _context.ProjectTasks.Single(p => p.Id == projectTask.Id);
                projectTaskInDb.Name = projectTask.Name;
                projectTaskInDb.Description = projectTask.Description;
                projectTaskInDb.StatusId = projectTask.StatusId;
                projectTaskInDb.UserJourneyId = projectTask.UserJourneyId;
                projectTaskInDb.PriorityId = projectTask.PriorityId;
            }

            _context.SaveChanges(); //wraps changes in a transaction
            //try
            //{
            //    _context.SaveChanges(); //wraps changes in a transaction
            //}
            //catch (DbEntityValidationException e)
            //{
            //    Console.WriteLine(e);
            //}


            return RedirectToAction("Index", "ProjectTasks");

        }
        public ActionResult Edit(int id)
        {
            var projectTask = _context.ProjectTasks.SingleOrDefault(p => p.Id == id);
            if (projectTask == null)
                return HttpNotFound();
            var viewModel = new ProjectTaskFormViewModel
            {
                ProjectTask = projectTask,
                UserJourneys = _context.UserJourneys.ToList(),
                Statuses = _context.Status.ToList(),
                Priorities = _context.Priority.ToList()
            };
            return View("ProjectTaskForm", viewModel);
        }

        public ActionResult Index()
        {
            var projectTasks = _context.ProjectTasks
                .Include(t=>t.UserJourney)
                .Include(t=>t.Status)
                .Include(t=>t.Priority);

            return View(projectTasks);
        }



        public ActionResult Details(int id)
        {
            var projectTask = _context.ProjectTasks.Include(t => t.UserJourney)
                    .Include(t => t.Status)
                    .Include(t => t.Priority)
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

