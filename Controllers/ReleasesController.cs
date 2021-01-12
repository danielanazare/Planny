using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planny.Models;

namespace Planny.Controllers
{
    public class ReleasesController : Controller
    {
        // GET: ProjectTasks

        private ApplicationDbContext _context;


        public ReleasesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var releasess = _context.Releases.Include(r => r.Project);

            return View(releasess);
        }



        public ActionResult Details(int id)
        {
            var release = _context.Releases.Include(r => r.Project).SingleOrDefault(p => p.Id == id);
            if (release == null)
            {
                return HttpNotFound();
            }

            return View(release);
        }
    }
}