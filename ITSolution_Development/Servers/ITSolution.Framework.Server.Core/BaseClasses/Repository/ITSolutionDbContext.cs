using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITSolution.Framework.Server.Core.BaseClasses.Repository
{
    public abstract class ITSolutionDbContext : DbContext
    {
        public ITSolutionDbContext()
        {

        }
        public ITSolutionDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("connectionstring");
        }
    }
}
