using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // <-- ESTO QUITA EL ROJO DE ToListAsync
using Infraestructure.Persistence;
using Domain.Entities;               // <-- ESTO QUITA EL ROJO DE AcademicProgram

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProgramsController : ControllerBase
{
    private readonly MarketingDbContext _context;

    public ProgramsController(MarketingDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AcademicProgram>>> GetPrograms()
    {
        // Revisa que en MarketingDbContext.cs se llame "AcademicPrograms"
        return await _context.AcademicPrograms.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<AcademicProgram>> CreateProgram(AcademicProgram program)
    {
        _context.AcademicPrograms.Add(program);
        await _context.SaveChangesAsync(); // <-- ESTO YA NO ESTARÁ EN ROJO
        return Ok(program);
    }
}