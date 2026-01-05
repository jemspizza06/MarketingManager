using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using Infraestructure.Persistence;
using Domain.Entities;               

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
