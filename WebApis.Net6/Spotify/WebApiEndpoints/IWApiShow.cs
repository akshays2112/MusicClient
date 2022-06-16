using WebApis.Net6.Spotify.Models;

namespace WebApis.Net6.Spotify.WebApiEndpoints
{
    public interface IWApiShow
    {
        Task<EmptyResponse?> DeleteRemoveUsersSavedShows(string[] ids, string? market = null, string? accessToken = null);
        Task<bool[]?> GetCheckUsersSavedShows(string[] ids, string? accessToken = null);
        Task<Show[]?> GetSeveralShows(string[] ids, string? market = null, string? accessToken = null);
        Task<Show?> GetShow(string id, string? market = null, string? accessToken = null);
        Task<Paged<Episode>?> GetShowEpisodes(string id, int limit = 20, int offset = 0, string? market = null, string? accessToken = null);
        Task<Paged<Show>?> GetUsersSavedShows(string id, int limit = 20, int offset = 0, string? market = null, string? accessToken = null);
        Task<EmptyResponse?> PutSaveShowsForCurrentUser(string[] ids, string? accessToken = null);
    }
}