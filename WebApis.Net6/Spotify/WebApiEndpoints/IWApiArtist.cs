using WebApis.Net6.Spotify.Models;

namespace WebApis.Net6.Spotify.WebApiEndpoints
{
    public interface IWApiArtist
    {
        Task<Artist?> GetArtist(string id, string? market = null, string? accessToken = null);
        Task<Paged<Album>?> GetArtistsAlbums(string id, WApiSpotifyGlobals.IncludeGroups[] include_groups, int limit = 20, int offset = 0, string? market = null, string? accessToken = null);
        Task<Artist[]?> GetArtistsRelatedArtists(string id, string? accessToken = null);
        Task<Track[]?> GetArtistsTopTracks(string id, string? market = null, string? accessToken = null);
        Task<Artist[]?> GetSeveralArtists(string[] ids, string? accessToken = null);
    }
}