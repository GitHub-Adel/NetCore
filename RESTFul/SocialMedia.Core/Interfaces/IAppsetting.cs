namespace SocialMedia.Core.Interfaces
{
    public interface IAppsetting
    {
        string SocialMediaConnection { get;}
        int ItemByPage { get;}
        int CurrentPage { get;}
    }
}
