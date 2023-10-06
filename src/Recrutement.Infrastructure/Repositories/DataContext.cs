using Microsoft.EntityFrameworkCore;
using Recrutement.Infrastructure.Repositories.Entities;

namespace Recrutement.Infrastructure.Repositories;

public class DataContext : DbContext
{
    public DbSet<Appareil> Appareils { get; set; }
    public DbSet<Releve> Releves { get; set; }
    public DbSet<UtilisateurDb> Utilisateurs { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Appareil>()
            .HasMany(appareil => appareil.Releves)
            .WithOne(releve => releve.Appareil)
            .HasForeignKey(releve => releve.AppareilId);

        builder.Entity<Releve>()
            .HasOne(releve => releve.Appareil)
            .WithMany(appareil => appareil.Releves)
            .HasForeignKey(releve => releve.AppareilId)
            .IsRequired();

        builder.Entity<Releve>()
            .Property(releve => releve.Valeur)
            .HasPrecision(18, 6);

        
        base.OnModelCreating(builder);
    }
}