using WebApis.Net6.Spotify.Models;

namespace WebApis.Net6.Spotify.WebApiEndpoints
{
    public interface IWApiPlaylist
    {
        Task<Paged<Playlist>?> GetCurrentUsersPlaylists(int limit = 20, int offset = 0, string? accessToken = null);
    }
}