using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ContosoUniversity.DAL;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.SqlClient;
using ContosoUniversity.App_Start;

namespace ContosoUniversity
{
    public class MvcApplication : System.Web.HttpApplication
    {
        string SqlConnectionString;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //sRouteTable.Routes.MapHubs();
            
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DbInterception.Add(new SchoolInterceptorTransientErrors());
            DbInterception.Add(new SchoolInterceptorLogging());
            ScheduleTaskStartUp.StartAsync();
            SchoolContext sc = new SchoolContext();
            SqlConnectionString = sc.Database.Connection.ConnectionString;
        
 
            if (!String.IsNullOrEmpty(SqlConnectionString))
                SqlDependency.Start(SqlConnectionString);

        }
        protected void Application_End()
        {
            if (!String.IsNullOrEmpty(SqlConnectionString))
                SqlDependency.Stop(SqlConnectionString);
        }

    }
}
