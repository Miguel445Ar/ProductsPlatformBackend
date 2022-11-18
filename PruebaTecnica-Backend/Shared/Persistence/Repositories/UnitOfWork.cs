using PruebaTecnica_Backend.Shared.Domain.Repositories;
using PruebaTecnica_Backend.Shared.Persistence.Contexts;

namespace PruebaTecnica_Backend.Shared.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
