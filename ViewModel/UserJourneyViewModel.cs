using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planny.Models;

namespace Planny.ViewModel
{
    public class UserJourneyViewModel
    {
        public UserJourney UserJourney { get; set; }
        public IEnumerable<ProjectTask> ProjectTasks { get; set; }
    }
}