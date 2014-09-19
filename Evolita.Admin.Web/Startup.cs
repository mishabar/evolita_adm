using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Evolita.Admin.Data.Repositories;
using Evolita.Admin.Services;
using Microsoft.Owin;
using MongoDB.Driver;
using Owin;

[assembly: OwinStartupAttribute(typeof(Evolita.Admin.Web.Startup))]
namespace Evolita.Admin.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            MongoClient mongoClient = new MongoClient(ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString);
            builder.Register(c => mongoClient.GetServer().GetDatabase(ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString.Split('/').Last())).AsSelf();

            builder.Register(c => new StrategyRepository(c.Resolve<MongoDatabase>())).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.Register(c => new StrategyService(c.Resolve<IStrategyRepository>())).AsImplementedInterfaces().InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            ConfigureAuth(app);
        }
    }
}
