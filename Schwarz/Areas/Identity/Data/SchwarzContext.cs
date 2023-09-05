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
	public DbSet<Cota> Cota{ get; set; }
	public DbSet<EquipeFSP> EquipeFSP{ get; set; }
	public DbSet<EquipeIdeia> EquipeIdeia { get; set; }
    public DbSet<Falha> Falha { get; set; }
	public DbSet<FSP> FSP{ get; set; }
	public DbSet<Funcionario> Funcionario { get; set; }
	public DbSet<Ideia> Ideia { get; set; }
    public DbSet<IdeiaAnexo> IdeiaAnexo { get; set; }
	public DbSet<PlanoAcao> PlanoAcao { get; set; }
	public DbSet<PlanoControle> PlanoControle { get; set; }
    public DbSet<PlanoControleEquipe> PlanoControleEquipe { get; set; }
    public DbSet<PlanoControleAnexo> PlanoControleAnexo { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
