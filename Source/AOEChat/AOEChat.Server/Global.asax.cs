using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
//using Autofac.Integration.Mvc;
using AOEChat.Server.Core.Modules;
using Autofac.Integration.WebApi;
using Serilog;

namespace AOEChat.Server
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IContainer _container;
        //private static IContainer _webApiContainer;
        //private static ILog<HttpApplication> _log;

        public IContainer Container
        {
            get { return _container; }
        }

        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<BusinessLogicModule>();
            builder.RegisterModule<DataServiceModule>();
            //builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            //builder.RegisterApiControllers(typeof(WebApiApplication).Assembly).PropertiesAutowired();

            _container = builder.Build();

            //Solution1
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(_container);


            //Solution2
             //Set the dependency resolver for Web API.
            var webApiResolver = new AutofacWebApiDependencyResolver(_container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;


            //// Set the dependency resolver for MVC.
                        //var mvcResolver = new AutofacDependencyResolver(_container);
                        //DependencyResolver.SetResolver(mvcResolver);

            //DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));

            //Log.Logger = _container.Resolve<ILogger>();
            Log.Information("Application started!");

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);



            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
