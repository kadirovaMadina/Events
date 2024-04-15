using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class EventSpeakerConfiguration : IEntityTypeConfiguration<EventSpeaker>
{
    public void Configure(EntityTypeBuilder<EventSpeaker> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasKey(e => new { e.EventId, e.SpeakerId });

        builder.HasOne(e => e.Event)
            .WithMany(e => e.EventSpeakers)
            .HasForeignKey(e => e.EventId);

        builder.HasOne(e => e.Speaker)
            .WithMany()
            .HasForeignKey(e => e.SpeakerId);
    }
}