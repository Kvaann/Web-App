using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProjektContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjektContext") ?? throw new InvalidOperationException("Connection string 'ProjektContext' not found.")));

//Add services to the container.

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
