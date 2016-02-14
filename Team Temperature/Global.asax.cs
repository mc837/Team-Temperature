using System.Configuration;
using System.Reflection;
using Autofac;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.WebApi;
using MongoDB.Driver;
using Repository;
using Team_Temperature.Infrastructure.Commands;

namespace Team_Temperature
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private IContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            _container = WebApplicationConfiguration.ConfigureContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(_container);
        }
    }

    public class WebApplicationConfiguration
    {
        public static IContainer ConfigureContainer()
        {
            var containerBuilder = new ContainerBuilder();
            var assembly = Assembly.GetExecutingAssembly();
            var config = GlobalConfiguration.Configuration;

            containerBuilder.RegisterApiControllers(assembly);

            var mongoHost = "mongodb://localhost";
            var mongoDatabase = new MongoClient(mongoHost).GetDatabase("teamTemperature");
            containerBuilder.RegisterType<MongoProvider>().As<IMongoProvider>().WithParameter("database", mongoDatabase);

            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();

            containerBuilder.RegisterType<AddUserCommand>().As<IAddUserCommand>();

            var container = containerBuilder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return container;


        }
    }
}
