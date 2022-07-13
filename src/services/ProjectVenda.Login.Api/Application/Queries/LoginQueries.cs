using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectVenda.Core.Notificator;
using ProjectVenda.Login.Api.Application.Queries.Interfaces;
using ProjectVenda.Login.Api.Domain.Interfaces;
using ProjectVenda.Login.Api.Interop.Dto;
using ProjectVenda.Login.Api.Interop.ViewModels;
using System;
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
                return await _loginService.GenerateToken(loginViewModel.Email);
            }

            if (result.IsLockedOut)
            {
                AddErrors("Usuário temporariamente bloqueado por tentativas inválidas");
                return null;
            }

            AddErrors("Usuário ou Senha inválidas");
            return null;
        }

        public async Task<LoginResponseDto> RefreshToken(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                _notificator.Handle(new Core.DomainObjects.Notification("Refresh Token Inválido"));
                return null;
            }

            var token = await _loginService.GetRefreshToken(Guid.Parse(refreshToken));

            if (token is null)
            {
                _notificator.Handle(new Core.DomainObjects.Notification("Refresh Token expirado"));
                return null;
            }

            return await _loginService.GenerateToken(token.Email);
        }
    }
}
