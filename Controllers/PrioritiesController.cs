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
        // GET: Projects
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