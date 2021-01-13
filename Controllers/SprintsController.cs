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
    public class SprintsController : Controller
    {
        // GET: Sprints
        private ApplicationDbContext _context;


        public SprintsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var releases = _context.Releases.ToList();

            var viewModel = new SprintFormViewModel()
            {
                Releases = releases
            };
            return View("SprintForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Sprint sprint)
        {

            if (sprint.Id == 0)
            {
                _context.Sprint.Add(sprint); //just in the memory
            }
            else
            {
                var sprintInDb = _context.Sprint.Single(p => p.Id == sprint.Id);
                sprintInDb.Name = sprint.Name;
                sprintInDb.StartDate = sprint.StartDate;
                sprintInDb.EndDate = sprint.EndDate;
                sprintInDb.Effort = sprint.Effort;
                sprintInDb.TimeSpent = sprint.TimeSpent;
                sprintInDb.Progress = sprint.Progress;
                sprintInDb.ReleaseId = sprint.ReleaseId;
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


            return RedirectToAction("Index", "Sprints");

        }
        public ActionResult Edit(int id)
        {
            var sprint = _context.Sprint.SingleOrDefault(p => p.Id == id);
            if (sprint == null)
                return HttpNotFound();
            var viewModel = new SprintFormViewModel
            {
                Sprint = sprint,
                Releases = _context.Releases.ToList()
            };
            return View("SprintForm", viewModel);
        }

        public ActionResult Index()
        {
            var sprints = _context.Sprint.Include(s => s.Release).Include(s =>s.Release.Project);

            return View(sprints);
        }



        public ActionResult Details(int id)
        {
            var sprint = _context.Sprint.Include(s => s.Release).Include(s => s.Release.Project).SingleOrDefault(p => p.Id == id);
            if (sprint == null)
            {
                return HttpNotFound();
            }

            return View(sprint);
        }

        public ActionResult Delete(int id)
        {
            var sprintInDb = _context.Sprint.SingleOrDefault(d => d.Id == id);

            if (sprintInDb == null)
                return HttpNotFound();

            _context.Sprint.Remove(sprintInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Sprints");
        }
    }
}