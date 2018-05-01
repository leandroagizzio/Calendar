using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Calendar.DAL
    {
    public class ApplicationDbContext : DbContext {

        public DbSet<Event> Events { get; set; }

    }
}