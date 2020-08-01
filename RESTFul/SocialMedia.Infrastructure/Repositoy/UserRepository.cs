using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Api;
using SocialMedia.Core.Interface;

namespace SocialMedia.Infrastructure.Repositoy
{
    public class UserRepository : IUserRepository
    {
        private readonly SocialmediaDBContext db;
        public UserRepository(SocialmediaDBContext db)
        {
            this.db = db;
        }

        public async Task AddUser(User user)
        {
           db.Add(user);
           await db.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            db.Update(user);
            await db.SaveChangesAsync();
        }
        public async Task<User> GetUser(int id)
        {
            return await db.User.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
           return await db.User.ToListAsync();
        }

    }
}
