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


        public ActionResult New()
        {
            var projects = _context.Projects.ToList();
            
            var viewModel = new ReleaseFormViewModel()
            {
                Projects = projects
            };
            return View("ReleaseForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Release release)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ReleaseFormViewModel
                {
                    Release = release,
                    Projects = _context.Projects.ToList()
                };
                return View("ReleaseForm", viewModel);
            }

            if (release.Id == 0)
            {
                _context.Releases.Add(release); //just in the memory
            }
            else
            {
                var releaseInDb = _context.Releases.Single(p => p.Id == release.Id);
                releaseInDb.Name = release.Name;
                releaseInDb.StartDate = release.StartDate;
                releaseInDb.EndDate = release.EndDate;
                releaseInDb.ProjectId = release.ProjectId;
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


            return RedirectToAction("Index", "Releases");

        }
        public ActionResult Edit(int id)
        {
            var release = _context.Releases.SingleOrDefault(p => p.Id == id);
            if (release == null)
                return HttpNotFound();
            var viewModel = new ReleaseFormViewModel
            {
                Release = release,
                Projects = _context.Projects.ToList()
            };
            return View("ReleaseForm", viewModel);
        }
        public ActionResult Index()
        {
            var releases = _context.Releases.Include(r => r.Project);

            return View(releases);
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

        public ActionResult Delete(int id)
        {
            var releaseInDb = _context.Releases.SingleOrDefault(d => d.Id == id);

            if (releaseInDb == null)
                return HttpNotFound();

            _context.Releases.Remove(releaseInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Releases");
        }
    }
}