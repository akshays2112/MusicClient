namespace WebApis.Net6.Authentication
{
    public interface ISpotifyAuthentication
    {
        Task GetSpotifyAccessToken();
        void GetSpotifyApiCode();
    }
}