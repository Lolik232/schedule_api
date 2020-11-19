using Microsoft.EntityFrameworkCore;
using schedule_api_database.models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace schedule_api_database
{
    public class MsSqlContext : DbContext
    {
        public DbSet<Settings> Settings { get; set; }
        public MsSqlContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
