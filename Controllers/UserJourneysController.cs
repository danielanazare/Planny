﻿using System;
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

        public ActionResult New()
        {
            var sprints = _context.Sprint.ToList();
            var statuses = _context.Status.ToList();
            var prioritites = _context.Priority.ToList();

            var viewModel = new UserJourneyFormViewModel()
            {
                Sprints = sprints,
                Statuses = statuses,
                Priorities = prioritites
            };
            return View("UserJourneyForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(UserJourney userJourney)
        {

            if (userJourney.Id == 0)
            {
                _context.UserJourneys.Add(userJourney); //just in the memory
            }
            else
            {
                var userJourneyInDb = _context.UserJourneys.Single(p => p.Id == userJourney.Id);
                userJourneyInDb.Name = userJourney.Name;
                userJourneyInDb.Description = userJourney.Description;
                userJourneyInDb.StatusId = userJourney.StatusId;
                userJourneyInDb.SprintId = userJourney.SprintId;
                userJourneyInDb.PriorityId = userJourney.PriorityId;
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


            return RedirectToAction("Index", "UserJourneys");

        }
        public ActionResult Edit(int id)
        {
            var userJourney  = _context.UserJourneys.SingleOrDefault(p => p.Id == id);
            if (userJourney == null)
                return HttpNotFound();
            var viewModel = new UserJourneyFormViewModel
            {
                UserJourney = userJourney,
                Sprints = _context.Sprint.ToList(),
                Statuses = _context.Status.ToList(),
                Priorities = _context.Priority.ToList()
            };
            return View("UserJourneyForm", viewModel);
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