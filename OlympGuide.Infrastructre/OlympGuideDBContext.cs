using Microsoft.EntityFrameworkCore;
using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Infrastructre
{
    public class OlympGuideDBContext(DbContextOptions<OlympGuideDBContext> options) : DbContext(options)
    {
        public DbSet<SportField> SportFields { get; set; }
    }
}