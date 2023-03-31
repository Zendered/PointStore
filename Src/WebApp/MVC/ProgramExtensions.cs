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

        public static void AddCustomMVCConfig(this WebApplication app)
        {

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/error/500");
                app.UseStatusCodePagesWithRedirects("/error/{0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.AddCustomAuthentication();

            app.UseMiddleware<ExceptionMiddleware>();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }

        public static void AddCustomConfiguration(this WebApplicationBuilder builder)
        {
            builder.Configuration.AddConfiguration(GetConfiguration()).Build();

        }

        static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
