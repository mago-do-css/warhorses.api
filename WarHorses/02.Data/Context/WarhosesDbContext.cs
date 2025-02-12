using Microsoft.EntityFrameworkCore;
using _01.Core.Entities; 
using Pomelo.EntityFrameworkCore.MySql;

public class WarhosesDbContext : DbContext
{
    public WarhosesDbContext(DbContextOptions<WarhosesDbContext> options) : base(options){} 

    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Duel> Duels { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TournamentConfiguration());
        builder.ApplyConfiguration(new DuelConfiguration());
    }
}
