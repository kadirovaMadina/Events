using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class EventSponsorConfiguration : IEntityTypeConfiguration<EventSponsor>
{
    public void Configure(EntityTypeBuilder<EventSponsor> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasKey(e => new { e.EventId, e.SponsorId });

        // ---

        builder.HasOne(e => e.Event)
            .WithMany(es => es.EventSponsors)
            .HasForeignKey(e => e.EventId);

        builder.HasOne(e => e.Sponsor)
            .WithMany(es => es.EventSponsors)
            .HasForeignKey(e => e.SponsorId);
    }
}