using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Datas;

namespace SocialMedia.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T: class
    {
        //para hacer _entity.Add en lugar de _context.Set<T>().Add
        protected readonly DbSet<T> _entity;
        //inicializa la propiedad _entity con el DbSet del _context
        public BaseRepository(SocialmediaDBContext _context) { _entity = _context.Set<T>();}
        public virtual void Add(T entity)  {_entity.Add(entity);}

    }


}
