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

        public ActionResult New()
        {

            return View("StatusForm");
        }

        [HttpPost]
        public ActionResult Save(Status status)
        {
            if (!ModelState.IsValid)
            {
                
                return View("StatusForm", status);
            }
            if (status.Id == 0)
            {
                _context.Status.Add(status); //just in the memory
            }
            else
            {
                var statusInDb = _context.Status.Single(p => p.Id == status.Id);
                statusInDb.Name = status.Name;
            }

            _context.SaveChanges(); //wraps changes in a transaction

            return RedirectToAction("Index", "Status");
        }
        public ActionResult Edit(int id)
        {
            var status = _context.Status.SingleOrDefault(p => p.Id == id);
            if (status == null)
                return HttpNotFound();
            return View("StatusForm", status);
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

        public ActionResult Delete(int id)
        {
            var statusInDb = _context.Status.SingleOrDefault(d => d.Id == id);

            if (statusInDb == null)
                return HttpNotFound();

            _context.Status.Remove(statusInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Status");
        }
    }
}