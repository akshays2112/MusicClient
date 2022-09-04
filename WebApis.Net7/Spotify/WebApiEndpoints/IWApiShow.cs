using WebApis.Net7.Spotify.Models;
using WebApis.Net7.Spotify.Models.Responses;

namespace WebApis.Net7.Spotify.WebApiEndpoints
{
    public interface IWApiShow
    {
        Task<EmptyResponse?> DeleteRemoveUsersSavedShows(string[] ids, string? market = null, string? accessToken = null);
        Task<bool[]?> GetCheckUsersSavedShows(string[] ids, string? accessToken = null);
        Task<RShows?> GetSeveralShows(string[] ids, string? market = null, string? accessToken = null);
        Task<Show?> GetShow(string id, string? market = null, string? accessToken = null);
        Task<Paged<Episode>?> GetShowEpisodes(string id, int limit = 20, int offset = 0, string? market = null, string? accessToken = null);
        Task<Paged<RShow>?> GetUsersSavedShows(int limit = 20, int offset = 0, string? accessToken = null);
        Task<EmptyResponse?> PutSaveShowsForCurrentUser(string[] ids, string? accessToken = null);
        Task<Paged<Episode>?> GetNextPageShowEpisodes(string nextPage, string? accessToken = null);
        Task<Paged<RShow>?> GetNextPageUsersSavedShows(string nextPage, string? accessToken = null);
    }
}