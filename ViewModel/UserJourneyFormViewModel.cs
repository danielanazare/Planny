using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planny.Models;

namespace Planny.ViewModel
{
    public class UserJourneyFormViewModel
    {
        public UserJourney UserJourney { get; set; }
        public IEnumerable<Sprint> Sprints { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public IEnumerable<Priority> Priorities { get; set; }

        public string Title
        {
            get
            {
                if (UserJourney != null && UserJourney.Id != 0)
                    return "Edit User Journey";

                return "New User Journey";
            }
        }
    }
}