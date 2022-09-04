namespace WebApis.Net7.Authentication
{
    public interface ISpotifyAuthentication
    {
        Task GetSpotifyAccessToken();
        void GetSpotifyApiCode();
    }
}