using _01.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DuelConfiguration : IEntityTypeConfiguration<Duel>
{
    public void Configure(EntityTypeBuilder<Duel> builder)
    {
        builder.ToTable("Duel");

        builder.HasKey(t => t.Id); 
        builder.HasOne(t => t.Tournament).WithMany(t => t.Duels).HasForeignKey(t => t.TournamentId);
    }
} 