using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ProjectVenda.Login.Api.IoC
{
    public static class ApiConfiguration
    {
        public static void AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();

        }

        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowAnyHeader()
                              .AllowAnyOrigin()
                              .AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseIdentityCOnfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
