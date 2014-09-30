// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="">
//   Copyright © 2014 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace App.SchedulingApp
{
    using System.Web.Routing;

    using App.SchedulingApp.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("SchedulingApp.svc");

            routes.Add("Default", new DefaultRoute());
        }
    }
}
