using System;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository UserRepo {get;}
        Task SaveChangeAsync();
    }
}
