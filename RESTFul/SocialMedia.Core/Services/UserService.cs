using System;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Exceptions;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                //logica de negocio: no se puede insertar un usuario si ya existe.
                var _user = _unitOfWork.UserRepo.GetByPhone(user.Phone);
                if (_user != null) throw new CustomException("Ya hay un User con ese Phone");

                _unitOfWork.UserRepo.Add(user);
                await _unitOfWork.SaveChangeAsync();
                return user;
            }
            catch (Exception ex )
            {
                //registramos error en un log.
                //le mostramos error al usuario.
                if(ex.GetType()==typeof(CustomException))  
                    throw new CustomException($"{ex.Message}");
                else
                    throw new Exception($"{ex.Message}");
            }


        }
    }
}
