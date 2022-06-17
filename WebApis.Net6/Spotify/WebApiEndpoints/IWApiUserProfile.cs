using WebApis.Net6.Spotify.Models;
using WebApis.Net6.Spotify.Models.Responses;

namespace WebApis.Net6.Spotify.WebApiEndpoints
{
    public interface IWApiUserProfile
    {
        Task<EmptyResponse?> DeleteUnfollowArtistsOrUsers(WApiSpotifyGlobals.ArtistOrUser type, string[] ids, string? accessToken = null);
        Task<EmptyResponse?> DeleteUnfollowPlaylist(string playlist_id, string? accessToken = null);
        Task<bool[]?> GetCheckIfUserFollowsArtistsOrUsers(string[] ids, WApiSpotifyGlobals.ArtistOrUser artistOrUser, string? accessToken = null);
        Task<bool[]?> GetCheckIfUsersFollowPlaylist(string playlist_id, string[] ids, string? accessToken = null);
        Task<UserProfile?> GetCurrentUsersProfile(string? accessToken = null);
        Task<RPagedArtists?> GetFollowedArtists(string? after, int limit = 20, string? accessToken = null);
        Task<UserProfile?> GetUsersProfile(string user_id, string? accessToken = null);
        Task<Paged<Artist>?> GetUsersTopArtists(int limit = 20, int offset = 0, WApiSpotifyGlobals.TimeRanges? time_range = WApiSpotifyGlobals.TimeRanges.medium_term, string? accessToken = null);
        Task<T?> GetUsersTopItems<T>(WApiSpotifyGlobals.ArtistsOrTracks type, int limit = 20, int offset = 0, WApiSpotifyGlobals.TimeRanges? time_range = WApiSpotifyGlobals.TimeRanges.medium_term, string? accessToken = null);
        Task<Paged<Track>?> GetUsersTopTracks(int limit = 20, int offset = 0, WApiSpotifyGlobals.TimeRanges? time_range = WApiSpotifyGlobals.TimeRanges.medium_term, string? accessToken = null);
        Task<EmptyResponse?> PutFollowArtistsOrUsers(WApiSpotifyGlobals.ArtistOrUser type, string[] ids, string? accessToken = null);
        Task<EmptyResponse?> PutFollowPlaylist(string playlist_id, bool @public = true, string? accessToken = null);
        Task<Paged<Artist>?> GetNextPageUsersTopArtists(string nextPage, string? accessToken = null);
        Task<Paged<Track>?> GetNextPageUsersTopTracks(string nextPage, string? accessToken = null);
        Task<Paged<T>?> GetNextPageUsersTopItems<T>(string nextPage, string? accessToken = null);
        Task<RPagedArtists?> GetNextPageFollowedArtists(string nextPage, string? accessToken = null);
        Task<EmptyResponse?> PutFollowArtists(string[] ids, string? accessToken = null);
        Task<EmptyResponse?> PutFollowUsers(string[] ids, string? accessToken = null);
        Task<bool[]?> GetCheckIfUserFollowsArtists(string[] ids, string? accessToken = null);
        Task<bool[]?> GetCheckIfUserFollowsUsers(string[] ids, string? accessToken = null);
        Task<EmptyResponse?> DeleteUnfollowArtists(string[] ids, string? accessToken = null);
        Task<EmptyResponse?> DeleteUnfollowUsers(string[] ids, string? accessToken = null);
    }
}