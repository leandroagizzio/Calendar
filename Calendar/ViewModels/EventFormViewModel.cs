using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Calendar.Models;

namespace Calendar.ViewModels {
    public class EventFormViewModel {

        public Event Event { get; set; }

        public string Title {
            get {
                return (((Event?.Id ?? 0) == 0)) ? "New Event" : "Edit Event";
            }
        }
    }
}