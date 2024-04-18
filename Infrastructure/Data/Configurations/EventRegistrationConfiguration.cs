using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class EventRegistrationConfiguration : IEntityTypeConfiguration<EventRegistration>
{
    public void Configure(EntityTypeBuilder<EventRegistration> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.EventId)
            .IsRequired();

        builder.Property(e => e.ParticipantId)
            .IsRequired();

        builder.Property(e => e.RegistrationDate)
            .IsRequired();

        // ---

        builder.HasOne(e => e.Event)
            .WithMany(er => er.EventRegistrations)
            .HasForeignKey(e => e.EventId);

        builder.HasOne(e => e.Participant)
            .WithMany(er => er.EventRegistrations)
            .HasForeignKey(e => e.ParticipantId);
    }
}