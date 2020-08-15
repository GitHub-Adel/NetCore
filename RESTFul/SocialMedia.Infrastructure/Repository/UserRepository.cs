using System;
using System.Linq;
using System.Threading.Tasks;
using SocialMedia.Core;
using SocialMedia.Core.Interface;

namespace SocialMedia.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SocialmediaDBContext _context) : base(_context)
        {
        }

        public User GetByPhone(string phone)
        {
            var user = _entity.FirstOrDefault(x=>x.Phone.Equals(phone));
            return  user;
        }
    }
}
