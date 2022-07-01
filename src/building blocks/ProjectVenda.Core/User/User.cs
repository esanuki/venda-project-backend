using Microsoft.AspNetCore.Http;
using ProjectVenda.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ProjectVenda.Core.User
{
    public class User : IUser
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public User(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string Name =>_contextAccessor.HttpContext.User.Identity.Name;

        public IEnumerable<Claim> GetClaims()
        {
            return _contextAccessor.HttpContext.User.Claims;
        }

        public HttpContext GetHttpContext()
        {
            return _contextAccessor.HttpContext;
        }

        public string GetUserEmail()
        {
            return IsAuthenticated() ? _contextAccessor.HttpContext.User.GetUserEmail() : string.Empty;
        }

        public Guid GetUserId()
        {
            return IsAuthenticated() ? Guid.Parse(_contextAccessor.HttpContext.User.GetUserId()) : Guid.Empty;
        }

        public string GetUserRefreshToken()
        {
            return IsAuthenticated() ? _contextAccessor.HttpContext.User.GetUserRefreshToken() : string.Empty;
        }

        public string GetUserToken()
        {
            return IsAuthenticated() ? _contextAccessor.HttpContext.User.GetUserToken() : string.Empty;
        }

        public bool HaveRole(string roleName)
        {
           return _contextAccessor.HttpContext.User.IsInRole(roleName);
        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
