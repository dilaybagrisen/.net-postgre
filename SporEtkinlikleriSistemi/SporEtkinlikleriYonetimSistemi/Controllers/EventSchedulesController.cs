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
    public class EventSchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventSchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventSchedules
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EventSchedules.Include(e => e.Event);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EventSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSchedule = await _context.EventSchedules
                .Include(e => e.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventSchedule == null)
            {
                return NotFound();
            }

            return View(eventSchedule);
        }

        // GET: EventSchedules/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "EventID", "EventID");
            return View();
        }

        // POST: EventSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartTime,EndTime,EventId")] EventSchedule eventSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventID", "EventID", eventSchedule.EventId);
            return View(eventSchedule);
        }

        // GET: EventSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSchedule = await _context.EventSchedules.FindAsync(id);
            if (eventSchedule == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventID", "EventID", eventSchedule.EventId);
            return View(eventSchedule);
        }

        // POST: EventSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartTime,EndTime,EventId")] EventSchedule eventSchedule)
        {
            if (id != eventSchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventScheduleExists(eventSchedule.Id))
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
            ViewData["EventId"] = new SelectList(_context.Events, "EventID", "EventID", eventSchedule.EventId);
            return View(eventSchedule);
        }

        // GET: EventSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSchedule = await _context.EventSchedules
                .Include(e => e.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventSchedule == null)
            {
                return NotFound();
            }

            return View(eventSchedule);
        }

        // POST: EventSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventSchedule = await _context.EventSchedules.FindAsync(id);
            if (eventSchedule != null)
            {
                _context.EventSchedules.Remove(eventSchedule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventScheduleExists(int id)
        {
            return _context.EventSchedules.Any(e => e.Id == id);
        }
    }
}
