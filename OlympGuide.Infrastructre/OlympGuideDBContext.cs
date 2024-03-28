using Microsoft.EntityFrameworkCore;
using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Infrastructre
{
    public class OlympGuideDBContext : DbContext
    {
        public OlympGuideDBContext(DbContextOptions<OlympGuideDBContext> options) : base(options)
        {

        }

        public DbSet<SportField> SportFields { get; set; }
    }
}