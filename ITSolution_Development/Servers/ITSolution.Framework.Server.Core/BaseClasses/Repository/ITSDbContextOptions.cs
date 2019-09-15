using ITSolution.Framework.Core.BaseClasses;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITSolution.Framework.Server.Core.BaseClasses.Repository
{
    public class ITSDbContextOptions : IDbContextOptions
    {
        public DbContextOptions DbContextOptions { get { return optionsBuilder.Options; } }
        DbContextOptionsBuilder optionsBuilder;
        public ITSDbContextOptions()
        {
            optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(AppConfigManager.Configuration.ConnectionString);
        }

        public IEnumerable<IDbContextOptionsExtension> Extensions
        {
            get
            {
                return optionsBuilder.Options.Extensions;
            }
        }

        TExtension IDbContextOptions.FindExtension<TExtension>()
        {
            return optionsBuilder.Options.FindExtension<TExtension>();
        }
    }
}
