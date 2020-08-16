namespace SocialMedia.Core.Interfaces
{
    //generic interface
    public  interface IBaseRepository<T> where T: class
    {       
       void Add(T entity);
    }


}
