using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Schwarz.Areas.Identity.Data;
using Schwarz.Models;

namespace Schwarz.Data;

public class SchwarzContext : IdentityDbContext<SchwarzUser>
{
    public SchwarzContext(DbContextOptions<SchwarzContext> options)
        : base(options)
    {
    }
    public DbSet<Ideia> Ideia { get; set; }
	public DbSet<EquipeIdeia> EquipeIdeia{ get; set; }
	public DbSet<Funcionario> Funcionario { get; set; }
    public DbSet<Maquina> Maquina { get; set; }
    public DbSet<CadastroOleo> CadastroOleo { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
