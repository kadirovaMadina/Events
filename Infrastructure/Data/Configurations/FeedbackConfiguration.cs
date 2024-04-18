using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Grade)
            .IsRequired();

        builder.Property(e => e.Comment)
            .HasMaxLength(255);              

        // ---
        
        builder.HasOne(e => e.Event)
            .WithMany(f => f.Feedbacks)
            .HasForeignKey(e => e.EventId);

        builder.HasOne(p => p.Participant)
            .WithMany(f => f.Feedbacks)
            .HasForeignKey(p => p.ParticipantId);
    }
}