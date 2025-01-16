using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SporEtkinlikleriYonetimSistemi.Data;
using SporEtkinlikleriYonetimSistemi.Models;



namespace SporEtkinlikleriYonetimSistemi.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Events.Include(e => e.Organizer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.Organizer)
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewData["OrganizerID"] = new SelectList(_context.Users, "UserID", "Name");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,Title,Description,Location,StartDate,EndDate,OrganizerID")] Event @event)
        {
            if (!ModelState.IsValid)
            {
                // ModelState hatalarýný logla
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
            }

            if (ModelState.IsValid)
            {
           
                @event.StartDate = @event.StartDate.ToUniversalTime();
                @event.EndDate = @event.EndDate.ToUniversalTime();
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["OrganizerID"] = new SelectList(_context.Users, "UserID", "Name", @event.OrganizerID);
            return View(@event);
        }



        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["OrganizerID"] = new SelectList(_context.Users, "UserID", "UserID", @event.OrganizerID);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,Title,Description,Location,StartDate,EndDate,OrganizerID")] Event @event)
        {
            if (id != @event.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                @event.StartDate = @event.StartDate.ToUniversalTime();
                @event.EndDate = @event.EndDate.ToUniversalTime();
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrganizerID"] = new SelectList(_context.Users, "UserID", "UserID", @event.OrganizerID);
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.Organizer)
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event != null)
            {
                _context.Events.Remove(@event);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventID == id);
        }


        public async Task<IActionResult> PastEvents()
        {
            // View'den verileri çekiyoruz
            var pastEvents = await _context.PastEventsViews.ToListAsync();

            // View'e gönderiyoruz
            return View(pastEvents);
        }


        public async Task<IActionResult> TopEvents()
        {
            var topEvents = await _context.TopEventViewModel.ToListAsync();

            return View(topEvents);
        }


        public async Task<IActionResult> UpcomingEvents()
        {
            var upcomingEvents = await _context.upcomingModels
                .Select(e => new UpcomingModel
                {
                    EventID = e.EventID,
                    eventtitle = e.eventtitle,
                    StartDate=e.StartDate,
                    EndDate=e.EndDate,
                    organizername = e.organizername,
                })
                .ToListAsync();

            return View(upcomingEvents);
        }



        public async Task<IActionResult> EventsByOrganizer()
        {
            var eventsByOrganizer = await _context.EventsByOrganizerViewModel
                .Select(e => new EventsByOrganizerViewModel
                {
                    organizerid = e.organizerid,
                    organizername = e.organizername,
                    EventID = e.EventID,
                    eventtitle = e.eventtitle,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate
                })
                .ToListAsync();

            return View(eventsByOrganizer);
        }



        public async Task<IActionResult> EventDurationStats()
        {
            var eventDurations = await _context.EventDurationStatsView
                .Select(e => new EventDurationStatsViewModel
                {
                    EventID = e.EventID,
                    eventtitle = e.eventtitle,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    durationindays = e.durationindays
                }).ToListAsync();

            return View(eventDurations);
        }



    }



}
