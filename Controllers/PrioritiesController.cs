using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planny.Models;

namespace Planny.Controllers
{
    public class PrioritiesController : Controller
    {
        // GET: Priorities
        private ApplicationDbContext _context;

        public PrioritiesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New()
        {

            return View("PriorityForm");
        }

        [HttpPost]
        public ActionResult Save(Priority priority)
        {
            if (priority.Id == 0)
            {
                _context.Priority.Add(priority); //just in the memory
            }
            else
            {
                var priorityInDb = _context.Priority.Single(p => p.Id == priority.Id);
                priorityInDb.Name = priority.Name;
            }

            _context.SaveChanges(); //wraps changes in a transaction

            return RedirectToAction("Index", "Priorities");
        }
        public ActionResult Edit(int id)
        {
            var priority = _context.Priority.SingleOrDefault(p => p.Id == id);
            if (priority == null)
                return HttpNotFound();
            return View("PriorityForm", priority);
        }
        public ActionResult Index()
        {
            var priorities = _context.Priority;

            return View(priorities);
        }



        public ActionResult Details(int id)
        {
            var priority = _context.Priority.SingleOrDefault(p => p.Id == id);
            if (priority == null)
            {
                return HttpNotFound();
            }

            return View(priority);
        }
    }
}