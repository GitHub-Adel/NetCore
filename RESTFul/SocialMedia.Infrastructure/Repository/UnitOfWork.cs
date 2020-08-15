using System;
using System.Threading.Tasks;
using SocialMedia.Core.Interface;

namespace SocialMedia.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialmediaDBContext _context;

        public UnitOfWork(SocialmediaDBContext _context)
        {
            this._context = _context;
        }

        public IUserRepository UserRepo => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void SaveChange()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
