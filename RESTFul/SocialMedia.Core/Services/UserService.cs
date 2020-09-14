using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Datas;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Exceptions;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;

namespace SocialMedia.Core.Services
{
    public class UserService : IUserService
    {
        private readonly SocialmediaDBContext _context;
        private readonly IConfiguration configuration;

        public UserService(SocialmediaDBContext _context, IConfiguration configuration)
        {
            this._context = _context;
            this.configuration = configuration;
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                //logica de negocio: no se puede insertar un usuario si ya existe.
                var _user = _context.User.FirstOrDefault(x => x.Phone.Equals(user.Phone));
                if (_user != null) throw new CustomException("Ya hay un User con ese Phone");

                _context.User.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                //registramos error en un log.
                //le mostramos error al usuario.
                if (ex.GetType() == typeof(CustomException))
                    throw new CustomException($"{ex.Message}");
                else
                    throw new Exception($"{ex.Message}");
            }


        }


        public PagedList<User> GetByFilters(UserQueryFilter filters)
        {
            if(filters.ItemByPage == null) filters.ItemByPage = int.Parse(configuration["ItemByPage"]); 
            if(filters.CurrentPage == null) filters.CurrentPage = int.Parse(configuration["CurrentPage"]); 
            
            var users = _context.User.AsEnumerable();
            if (users != null)
            {
                if (filters.UserId != null)
                    users = users.Where(x => x.UserId.Equals(filters.UserId));
                if (filters.Firstname != null)
                    users = users.Where(x => x.Firstname.ToLower().Contains(filters.Firstname.ToLower()));
                if (filters.Lastname != null)
                    users = users.Where(x => x.Lastname.ToLower().Contains(filters.Lastname.ToLower()));
                if (filters.Phone != null)
                    users = users.Where(x => x.Phone.Equals(filters.Phone));
            }            
            
            return new PagedList<User>(users.ToList(), filters.ItemByPage.Value, filters.CurrentPage.Value);
        }

    }
}
