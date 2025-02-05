using Microsoft.EntityFrameworkCore; 
using _01.Core.Entities;

public class WarhosesDbContext : DbContext
{
    public WarhosesDbContext(DbContextOptions<WarhosesDbContext> options) : base(options){} 
    
    public DbSet<Tournament> Tournaments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder){
        builder.ApplyConfiguration( new TournamentConfiguration());
    }
}