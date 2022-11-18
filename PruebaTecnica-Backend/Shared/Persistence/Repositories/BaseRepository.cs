using PruebaTecnica_Backend.Shared.Persistence.Contexts;

namespace PruebaTecnica_Backend.Shared.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context) { 
            _context = context; 
        }    
    }   
}
