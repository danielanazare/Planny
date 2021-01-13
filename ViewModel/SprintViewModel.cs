using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planny.Models;

namespace Planny.ViewModel
{
    public class SprintViewModel
    {
        public Sprint Sprint { get; set; }
        public IEnumerable<UserJourney> UserJourneys { get; set; }
    }
}