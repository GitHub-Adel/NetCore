using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Interface;

namespace SocialMedia.Infrastructure.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T: class
    {
        private readonly SocialmediaDBContext _context;
        protected readonly DbSet<T> _entity; 
        public BaseRepository(SocialmediaDBContext _context)
        {
            this._context = _context;
            _entity=_context.Set<T>();
        }

        public async Task Add(T entity)
        {
            _entity.Add(entity);
            await _context.SaveChangesAsync();
        }

    }



}
