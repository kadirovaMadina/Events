using Application.Services;
using Domain.Common.BaseEntities;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IBaseService<Event>, EventService>();
            services.AddScoped<IBaseService<Location>, LocationService>();
            services.AddScoped<IBaseService<EventCategory>, CategoryService>();
            services.AddScoped<IBaseService<Participant>, ParticipantService>();
            services.AddScoped<IBaseService<Organizer>, OrganizerService>();
            services.AddScoped<IBaseService<Speaker>, SpeakerService>();
            services.AddScoped<IBaseService<Sponsor>, SponsorService>();            
            services.AddScoped<IBaseService<EventRegistration>, EventRegistrationService>();
            services.AddScoped<IBaseService<EventOrganizer>, EventOrganizerService>();
            services.AddScoped<IBaseService<EventSpeaker>, EventSpeakerService>();
            services.AddScoped<IBaseService<EventSponsor>, EventSponsorService>();
            services.AddScoped<IBaseService<ContactInformation>, ContactInformationService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
