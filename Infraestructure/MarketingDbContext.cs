using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infraestructure.Persistence;

public class MarketingDbContext : DbContext
{
    public MarketingDbContext(DbContextOptions<MarketingDbContext> options) : base(options) { }

    public DbSet<AcademicProgram> AcademicPrograms { get; set; } // <--- Mira este nombre
    public DbSet<Prospect> Prospects => Set<Prospect>();
}