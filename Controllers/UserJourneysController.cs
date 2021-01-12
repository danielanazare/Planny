using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planny.Models;

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

        public ActionResult Index()
        {
            var userJourneys = _context.UserJourneys.Include(s => s.Sprint).Include(s => s.Sprint.Release).Include(s => s.Sprint.Release.Project);

            return View(userJourneys);
        }



        public ActionResult Details(int id)
        {
            var userJourney = _context.UserJourneys.Include(s => s.Sprint).Include(s => s.Sprint.Release).Include(s => s.Sprint.Release.Project).SingleOrDefault(p => p.Id == id);
            if (userJourney == null)
            {
                return HttpNotFound();
            }

            return View(userJourney);
        }
    }
}