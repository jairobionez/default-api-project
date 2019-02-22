using System.Web.Http;
using WebActivatorEx;
using DefaultProject.Application;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace DefaultProject.Application
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
               .EnableSwagger(c =>
               {
                   c.SingleApiVersion("v1", "Default Project API");
                   c.IncludeXmlComments(string.Format(@"{0}App_Data\DefaultProject.xml",
                                        System.AppDomain.CurrentDomain.BaseDirectory));
               })
           .EnableSwaggerUi();
        }
    }
}
