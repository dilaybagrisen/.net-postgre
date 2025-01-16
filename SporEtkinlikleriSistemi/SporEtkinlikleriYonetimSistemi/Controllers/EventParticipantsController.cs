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
    public class EventParticipantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventParticipantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventParticipants
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EventParticipants.Include(e => e.Event).Include(e => e.Participant);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EventParticipants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventParticipant = await _context.EventParticipants
                .Include(e => e.Event)
                .Include(e => e.Participant)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eventParticipant == null)
            {
                return NotFound();
            }

            return View(eventParticipant);
        }

        // GET: EventParticipants/Create
        public IActionResult Create()
        {
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "EventID");
            ViewData["ParticipantID"] = new SelectList(_context.Users, "UserID", "UserID");
            return View();
        }

        // POST: EventParticipants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EventID,ParticipantID")] EventParticipant eventParticipant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventParticipant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "EventID", eventParticipant.EventID);
            ViewData["ParticipantID"] = new SelectList(_context.Users, "UserID", "UserID", eventParticipant.ParticipantID);
            return View(eventParticipant);
        }

        // GET: EventParticipants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventParticipant = await _context.EventParticipants.FindAsync(id);
            if (eventParticipant == null)
            {
                return NotFound();
            }
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "EventID", eventParticipant.EventID);
            ViewData["ParticipantID"] = new SelectList(_context.Users, "UserID", "UserID", eventParticipant.ParticipantID);
            return View(eventParticipant);
        }

        // POST: EventParticipants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EventID,ParticipantID")] EventParticipant eventParticipant)
        {
            if (id != eventParticipant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventParticipant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventParticipantExists(eventParticipant.ID))
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
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "EventID", eventParticipant.EventID);
            ViewData["ParticipantID"] = new SelectList(_context.Users, "UserID", "UserID", eventParticipant.ParticipantID);
            return View(eventParticipant);
        }

        // GET: EventParticipants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventParticipant = await _context.EventParticipants
                .Include(e => e.Event)
                .Include(e => e.Participant)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eventParticipant == null)
            {
                return NotFound();
            }

            return View(eventParticipant);
        }

        // POST: EventParticipants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventParticipant = await _context.EventParticipants.FindAsync(id);
            if (eventParticipant != null)
            {
                _context.EventParticipants.Remove(eventParticipant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventParticipantExists(int id)
        {
            return _context.EventParticipants.Any(e => e.ID == id);
        }
    }
}
