using System;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository UserRepo { get;}
        void SaveChange();
        Task SaveChangeAsync();
    }
}
