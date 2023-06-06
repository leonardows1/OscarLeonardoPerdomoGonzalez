using Microsoft.EntityFrameworkCore;
using OscarLeonardoPerdomoGonzalez.Models;
using OscarLeonardoPerdomoGonzalez.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HalterofiliaContext>(options => options.UseInMemoryDatabase(databaseName: "HalterofiliaDb"));
//builder.Services.AddSqlServer<HalterofiliaDbContext>(builder.Configuration.GetConnectionString("HalterofiliaDB"));
builder.Services.AddScoped<IHalterofiliaService, HalterofiliaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
