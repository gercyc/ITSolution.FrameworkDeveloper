using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITSolution.Framework.Server.Core.BaseClasses.Repository
{
    public class ITSolutionContext : ITSolutionDbContext
    {
        public ITSDbContextOptions ITSDbContextOptions { get; set; }
        public ITSolutionContext(ITSDbContextOptions dbContextOptions) : base(dbContextOptions.DbContextOptions)
        {
            this.ITSDbContextOptions = dbContextOptions;
        }
        public ITSolutionContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
