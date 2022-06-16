namespace WebApis.Net6.Spotify
{
    public interface ISpotifyAuthentication
    {
        Task GetSpotifyAccessToken();
        void GetSpotifyApiCode();
    }
}