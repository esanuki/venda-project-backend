using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProjectVenda.BFF.Api.Configuration;
using ProjectVenda.Core.Base;
using ProjectVenda.Core.Interop.Login;
using ProjectVenda.Core.Notificator;
using ProjectVenda.Core.Response;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectVenda.BFF.Api.Services.Login
{
    public class LoginService : Service, ILoginService
    {
        private readonly HttpClient _httpClient;
        public LoginService(INotificator notificator, HttpClient httpClient, IOptions<AppSettings> options) : base(notificator)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.LoginUrl);
        }

        public async Task<ResponseResult<LoginResponseDto>> Login(LoginViewModel login)
        {
            var content = SerializarObjeto(login);
            var response = await _httpClient.PostAsync("login/autenticar", content);

            var result = await DeserializarObjeto<ResponseResult<LoginResponseDto>>(response);

            TratarErrosResponse(result);

            return result;


        }

        public Task<ResponseResult<LoginResponseDto>> Register(IdentityUser user, string senha)
        {
            throw new System.NotImplementedException();
        }
    }
}
