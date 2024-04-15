using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Domain.Entities;

namespace Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<EventCategory> EventCategories { get; set; } = null!;
    public DbSet<EventRegistration> EventRegistrations { get; set; } = null!;
    public DbSet<EventSpeaker> EventSpeakers { get; set; } = null!;
    public DbSet<EventSponsor> EventSponsors { get; set; } = null!;
    public DbSet<Feedback> Feedbacks { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;
    public DbSet<Organizer> Organizers { get; set; } = null!;
    public DbSet<Participant> Participants { get; set; } = null!;
    public DbSet<Speaker> Speakers { get; set; } = null!;
    public DbSet<Sponsor> Sponsors { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}