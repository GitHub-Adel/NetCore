namespace SocialMedia.Api.Interfaces
{
    public interface IAppsettingService
    {
        string SocialMediaConnection { get;}
        int ItemByPage { get;}
        int CurrentPage { get;}
        byte[] SecretKey { get;}
        string Issuer { get;}
        string Audience { get;}
        double TokenMinuteExpires { get;}
    }
}
