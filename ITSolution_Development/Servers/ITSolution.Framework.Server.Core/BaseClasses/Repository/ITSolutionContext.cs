using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITSolution.Framework.Server.Core.BaseClasses.Repository
{
    public class ITSolutionContext : ITSolutionDbContext
    {
        public ITSolutionContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }
    }
}
