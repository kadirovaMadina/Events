using Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbInitializer(ApplicationDbContext context) : IApplicationDbInitializer
{
    public void Initialize()
    {
        if (context.Database.IsRelational())
            context.Database.Migrate();
    }
}