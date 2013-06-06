using Mvc4WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Mvc4WebApplication.Repository
{
  public class DubaiDbContext : DbContext
  {
    public DbSet<InstrumentMaturity> Maturities { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Configurations.Add(new InstrumentMaturityConfiguration());
      base.OnModelCreating(modelBuilder);
    }
  }

  internal sealed class Configuration : DbMigrationsConfiguration<DubaiDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = true;
      AutomaticMigrationDataLossAllowed = true;
    }

    protected override void Seed(DubaiDbContext context)
    {
      DubaiDbContextSeedWeb.Seed(context);
    }
  }

  public class InstrumentMaturityConfiguration : EntityTypeConfiguration<InstrumentMaturity>
  {
    public InstrumentMaturityConfiguration()
    {
      HasKey(x => new { x.InstrumentName, x.Maturity });

      Ignore(x => x.MaturityToString);
      Ignore(x => x.LastInterestToString);
    }
  }

  public static class DubaiDbContextSeed
  //  public class DubaiInitializer : DropCreateDatabaseAlways<DubaiDbContext>
  //  public class DubaiInitializer : MigrateDatabaseToLatestVersion<DubaiDbContext>   //EF 5.0 ?
  {
    public static void Seed(DubaiDbContext context)
    {
      const string instrumentName = "Realised SX5E";

      //http://stackoverflow.com/questions/8550756/how-to-seed-data-with-many-to-may-relations-in-entity-framework-migrations

      if (!context.Maturities.Any())
      {
        var instrumentMaturities = new List<InstrumentMaturity>
                                     {
                                       new InstrumentMaturity()
                                         {
                                           InstrumentName = instrumentName,
                                           Maturity = new DateTime(2012, 12, 01),
                                           Price = 59.75m
                                         }
                                     };
        //instrumentMaturities.ForEach(instrumentMaturity => context.Maturities.AddOrUpdate(instrumentMaturity));   //ok
        //exemple où on seed avec une complex key
        instrumentMaturities.ForEach(
          instrumentMaturity =>
          context.Maturities.AddOrUpdate(m => new { m.InstrumentName, m.Maturity }, instrumentMaturity));
        context.SaveChanges();
      }
    }
  }
  public static class DubaiDbContextSeedWeb
  {
    //http://stackoverflow.com/questions/10474839/ef-4-3-1-migrations-seeding-not-working-as-expected
    public static void Seed(DubaiDbContext context)
    {
      MembershipCreateStatus createStatus;
      Membership.CreateUser("David", "123456", "david.mourrat@ca-cib.com", passwordQuestion: null, passwordAnswer: null,
                            isApproved: true, providerUserKey: null, status: out createStatus);
      Membership.CreateUser("Patrice", "123456", "patrice.sallandre-prestataire@ca-cib.com", passwordQuestion: null, passwordAnswer: null,
                            isApproved: true, providerUserKey: null, status: out createStatus);
      Membership.CreateUser("Thibaut", "123456", "thibaut.fourment@ca-cib.com", passwordQuestion: null, passwordAnswer: null,
                            isApproved: true, providerUserKey: null, status: out createStatus);
      Membership.CreateUser("Xavier", "123456", "xavier.desoindre@ca-cib.com", passwordQuestion: null, passwordAnswer: null,
                            isApproved: true, providerUserKey: null, status: out createStatus);

      if (!Roles.RoleExists("Admin"))
      {
        Roles.CreateRole("Admin");
      }
      if (!Roles.IsUserInRole("Patrice", "Admin"))
        Roles.AddUserToRole("Patrice", "Admin");
      if (!Roles.IsUserInRole("David", "Admin"))
        Roles.AddUserToRole("David", "Admin");

      //context.Roles.AddOrUpdate(r => r.Name, new Role { Name = "Admin" });

      DubaiDbContextSeed.Seed(context);
    }
  }
}