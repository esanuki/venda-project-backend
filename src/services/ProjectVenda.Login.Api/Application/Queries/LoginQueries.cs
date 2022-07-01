using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectVenda.Core.Notificator;
using ProjectVenda.Login.Api.Application.Queries.Interfaces;
using ProjectVenda.Login.Api.Domain.Interfaces;
using ProjectVenda.Login.Api.Interop.Dto;
using ProjectVenda.Login.Api.Interop.ViewModels;
using System.Threading.Tasks;

namespace ProjectVenda.Login.Api.Application.Queries
{
    public class LoginQueries : Core.DomainObjects.Queries, ILoginQueries
    {
        private readonly ILoginService _loginService;

        public LoginQueries(
            INotificator notificator, 
            ILoginService loginService) : base(notificator)
        {
            _loginService = loginService;
        }

        public async Task<LoginResponseDto> Login(LoginViewModel loginViewModel)
        {
            var result = await _loginService.Login(loginViewModel);

            if (result.Succeeded)
            {
                return null;
            }

            if (result.IsLockedOut)
            {
                AddErrors("Usuário temporariamente bloqueado por tentativas inválidas");
                return null;
            }

            AddErrors("Usuário ou Senha inválidas");
            return null;
        }
    }
}
