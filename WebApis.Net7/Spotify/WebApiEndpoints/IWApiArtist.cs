using WebApis.Net7.Spotify.Models;
using WebApis.Net7.Spotify.Models.Responses;

namespace WebApis.Net7.Spotify.WebApiEndpoints
{
    public interface IWApiArtist
    {
        Task<Artist?> GetArtist(string id, string? accessToken = null);
        Task<Paged<Album>?> GetArtistsAlbums(string id, WApiSpotifyGlobals.IncludeGroups[] include_groups, int limit = 20, int offset = 0, string? market = null, string? accessToken = null);
        Task<RArtists?> GetArtistsRelatedArtists(string id, string? accessToken = null);
        Task<RTracks?> GetArtistsTopTracks(string id, string? market, string? accessToken = null);
        Task<RArtists?> GetSeveralArtists(string[] ids, string? accessToken = null);
        Task<Paged<Album>?> GetNextPageArtistsAlbums(string nextPage, string? accessToken = null);
    }
}