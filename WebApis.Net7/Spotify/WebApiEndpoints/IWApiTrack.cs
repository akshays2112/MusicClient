using WebApis.Net7.Spotify.Models;
using WebApis.Net7.Spotify.Models.Responses;

namespace WebApis.Net7.Spotify.WebApiEndpoints
{
    public interface IWApiTrack
    {
        Task<EmptyResponse?> DeleteRemoveUsersSavedTracks(string[] ids, string? accessToken = null);
        Task<bool[]?> GetCheckUsersSavedTracks(string[] ids, string? accessToken = null);
        Task<Track?> GetTrack(string id, string? market = null, string? accessToken = null);
        Task<RTracks?> GetSeveralTracks(string[] ids, string? market = null, string? accessToken = null);
        Task<AudioAnalysis?> GetTracksAudioAnalysis(string id, string? accessToken = null);
        Task<RAudioFeatures?> GetTracksAudioFeatures(string[] ids, string? accessToken = null);
        Task<Paged<RTrack>?> GetUsersSavedTracks(int? limit = 20, int? offset = 0, string? market = null, string? accessToken = null);
        Task<EmptyResponse?> PutSaveTracksForCurrentUser(string[] ids, string? accessToken = null);
        Task<Paged<RTrack>?> GetNextPageUsersSavedTracks(string nextPage, string? accessToken = null);
        Task<AudioFeature?> GetTracksAudioFeatures(string id, string? accessToken = null);
        Task<Recommendation?> GetRecommendations(object? obj, int? limit = 20, string? market = null, string? accessToken = null);
    }
}