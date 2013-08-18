using Mvc4WebApplication.Models;

namespace Mvc4WebApplication.Migrations
{
    using Mvc4WebApplication.Repository;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DubaiDbContext>
    {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DubaiDbContext context) {
            DubaiDbContextSeedWeb.Seed(context);
        }
    }

}
