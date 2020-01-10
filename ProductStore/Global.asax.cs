using Autofac;
using Autofac.Integration.WebApi;
using ProductStore.Models;
using ProductStore.Repositories;
using System.Reflection;
using System.Web.Http;

namespace ProductStore
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
          
            builder.RegisterType<ProductDbContext>().InstancePerRequest();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().PropertiesAutowired();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


        }
    }
}
