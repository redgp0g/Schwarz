using Microsoft.EntityFrameworkCore;
using Schwarz.Models;
using Microsoft.AspNetCore.Identity;
using Schwarz.Data;
using Schwarz.Areas.Identity.Data;
using System.Globalization;
using Schwarz.Services;
using Schwarz.Services.Interfaces;
using Microsoft.Extensions.FileProviders;
using Schwarz.Components;
using MudBlazor.Services;
using MudBlazor;
using MudBlazor.Translations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("pt-BR");
});

var connectionString = Environment.GetEnvironmentVariable("SCHWARZ_DATABASE_STRING_CONNECTION");
builder.Services.AddDbContext<SchwarzContext>
(options => options.UseLazyLoadingProxies()
.UseSqlServer(connectionString)
);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();

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

builder.Services.AddMudServices();
builder.Services.AddMudTranslations();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
    RequestPath = new PathString("/node_modules")
});

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.MapBlazorHub();
app.Run();
