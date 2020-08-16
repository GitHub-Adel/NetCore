using System.Threading.Tasks;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Datas;

namespace SocialMedia.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public SocialmediaDBContext _context { get; }
        public UnitOfWork(SocialmediaDBContext _context)
        {
            this._context = _context;
            UserRepo= new UserRepository(_context);
        }

        public IUserRepository UserRepo { get; }

        public void Dispose() => _context?.Dispose();        
        public async Task SaveChangeAsync() => await _context.SaveChangesAsync();
        
    }
}
