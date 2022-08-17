using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectVenda.Cliente.Api.Application.Comand;
using ProjectVenda.Cliente.Api.Application.ComandHandler;
using ProjectVenda.Cliente.Api.Application.Queries;
using ProjectVenda.Cliente.Api.Application.Queries.Interfaces;
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
            services.AddScoped<IRequestHandler<InsertClienteCommand, bool>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateClienteCommand, bool>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteClienteCommand, bool>, ClienteCommandHandler>();

            ////Services
            //services.AddScoped<ILoginService, LoginService>();

            ////Queries
            services.AddScoped<IClienteQueries, ClienteQueries>();

            ////User
            services.AddScoped<IUser, User>();

            //Repository
            services.AddScoped<IClienteRepository, ClienteRepository>();


        }
    }
}
