using DefaultProject.Domain.Interfaces.Repositories.Base;
using DefaultProject.Domain.Interfaces.Repositories.UserRepository;
using DefaultProject.Domain.Interfaces.Services.Base;
using DefaultProject.Domain.Services.UserService;
using DefaultProject.Infra.Data.Context;
using DefaultProject.Infra.Data.Repositories;
using DefaultProject.Infra.Data.Repositories.UserRepository;
using DefaultProject.Infra.Data.Transactions;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace DefaultProject.Application.App_Start
{
    public static class DependenceConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<DefaultContext>(Lifestyle.Scoped);

            container.Register(typeof(IBaseRepository<,>), typeof(BaseRepository<,>), Lifestyle.Scoped);

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<IUserService, UserService>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(config);
            container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}