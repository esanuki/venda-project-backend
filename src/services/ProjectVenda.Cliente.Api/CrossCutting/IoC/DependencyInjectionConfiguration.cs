using Microsoft.Extensions.DependencyInjection;
using ProjectVenda.Cliente.Api.Persistance;
using ProjectVenda.Cliente.Api.Persistance.Repository.Cliente;
using ProjectVenda.Core.Data;
using ProjectVenda.Core.Mediator;
using ProjectVenda.Core.Notificator;
using ProjectVenda.Core.User;

namespace ProjectVenda.Cliente.Api.CrossCutting.IoC
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            //UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWorkCliente>();

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
            services.AddScoped<IUser, User>();

            //Repository
            services.AddScoped<IClienteRepository, ClienteRepository>();

        }
    }
}
