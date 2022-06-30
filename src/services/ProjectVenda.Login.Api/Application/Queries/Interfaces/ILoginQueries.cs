using Microsoft.AspNetCore.Mvc;
using ProjectVenda.Login.Api.Interop.ViewModels;
using System.Threading.Tasks;

namespace ProjectVenda.Login.Api.Application.Queries.Interfaces
{
    public interface ILoginQueries
    {
        Task<ActionResult> Login(LoginViewModel user);
    }
}
