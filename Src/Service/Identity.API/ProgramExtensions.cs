using Identity.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.API
{
    public static class ProgramExtensions
    {

        public static void AddCustomConfiguration(this WebApplicationBuilder builder)
        {
            builder.Configuration.AddConfiguration(GetConfiguration()).Build();

        }

        public static void AddCustomMvc(this WebApplicationBuilder builder)
        {
            //builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();
            //builder.Services.AddRazorPages();
        }

        public static void AddCustomDatabase(this WebApplicationBuilder builder) =>
            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration["ConnectionString:DefaultConnection"]));

        public static void AddCustomIdentity(this WebApplicationBuilder builder)
        {
            builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var config = builder.Build();

            return builder.Build();
        }
    }
}
