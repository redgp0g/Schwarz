using Microsoft.EntityFrameworkCore;
using Schwarz.Models;
using Microsoft.AspNetCore.Identity;
using Schwarz.Data;
using Schwarz.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SchwarzContextConnection") ?? throw new InvalidOperationException("Connection string 'SchwarzContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SchwarzContext>
(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<SchwarzUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SchwarzContext>();


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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Ideia}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
