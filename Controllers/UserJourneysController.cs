using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planny.Models;
using Planny.ViewModel;

namespace Planny.Controllers
{
    public class UserJourneysController : Controller
    {
        private ApplicationDbContext _context;


        public UserJourneysController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var sprints = _context.Sprint.ToList();
            var statuses = _context.Status.ToList();
            var priorities = _context.Priority.ToList();

            var viewModel = new UserJourneyFormViewModel()
            {
                Sprints = sprints,
                Statuses = statuses,
                Priorities = priorities
            };
            return View("UserJourneyForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(UserJourney userJourney)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new UserJourneyFormViewModel
                {
                    UserJourney = userJourney,
                    Sprints = _context.Sprint.ToList(),
                    Statuses = _context.Status.ToList(),
                    Priorities = _context.Priority.ToList()
                };
                return View("UserJourneyForm", viewModel);
            }

            if (userJourney.Id == 0)
            {
                _context.UserJourneys.Add(userJourney); //just in the memory
            }
            else
            {
                var userJourneyInDb = _context.UserJourneys.Single(p => p.Id == userJourney.Id);
                userJourneyInDb.Name = userJourney.Name;
                userJourneyInDb.Description = userJourney.Description;
                userJourneyInDb.StatusId = userJourney.StatusId;
                userJourneyInDb.SprintId = userJourney.SprintId;
                userJourneyInDb.PriorityId = userJourney.PriorityId;
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


            return RedirectToAction("Index", "UserJourneys");

        }
        public ActionResult Edit(int id)
        {
            var userJourney  = _context.UserJourneys.SingleOrDefault(p => p.Id == id);
            if (userJourney == null)
                return HttpNotFound();
            var viewModel = new UserJourneyFormViewModel
            {
                UserJourney = userJourney,
                Sprints = _context.Sprint.ToList(),
                Statuses = _context.Status.ToList(),
                Priorities = _context.Priority.ToList()
            };
            return View("UserJourneyForm", viewModel);
        }

        public ActionResult Index()
        {
            var userJourneys = _context.UserJourneys.Include(s => s.Sprint).Include(s => s.Sprint.Release).Include(s => s.Sprint.Release.Project);

            return View(userJourneys);
        }



        //public ActionResult Details(int id)
        //{
        //    var userJourney = _context.UserJourneys.Include(s => s.Sprint).Include(s => s.Sprint.Release).Include(s => s.Sprint.Release.Project).SingleOrDefault(p => p.Id == id);
        //    if (userJourney == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(userJourney);
        //}

        public ActionResult Details(int id)
        {
            var userJourney = _context.UserJourneys.Include(s => s.Sprint).Include(s => s.Sprint.Release).Include(s => s.Sprint.Release.Project).SingleOrDefault(p => p.Id == id);
            if (userJourney == null)
            {
                return HttpNotFound();
            }

            var viewModel = new UserJourneyViewModel
            {
                UserJourney = userJourney,
                ProjectTasks = _context.ProjectTasks
                    .Include(t=>t.Status)
                    .Include(t=>t.Priority)
                    .Where(t => t.UserJourneyId == id)
            };

            return View("UserJourneyView", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var userJourneyInDb = _context.UserJourneys.SingleOrDefault(d => d.Id == id);

            if (userJourneyInDb == null)
                return HttpNotFound();

            _context.UserJourneys.Remove(userJourneyInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "UserJourneys");
        }
    }
}