using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planny.Models;

namespace Planny.Controllers
{
    public class StatusController : Controller
    {
        // GET: Status
        private ApplicationDbContext _context;


        public StatusController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var statuses = _context.Status;

            return View(statuses);
        }



        public ActionResult Details(int id)
        {
            var status = _context.Status.SingleOrDefault(s => s.Id == id);
            if (status == null)
            {
                return HttpNotFound();
            }

            return View(status);
        }
    }
}