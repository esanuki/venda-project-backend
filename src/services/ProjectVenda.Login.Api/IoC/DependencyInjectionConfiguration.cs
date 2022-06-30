using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectVenda.Core.Mediator;
using ProjectVenda.Core.Notificator;
using ProjectVenda.Login.Api.Application.Comand;
using ProjectVenda.Login.Api.Application.ComandHandler;
using ProjectVenda.Login.Api.Domain.Interfaces;
using ProjectVenda.Login.Api.Services;

namespace ProjectVenda.Login.Api.IoC
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            //Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Notificator
            services.AddScoped<INotificator, Notificator>();

            //Commands
            services.AddScoped<IRequestHandler<RegistrarUsuarioCommand, bool>, LoginCommandHandler>();

            //Services
            services.AddScoped<ILoginService, LoginService>();

        }
    }
}
