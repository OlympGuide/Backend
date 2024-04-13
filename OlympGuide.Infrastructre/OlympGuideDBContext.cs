﻿using Microsoft.EntityFrameworkCore;
using OlympGuide.Domain.Features.SportField;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Infrastructre
{
    public class OlympGuideDbContext(DbContextOptions<OlympGuideDbContext> options) : DbContext(options)
    {
        public DbSet<SportFieldType> SportFields { get; set; }
        public DbSet<UserProfile> Users { get; set; }
    }
}