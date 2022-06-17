using WebApis.Net6.Spotify.Models;
using WebApis.Net6.Spotify.Models.Responses;

namespace WebApis.Net6.Spotify.WebApiEndpoints
{
    public interface IWApiEpisode
    {
        Task<EmptyResponse?> DeleteRemoveUsersSavedEpisodes(string[] ids, string? accessToken = null);
        Task<bool[]?> GetCheckUsersSavedEpisodes(string[] ids, string? accessToken = null);
        Task<Episode?> GetEpisode(string id, string? market = null, string? accessToken = null);
        Task<REpisodes?> GetSeveralEpisodes(string[] ids, string? market = null, string? accessToken = null);
        Task<Paged<REpisode>?> GetUsersSavedEpisodes(int limit = 20, int offset = 0, string? market = null, string? accessToken = null);
        Task<EmptyResponse?> PutSaveEpisodesForUser(string[] ids, string? accessToken = null);
        Task<Paged<REpisode>?> GetNextPageUsersSavedEpisodes(string nextPage, string? accessToken = null);
    }
}