using Microsoft.AspNetCore.Mvc;
using SporEtkinlikleriYonetimSistemi.Data;
using System.Linq;

public class UpcomingEventsViewComponent : ViewComponent
{
    private readonly ApplicationDbContext _context;

    public UpcomingEventsViewComponent(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        // Şu anki zamanı UTC'ye dönüştür
        var now = DateTime.UtcNow;

        // Yaklaşan etkinlikler
        var upcomingEvents = _context.Events
            .Where(e => e.StartDate >= now) // DateTime.UtcNow kullanılıyor
            .OrderBy(e => e.StartDate)
            .Take(5)
            .ToList();

        return View(upcomingEvents);
    }

}
