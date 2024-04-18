using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Domain.Entities;
using Domain.Common.BaseEntities;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }



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
    public DbSet<ContactInformation> ContactInformations { get; set; } = null!;
}