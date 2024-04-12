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
    public DbSet<Arquivo> Arquivo{ get; set; }
    public DbSet<Cota> Cota{ get; set; }
	public DbSet<EquipeIdeia> EquipeIdeia { get; set; }
    public DbSet<Falha> Falha { get; set; }
	public DbSet<Funcionario> Funcionario { get; set; }
	public DbSet<Ideia> Ideia { get; set; }
    public DbSet<IdeiaAnexo> IdeiaAnexo { get; set; }
	public DbSet<PlanoControle> PlanoControle { get; set; }
    public DbSet<Registro> Registro { get; set; }
    public DbSet<RegistroCotas> RegistroCotas { get; set; }
    public DbSet<AlertaCota> AlertaCota { get; set; }
    public DbSet<LicaoAprendida> LicaoAprendida { get; set; }
    public DbSet<ArquivoLicaoAprendida> ArquivoLicaoAprendida { get; set; }
    public DbSet<Cliente> Cliente { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

public DbSet<Schwarz.Models.TransporteMercadoria> TransporteMercadoria { get; set; } = default!;
}
