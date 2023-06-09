using WebApp.MVC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.AddCustomConfiguration();
builder.AddCustomIdentityConfig();
builder.AddCustomDependencyInjection();

var app = builder.Build();

app.AddCustomMVCConfig();

app.Run();
