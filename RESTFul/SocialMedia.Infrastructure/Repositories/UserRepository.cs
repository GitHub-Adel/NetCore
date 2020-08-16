using System.Linq;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Datas;

namespace SocialMedia.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SocialmediaDBContext _context) : base(_context)
        {
        }
        //este metodo es propio de esta class
        //_entity se hereda de BaseRepository
        public User GetByPhone(string phone)
        {
            return _entity.FirstOrDefault(x=>x.Phone.Equals(phone));
        }
    }
}
