using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProspectsController : ControllerBase
{
    private readonly MarketingDbContext _context;

    public ProspectsController(MarketingDbContext context)
    {
        _context = context;
    }

    [HttpGet("reminders/today")]
    public async Task<IActionResult> GetTodayReminders()
    {
        var today = DateTime.UtcNow.Date;
        var reminders = await _context.Prospects
            .Where(p => p.NextReminder.HasValue && p.NextReminder.Value.Date == today)
            .ToListAsync();
        return Ok(reminders);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProspect(Prospect prospect)
    {
        _context.Prospects.Add(prospect);
        await _context.SaveChangesAsync();
        return Ok(prospect);
    }
}
