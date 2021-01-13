using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planny.Models;
using Planny.ViewModel;

namespace Planny.Controllers
{
    public class TimesController : Controller
    {
        // GET: Times
        private ApplicationDbContext _context;


        public TimesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var projectTasks = _context.ProjectTasks.ToList();

            var viewModel = new TimeFormViewModel
            {
                ProjectTasks = projectTasks
            };
            return View("TimeForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Time time)
        {

            if (time.Id == 0)
            {
                _context.Times.Add(time); //just in the memory
            }
            else
            {
                var timeInDb = _context.Times.Single(p => p.Id == time.Id);
                timeInDb.Description = time.Description;
                timeInDb.Date = time.Date;
                timeInDb.TimeSpent = time.TimeSpent;
                timeInDb.TaskId = time.TaskId;
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


            return RedirectToAction("Index", "Times");

        }
        public ActionResult Edit(int id)
        {
            var time = _context.Times.SingleOrDefault(p => p.Id == id);
            if (time == null)
                return HttpNotFound();
            var viewModel = new TimeFormViewModel
            {
                Time = time,
                ProjectTasks = _context.ProjectTasks.ToList()
            };
            return View("TimeForm", viewModel);
        }

        public ActionResult Index()
        {
            var times = _context.Times.Include(t => t.Task).Include(t => t.Task.UserJourney)
                .Include(t => t.Task.UserJourney.Sprint).Include(t => t.Task.UserJourney.Sprint.Release)
                .Include(t => t.Task.UserJourney.Sprint.Release.Project);

            return View(times);
        }



        public ActionResult Details(int id)
        {
            var time = _context.Times.Include(t => t.Task).Include(t => t.Task.UserJourney)
                    .Include(t => t.Task.UserJourney.Sprint).Include(t => t.Task.UserJourney.Sprint.Release)
                    .Include(t => t.Task.UserJourney.Sprint.Release.Project)
                    .SingleOrDefault(t => t.Id == id);


            if (time == null)
            {
                return HttpNotFound();
            }

            return View(time);
        }

        public ActionResult Delete(int id)
        {
            var timeInDb = _context.Times.SingleOrDefault(d => d.Id == id);

            if (timeInDb == null)
                return HttpNotFound();

            _context.Times.Remove(timeInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Times");
        }
    }
}