using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace OwinService
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Services.Replace(typeof(IAssembliesResolver), new AssembliesResolver());
            appBuilder.UseWebApi(config);
        }
    }

    class AssembliesResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            ICollection<Assembly> assemblies = base.GetAssemblies();
            var apiAssembly = Assembly.LoadFrom("OwinService.dll");
            assemblies.Add(apiAssembly);
            return assemblies;
        }
    }   
}
