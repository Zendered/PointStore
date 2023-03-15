using Identity.API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();
            builder.Services.AddRazorPages();
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
        }

        public static void AddCustomAuthentication(this WebApplicationBuilder builder)
        {
            var secretkey = builder.Configuration["AppSettings:Secret"];
            var issuer = builder.Configuration["AppSettings:Issuer"];
            var audience = builder.Configuration["AppSettings:ValidIn"];

            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                bearerOptions.RequireHttpsMetadata = true;
                bearerOptions.SaveToken = true;
                bearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretkey)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidIssuer = issuer,
                };
            });
        }

        public static void AddCustomSwaggerConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(opt =>
            opt.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "PointStore Identity API",
                Description = "Authentication/Authorization API",
                Contact = new OpenApiContact() { Name = "Fake name", Email = "fake_email@mail.com" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/license/mit/") }
            }));
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
