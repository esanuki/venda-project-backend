using Microsoft.Extensions.DependencyInjection;
using ProjectVenda.Core.Mediator;
using ProjectVenda.Core.Notificator;

namespace ProjectVenda.Cliente.Api.IoC
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            //Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Notificator
            services.AddScoped<INotificator, Notificator>();

            ////Commands
            //services.AddScoped<IRequestHandler<RegistrarUsuarioCommand, bool>, LoginCommandHandler>();

            ////Services
            //services.AddScoped<ILoginService, LoginService>();

            ////Queries
            //services.AddScoped<ILoginQueries, LoginQueries>();

            ////User
            //services.AddScoped<IUser, User>();

        }
    }
}
