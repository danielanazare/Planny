using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planny.Models;

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
    }
}