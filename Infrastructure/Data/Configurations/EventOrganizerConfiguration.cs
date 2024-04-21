using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class EventOrganizerConfiguration : IEntityTypeConfiguration<EventOrganizer>
{
    public void Configure(EntityTypeBuilder<EventOrganizer> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasKey(e => new { e.EventId, e.OrganizerId });

        // ---

        builder.HasOne(e => e.Event)
            .WithMany(es => es.EventOrganizers)
            .HasForeignKey(e => e.EventId);

        builder.HasOne(e => e.Organizer)
            .WithMany(es => es.EventOrganizers)
            .HasForeignKey(e => e.OrganizerId);
    }
}