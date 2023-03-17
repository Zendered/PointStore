using WebApp.MVC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.AddCustomIdentityConfig();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.AddCustomAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
