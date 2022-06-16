using WebApis.Net6.Spotify.Models;

namespace WebApis.Net6.Spotify.WebApiEndpoints
{
    public interface IWApiEpisode
    {
        Task<EmptyResponse?> DeleteRemoveUsersSavedEpisodes(string[] ids, string? market = null, string? accessToken = null);
        Task<bool[]?> GetCheckUsersSavedEpisodes(string[] ids, string? accessToken = null);
        Task<Episode?> GetEpisode(string id, string? market = null, string? accessToken = null);
        Task<Episode[]?> GetSeveralEpisodes(string[] ids, string? market = null, string? accessToken = null);
        Task<Paged<Episode>?> GetUsersSavedEpisodes(string id, int limit = 20, int offset = 0, string? market = null, string? accessToken = null);
        Task<EmptyResponse?> PutSaveEpisodesForCurrentUser(string[] ids, string? accessToken = null);
    }
}