﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planny.Models;

namespace Planny.ViewModel
{
    public class ProjectTaskFormViewModel
    {
        public IEnumerable<Status> Statuses { get; set; }
        public ProjectTask ProjectTask { get; set; }
        public IEnumerable<Priority> Priorities { get; set; }
        public IEnumerable<UserJourney> UserJourneys { get; set; }
    }
}