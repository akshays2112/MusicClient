using WebApis.Net6.Spotify.Models;
using WebApis.Net6.Spotify.Models.Responses;

namespace WebApis.Net6.Spotify.WebApiEndpoints
{
    public interface IWApiAlbum
    {
        Task<EmptyResponse?> DeleteRemoveAlbums(string[] ids, string? accessToken = null);
        Task<Album?> GetAlbum(string id, string? market = null, string? accessToken = null);
        Task<Paged<Track>?> GetAlbumTracks(string id, int limit = 20, int offset = 0, string? market = null, string? accessToken = null);
        Task<bool[]?> GetCheckSavedAlbums(string[] ids, string? accessToken = null);
        Task<RPagedAlbums?> GetNewReleases(string? country, int limit = 20, int offset = 0, string? accessToken = null);
        Task<Paged<Track>?> GetNextPageAlbumTracks(string nextPage, string? accessToken = null);
        Task<Paged<RAlbum>?> GetNextPageSavedAlbums(string nextPage, string? accessToken = null);
        Task<RPagedAlbums?> GetNextPageNewReleases(string nextPage, string? accessToken = null);
        Task<Paged<RAlbum>?> GetSavedAlbums(int limit = 20, int offset = 0, string? market = null, string? accessToken = null);
        Task<RAlbums?> GetSeveralAlbums(string[] ids, string? market = null, string? accessToken = null);
        Task<EmptyResponse?> PutSaveAlbums(string[] ids, string? accessToken = null);
    }
}