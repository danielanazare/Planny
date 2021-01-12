using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Planny.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public UserJourney UserJourney { get; set; }
        public int UserJourneyID { get; set; }
        public string Description { get; set; }

        public Status Status { get; set; }
        public int StatusID { get; set; }
        public Priority Priority { get; set; }
        public int PriorityID { get; set; }


    }
}