using Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbInitializer : IApplicationDbInitializer
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            if (_context.Database.IsRelational())
                _context.Database.Migrate();
        }
    }
}
