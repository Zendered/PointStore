using Identity.API;

var builder = WebApplication.CreateBuilder(args);

builder.AddCustomConfiguration();
builder.AddCustomMvc();
builder.AddCustomDatabase();
builder.AddCustomIdentity();
builder.AddCustomSwaggerConfig();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    //app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
