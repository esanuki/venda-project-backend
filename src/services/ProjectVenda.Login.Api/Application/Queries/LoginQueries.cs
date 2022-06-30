using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectVenda.Core.Notificator;
using ProjectVenda.Login.Api.Application.Queries.Interfaces;
using ProjectVenda.Login.Api.Interop.ViewModels;
using System.Threading.Tasks;

namespace ProjectVenda.Login.Api.Application.Queries
{
    public class LoginQueries : Core.DomainObjects.Queries, ILoginQueries
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly IMapper _mapper;

        public LoginQueries(
            INotificator notificator,
            UserManager<IdentityUser> userManager) : base(notificator)
        {
            _userManager = userManager;
        }

        public Task<ActionResult> Login(LoginViewModel loginViewModel)
        {

            return null;
        }
    }
}
