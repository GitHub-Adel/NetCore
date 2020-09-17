using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SocialMedia.Core.Datas;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Exceptions;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;

namespace SocialMedia.Core.Services
{
    public class UserService : IUser
    {
        private readonly SocialmediaDBContext _context;
        public UserService(SocialmediaDBContext _context)
        {
            this._context = _context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                //logica de negocio: no se puede insertar un usuario si ya existe.
                var _user = _context.User.FirstOrDefault(x => x.Phone.Equals(user.Phone));
                if (_user != null) throw new CustomException($"Ya hay un User con ese Phone {user.Phone}",HttpStatusCode.NotFound);

                _context.User.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            { 
                //registramos error en un log.
                //le mostramos error al usuario.
                if(ex.GetType()==typeof(CustomException)){
                    var a= (CustomException)ex;
                   throw new CustomException(ex.Message,a.StatusCode,ex.InnerException);
                } 
                else { //sino no es un eror personalizado, muestro un internal error por default
                    throw new CustomException(ex.Message,HttpStatusCode.InternalServerError,ex.InnerException);
                }

                throw new Exception();
            }
        }


        public IEnumerable<User> GetByFilters(UserQueryFilter filters)
        {
            
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
            return users;
           
        }

    }
}
