using Microsoft.EntityFrameworkCore;
using Schwarz.Models;
using Microsoft.AspNetCore.Identity;
using Schwarz.Data;
using Schwarz.Areas.Identity.Data;
using Microsoft.Extensions.Options;
using Schwarz.Repository.Interfaces;
using Schwarz.Repository;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("SchwarzContextConnection") ?? throw new InvalidOperationException("Connection string 'SchwarzContextConnection' not found.");

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHFqVkNrXVNbdV5dVGpAd0N3RGlcdlR1fUUmHVdTRHRcQl5gSHxTdkNiUH9eeHA=;Mgo+DSMBPh8sVXJ1S0d+X1RPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSX1Qd0djWXlfeXRXRmQ=;ORg4AjUWIQA/Gnt2VFhhQlJBfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5QdURhWX9YcX1VRWNY;MTU3NzM4NkAzMjMxMmUzMTJlMzMzNUQxeEVINnpGYytyODcwaWFhNkFWYzZybEQydjBUYzdSUlNCSzFJK0xoUWs9;MTU3NzM4N0AzMjMxMmUzMTJlMzMzNWhaR2Q1dnhLQy9RT3VsRHBBTjFERmVhUmhESVc1a3dGNU96Y1hjNlA4Y3M9;NRAiBiAaIQQuGjN/V0d+XU9Hc1RDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31TdUZiW39ednVcRmlVVQ==;MTU3NzM4OUAzMjMxMmUzMTJlMzMzNVNHekovZ2NBQ0RzRy9NNHB3cWl3eXdQZWhva3JocG9ZVXRzRlh6UHJTcTg9;MTU3NzM5MEAzMjMxMmUzMTJlMzMzNVQyNnZjUkhYaUZuRlRNNWFraUlLQlNoUWtzWDBJaVF5Z1E0TldHemtySXc9;Mgo+DSMBMAY9C3t2VFhhQlJBfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5QdURhWX9YcX1UQWFY;MTU3NzM5MkAzMjMxMmUzMTJlMzMzNVVnNUxBUis4eUpxZUdITTRuR3NTMm1NSENZUHZuZjQwL3JKWjJFcEJxMFU9;MTU3NzM5M0AzMjMxMmUzMTJlMzMzNWJDNHZhMDZybjR1ZklQdTdYaGRub1BSMkFsWnRtN0ZtS2o3ZkI1YTJYNnM9;MTU3NzM5NEAzMjMxMmUzMTJlMzMzNVNHekovZ2NBQ0RzRy9NNHB3cWl3eXdQZWhva3JocG9ZVXRzRlh6UHJTcTg9");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IEquipeFSPRepository, EquipeFSPRepository>();
builder.Services.AddScoped<IEquipeIdeiaRepository, EquipeIdeiaRepository>();
builder.Services.AddScoped<IFalhaRepository, FalhaRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<IFSPRepository, FSPRepository>();
builder.Services.AddScoped<IIdeiaRepository, IdeiaRepository>();
builder.Services.AddScoped<IPlanoAcaoRepository, PlanoAcaoRepository>();
builder.Services.AddScoped<IPlanoControleRepository, PlanoControleRepository>();




builder.Services.AddDbContext<SchwarzContext>
(options => options.UseLazyLoadingProxies()
                   .UseSqlServer(connectionString)
);

builder.Services.AddIdentity<SchwarzUser, IdentityRole>(options =>
	{
		options.SignIn.RequireConfirmedAccount = true;

		options.Password.RequireDigit = true;
		options.Password.RequireLowercase = false;
		options.Password.RequireNonAlphanumeric = false;
		options.Password.RequireUppercase = false;
		options.Password.RequiredLength = 6;
		options.Password.RequiredUniqueChars = 0;

		// Lockout settings.
		options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
		options.Lockout.MaxFailedAccessAttempts = 5;
		options.Lockout.AllowedForNewUsers = true;

		// User settings.
		options.User.AllowedUserNameCharacters =
		"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
		options.User.RequireUniqueEmail = false;
	}).AddDefaultUI()
	.AddEntityFrameworkStores<SchwarzContext>()
	.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
	options.Cookie.HttpOnly = true;
	options.ExpireTimeSpan = TimeSpan.FromMinutes(20);

	options.LoginPath = "/Identity/Account/Login";
	options.AccessDeniedPath = "/Identity/Account/AccessDenied";
	options.SlidingExpiration = true;
});


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
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
