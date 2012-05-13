using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Howframework.Domain.Infrastructure;
using Howframework.Domain.Commands;
using Howframework.Domain.ContextHandler;
using System.Reflection;

namespace Howframework.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);

            RegisterRoutes(RouteTable.Routes);

            var builder = new ContainerBuilder();

            var ctx1 = new RegisterUserContext();

            var commandBus = new CommandBus();
            commandBus.RegisterHandlerCommand<RegisterUserCommand>(ctx1.Handle);

            builder.Register<IBus>(c => commandBus).As<IBus>();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();


            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}