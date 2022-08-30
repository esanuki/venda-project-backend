using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProjectVenda.BFF.Api.Helpers;
using ProjectVenda.BFF.Api.Services.Login;
using ProjectVenda.Core.Data;
using ProjectVenda.Core.DomainObjects;
using ProjectVenda.Core.Mediator;
using ProjectVenda.Core.Notificator;
using ProjectVenda.Core.User;

namespace ProjectVenda.BFF.Api.IoC
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, User>();
            services.AddScoped<INotificator, Notificator>();

            services.AddTransient<HttpClienteAuthorizationDelegate>();

            services.AddHttpClient<ILoginService, LoginService>()
                .AddHttpMessageHandler<HttpClienteAuthorizationDelegate>();
        }
    }
}
