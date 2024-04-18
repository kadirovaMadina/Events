using Domain.Common.BaseEntities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class ContactInformationConfiguration : IEntityTypeConfiguration<ContactInformation>
{
    public void Configure(EntityTypeBuilder<ContactInformation> builder)
    {
        builder.HasKey(e => e.Id);

        // ---
    }
}