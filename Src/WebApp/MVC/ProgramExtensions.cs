using WebApp.MVC.Extensions;
using WebApp.MVC.Services;

namespace WebApp.MVC
{
    public static class ProgramExtensions
    {
        public static void AddCustomIdentityConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication()
                    .AddCookie(opt =>
                    {
                        opt.LoginPath = "/login/";
                        opt.AccessDeniedPath = "/Access-denied/";
                    });
        }

        public static void AddCustomAuthentication(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }

        public static void AddCustomDependencyInjection(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<IUser, AspNetUser>();
        }
    }
}
