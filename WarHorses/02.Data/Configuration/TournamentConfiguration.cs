using _01.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
{
    public void Configure(EntityTypeBuilder<Tournament> builder)
    {
        builder.ToTable("Tournament");

        builder.HasKey(t => t.Id);   

        builder.HasMany(t => t.Duels).WithOne(d => d.Tournament).HasForeignKey(d => d.TournamentId);
    }
} 