using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planny.Models;

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
    }
}