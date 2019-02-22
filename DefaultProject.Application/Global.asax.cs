using DefaultProject.Application.App_Start;
using DefaultProject.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace DefaultProject.Application
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DependenceConfig.Register(GlobalConfiguration.Configuration);            

            Database.SetInitializer<DefaultContext>(null);
        }
    }
}
