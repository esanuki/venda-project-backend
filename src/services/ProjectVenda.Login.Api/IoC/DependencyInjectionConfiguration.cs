using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectVenda.Core.Mediator;
using ProjectVenda.Login.Api.Application.Comand;
using ProjectVenda.Login.Api.Application.ComandHandler;

namespace ProjectVenda.Login.Api.IoC
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            //Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Commands
            services.AddScoped<IRequestHandler<RegistrarUsuarioCommand, ValidationResult>, LoginCommandHandler>();
        }
    }
}
