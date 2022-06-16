using WebApis.Net6.Spotify.Models;
using WebApis.Net6.Spotify.Models.Responses;

namespace WebApis.Net6.Spotify.WebApiEndpoints
{
    public interface IWApiArtist
    {
        Task<Artist?> GetArtist(string id, string? accessToken = null);
        Task<Paged<Album>?> GetArtistsAlbums(string id, WApiSpotifyGlobals.IncludeGroups[] include_groups, int limit = 20, int offset = 0, string? market = null, string? accessToken = null);
        Task<Artist[]?> GetArtistsRelatedArtists(string id, string? accessToken = null);
        Task<Track[]?> GetArtistsTopTracks(string id, string? market = null, string? accessToken = null);
        Task<RArtists?> GetSeveralArtists(string[] ids, string? accessToken = null);
        Task<Paged<Album>?> GetNextPageArtistsAlbums(string nextPage, string? accessToken = null);
    }
}