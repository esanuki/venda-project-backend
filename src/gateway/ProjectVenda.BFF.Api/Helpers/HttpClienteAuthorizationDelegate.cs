using ProjectVenda.Core.User;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectVenda.BFF.Api.Helpers
{
    public class HttpClienteAuthorizationDelegate : DelegatingHandler
    {
        private readonly IUser _user;

        public HttpClienteAuthorizationDelegate(IUser user)
        {
            _user = user;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _user.GetUserToken();

            if (token is not null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken);
            
        }
    }
}
