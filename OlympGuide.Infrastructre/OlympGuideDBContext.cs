using Microsoft.EntityFrameworkCore;
using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Infrastructre
{
    public class OlympGuideDBContext : DbContext
    {
        public DbSet<SportField> SportFields { get; set; }
    }
}