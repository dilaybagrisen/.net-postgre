using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SporEtkinlikleriYonetimSistemi.Data;
using SporEtkinlikleriYonetimSistemi.Models;
using System.Threading.Tasks;

namespace SporEtkinlikleriYonetimSistemi.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParticipantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Katılımcı Kayıt Sayfası
        public IActionResult Register()
        {
            ViewData["Events"] = _context.Events.Select(e => new SelectListItem
            {
                Value = e.EventID.ToString(),
                Text = $"{e.Title} ({e.StartDate.ToShortDateString()} - {e.EndDate.ToShortDateString()})"
            }).ToList();

            return View(new Participant());
        }

        // POST: Katılımcı Kaydı İşlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Participant model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                ModelState.AddModelError("Name", "Lütfen adınızı giriniz.");
            }

            if (ModelState.IsValid)
            {
                // Katılımcıyı doğrudan kaydediyoruz
                var newParticipant = _context.Participants.Add(model);
                //var selectedEvent = _context.Events.ToList().Where(x => x.EventID == model.SelectedEventID).First();
                //model.Event = selectedEvent;
                await _context.SaveChangesAsync();

                // Kayıt sonrası özet sayfasına yönlendirme
                return RedirectToAction("Summary", model);
            }

            // Hatalı durumlarda etkinlik listesini tekrar yükle
            ViewData["Events"] = _context.Events.Select(e => new SelectListItem
            {
                Value = e.EventID.ToString(),
                Text = $"{e.Title} ({e.StartDate.ToShortDateString()} - {e.EndDate.ToShortDateString()})"
            }).ToList();

            return View(model);
        }

        // GET: Katılımcı Özeti
        public async Task<IActionResult> Summary(int id)
        {
            var participant = await _context.Participants
                .Include(p => p.Event) // Seçilen etkinliği yükle
                .FirstOrDefaultAsync(p => p.ID == id);

            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // Stored Procedure ile Eski Katılımcıları Sil
        public IActionResult DeleteOldParticipants()
        {
            _context.Database.ExecuteSqlRaw("CALL DeleteOldParticipants();");
            return RedirectToAction("List"); // İlgili bir sayfaya yönlendirin
        }



        public async Task<IActionResult> List()
        {
            

            var viewModel = await _context.ParticipantWithEventViewModels.ToListAsync();

            return View(viewModel);
        }









    }
}
