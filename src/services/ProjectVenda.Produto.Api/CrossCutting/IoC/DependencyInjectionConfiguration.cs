using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectVenda.Core.Data;
using ProjectVenda.Core.Mediator;
using ProjectVenda.Core.Notificator;
using ProjectVenda.Core.User;
using ProjectVenda.Produto.Api.Application.Queries;
using ProjectVenda.Produto.Api.Application.Queries.Interfaces;
using ProjectVenda.Produto.Api.Persistance;
using ProjectVenda.Produto.Api.Persistance.Repository;

namespace ProjectVenda.Produto.Api.CrossCutting.IoC
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            //UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWorkProduto>();

            //Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Notificator
            services.AddScoped<INotificator, Notificator>();

            ////Commands
            

            ////Services
            //services.AddScoped<ILoginService, LoginService>();

            ////Queries
            services.AddScoped<IProdutoQueries, ProdutoQueries>();

            ////User
            services.AddScoped<IUser, User>();

            //Repository
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

        }
    }
}
