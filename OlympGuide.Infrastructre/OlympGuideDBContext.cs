using Microsoft.EntityFrameworkCore;
using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Infrastructre
{
    public class OlympGuideDbContext(DbContextOptions<OlympGuideDbContext> options) : DbContext(options)
    {
        public DbSet<SportFieldType> SportFields { get; set; }
    }
}