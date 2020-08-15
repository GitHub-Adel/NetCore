using System;
using System.Threading.Tasks;
using SocialMedia.Core.Interface;

namespace SocialMedia.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository _userRepo)
        {
            this._userRepo = _userRepo;
        }

        public async Task<User> AddUser(User user)
        {
            try
            {
                //logica de negocio: no se puede insertar un usuario si ya existe.
                var _user = _userRepo.GetByPhone(user.Phone);
                if(_user==null)  throw new Exception("Ya hay un User con ese Phone");

                await _userRepo.Add(user);  
                return user;          
            }
            catch (Exception ex)
            {
                //registramos error en un log.
                //le mostramos error al usuario.
                throw new Exception($"Error, no se pudo insertar el User {ex}" );
            }


        }
    }
}
