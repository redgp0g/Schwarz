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
	public DbSet<EquipeIdeia> EquipeIdeia { get; set; }
    public DbSet<Falha> Falha { get; set; }
	public DbSet<Funcionario> Funcionario { get; set; }
	public DbSet<Ideia> Ideia { get; set; }
    public DbSet<IdeiaAnexo> IdeiaAnexo { get; set; }
    public DbSet<Registro> Registro { get; set; }
    public DbSet<RegistroCotas> RegistroCotas { get; set; }
    public DbSet<AlertaCota> AlertaCota { get; set; }
    public DbSet<LicaoAprendida> LicaoAprendida { get; set; }
    public DbSet<LicaoAprendidaAnexo> LicaoAprendidaAnexo { get; set; }
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<TransporteMercadoria> TransporteMercadoria { get; set; }
    public DbSet<PareQualidade> PareQualidade{ get; set; }
    public DbSet<PareQualidadeFoto> PareQualidadeFoto{ get; set; }
    public DbSet<PareSeguranca> PareSeguranca { get; set; }
    public DbSet<PareSegurancaFoto> PareSegurancaFoto { get; set; }
    public DbSet<VencedorPare> VencedorPare { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

}
