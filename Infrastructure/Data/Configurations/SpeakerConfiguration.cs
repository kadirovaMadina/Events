using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class SpeakerConfiguration : IEntityTypeConfiguration<Speaker>
{
    public void Configure(EntityTypeBuilder<Speaker> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(e => e.IsActive)
            .IsRequired();
    }
}