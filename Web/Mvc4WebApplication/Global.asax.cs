using Mvc4WebApplication.Migrations;
using Mvc4WebApplication.Models.Binders;
using Mvc4WebApplication.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Mvc4WebApplication
{
  // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
  // visit http://go.microsoft.com/?LinkId=9394801

  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      Database.SetInitializer(new MigrateDatabaseToLatestVersion<DubaiDbContext, Configuration>());

      using (var ctx = new DubaiDbContext())
      {
        //var rolesCount = ctx.Roles.Count(); // should return 2
        var maturitiesCount = ctx.Maturities.Count();
      }
      AreaRegistration.RegisterAllAreas();

      WebApiConfig.Register(GlobalConfiguration.Configuration);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      AuthConfig.RegisterAuth();

      //http://stackoverflow.com/questions/7835614/asp-net-mvc3-datetime-format/7836093#7836093
      //ModelBinders.Binders.Add(typeof(DateTime), new MyDateTimeModelBinder());
    }
  }
}