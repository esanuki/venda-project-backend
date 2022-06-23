using Microsoft.AspNetCore.Builder;

namespace ProjectVenda.Core.IoC
{
    public static class JwtConfiguration
    {
        public static void UseAuthenticationConfiguration(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
