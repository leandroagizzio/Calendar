using Calendar.DAL;
using Calendar.Models;
using Calendar.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calendar.Controllers
{
    public class EventController : Controller
    {

        private ApplicationDbContext _context;

        public EventController() {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        // GET: Event
        /*public ActionResult Index()
        {            
            return View(_context.Events.ToList());
        }*/

        public ActionResult Index(string start = null, string finish = null) {
            if (String.IsNullOrEmpty(start) || String.IsNullOrEmpty(finish))
                return View(_context.Events.ToList());
            var st = DateTime.Parse(start);
            var fn = DateTime.Parse(finish);

            return View(_context.Events.Where(e => e.StartDate >= st && e.FinishDate <= fn).ToList());
        }

        public ActionResult New() {
            var viewModel = new EventFormViewModel {
                Event = new Event()
            };

            return View("EventForm", viewModel);
        }

        public ActionResult Edit(int? id) {
            var eventt = _context.Events.SingleOrDefault(e => e.Id == (id ?? 0));
            if (eventt == null)
                return HttpNotFound();
            var viewModel = new EventFormViewModel {
                Event = eventt
            };
            return View("EventForm", eventt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(EventFormViewModel model) {
            /* if (!ModelState.IsValid)

                 return View("EventForm", new EventFormViewModel {
                     Event = eventt
                 });*/
            var eventt = model.Event;
            if (eventt.Id == 0) {
                _context.Events.Add(eventt);
            } else {
                var eventtInDb = _context.Events.Single(e => e.Id == eventt.Id);
                eventtInDb.Name = eventt.Name;
                eventtInDb.Description = eventt.Description;
                eventtInDb.StartDate = eventt.StartDate;
                eventtInDb.FinishDate = eventt.FinishDate;
            }
            try { 
                _context.SaveChanges();
            } catch (DbEntityValidationException e) {
                Console.WriteLine("oi");
                foreach (var eve in e.EntityValidationErrors) {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors) {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return RedirectToAction("Index","Event");
        }

        
    }
}