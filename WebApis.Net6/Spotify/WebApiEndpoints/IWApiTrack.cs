using WebApis.Net6.Spotify.Models;

namespace WebApis.Net6.Spotify.WebApiEndpoints
{
    public interface IWApiTrack
    {
        Task<EmptyResponse?> DeleteRemoveUsersSavedTracks(string[] ids, string? market = null, string? accessToken = null);
        Task<bool[]?> GetCheckUsersSavedTracks(string[] ids, string? accessToken = null);
        Task<Track?> GetEpisode(string id, string? market = null, string? accessToken = null);
        Task<Track[]?> GetSeveralEpisodes(string[] ids, string? market = null, string? accessToken = null);
        Task<AudioFeature?> GetTrackAudioFeatures(string id, string? accessToken = null);
        Task<AudioAnalysis?> GetTracksAudioAnalysis(string id, string? accessToken = null);
        Task<AudioFeature[]?> GetTracksAudioFeatures(string[] ids, string? accessToken = null);
        Task<Paged<Track>?> GetUsersSavedEpisodes(int? limit = 20, int? offset = 0, string? market = null, string? accessToken = null);
        Task<EmptyResponse?> PutSaveTracksForCurrentUser(string[] ids, string? accessToken = null);
    }
}