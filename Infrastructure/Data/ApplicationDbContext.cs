using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Domain.Entities;
using Domain.Common.BaseEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata;

namespace Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<IdentityUser>(options)
{ 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUser>().ToTable("Users");
        modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
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