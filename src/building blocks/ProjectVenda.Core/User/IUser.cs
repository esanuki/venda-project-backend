using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ProjectVenda.Core.User
{
    public interface IUser
    {
        string Name { get;}
        Guid GetUserId();
        string GetUserEmail();
        string GetUserToken();
        string GetUserRefreshToken();
        bool IsAuthenticated();
        bool HaveRole(string roleName);
        IEnumerable<Claim> GetClaims();
        HttpContext GetHttpContext();
    }
}
