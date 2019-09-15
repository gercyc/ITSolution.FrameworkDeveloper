using ITSolution.Framework.Server.Core.BaseClasses.Repository;
using ITSolution.Framework.Server.Core.BaseEnums;
using ITSolution.Framework.Servers.Core.FirstAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.Servers.Core.FirstAPI.Data
{
    public class DBAccessContext : ITSolutionContext
    {

        public DBAccessContext(ITSDbContextOptions itsDbContextOptions) : base(itsDbContextOptions)
        {
            this.ITSDbContextOptions = itsDbContextOptions;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Menu> MenuSet { get; set; }
        public ITSRepository<Menu, DBAccessContext> MenuRep { get { return new ITSRepository<Menu, DBAccessContext>(this); } }
    }
}
