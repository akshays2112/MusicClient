using WebApis.Net7.Spotify.Models;
using WebApis.Net7.Spotify.Models.Responses;
using WebApis.Net7.Spotify.Models.Queries;

namespace WebApis.Net7.Spotify.WebApiEndpoints
{
    public interface IWApiPlaylist
    {
        Task<Playlist?> GetPlaylist(string id, WApiSpotifyGlobals.TrackOrEpisode[]? additional_types = null,
            string? fields = null, string? market = null, string? accessToken = null);
        Task<EmptyResponse?> PutChangePlaylistDetails(string id, string? name = null, bool @public = true,
            bool collaborative = false, string? description = null, string? accessToken = null);
        Task<Paged<RTrack>?> GetPlaylistTracks(string id, string? fields = null, int limit = 20, int offset = 0,
            string? market = null, string? accessToken = null);
        Task<Paged<REpisode>?> GetPlaylistEpisodes(string id, string? fields = null, int limit = 20, int offset = 0,
            string? market = null, string? accessToken = null);
        Task<Paged<T>?> GetPlaylistItems<T>(string id, WApiSpotifyGlobals.TrackOrEpisode[]? additional_types = null,
            string? fields = null, int limit = 20, int offset = 0, string? market = null, string? accessToken = null);
        Task<Paged<RTrack>?> GetNextPagePlaylistTracks(string nextPage, string? accessToken = null);
        Task<Paged<REpisode>?> GetNextPagePlaylistEpisodes(string nextPage, string? accessToken = null);
        Task<Paged<T>?> GetNextPagePlaylistItems<T>(string nextPage, string? accessToken = null);
        Task<RSnapshotId?> PostAddItemsToPlaylist(string playlist_id, string[]? uris, int position = 0, string? accessToken = null);
        Task<RSnapshotId?> PutUpdatePlaylistItems(string playlist_id, string[]? uris, int range_start = 0,
            int insert_before = 0, int range_length = 1, string? snapshot_id = null, string? accessToken = null);
        Task<RSnapshotId?> DeleteRemovePlaylistItems(string playlist_id, QTracks? uris,
            string? snapshot_id = null, string? accessToken = null);
        Task<Paged<Playlist>?> GetCurrentUsersPlaylists(int limit = 20, int offset = 0, string? accessToken = null);
        Task<Paged<Playlist>?> GetNextPageCurrentUsersPlaylists(string nextPage, string? accessToken = null);
        Task<Paged<Playlist>?> GetUsersPlaylists(string? user_id, int limit = 20, int offset = 0, string? accessToken = null);
        Task<Paged<Playlist>?> GetNextPageUsersPlaylists(string nextPage, string? accessToken = null);
        Task<Playlist?> PostCreatePlaylist(string? user_id, string? name, bool @public = true, bool collaborative = false,
            string? description = null, string? accessToken = null);
        Task<RPagedPlaylists?> GetFeaturedPlaylists(string? country, string? locale = null, int limit = 20,
            int offset = 0, DateTime? timestamp = null, string? accessToken = null);
        Task<Image[]?> GetPlaylistCoverImage(string? playlist_id, string? accessToken = null);
        Task<RPagedPlaylists?> GetNextPageFeaturedPlaylists(string nextPage, string? accessToken = null);
        Task<RPagedPlaylists?> GetCategorysPlaylists(string? category_id, string? country = null, int limit = 20,
            int offset = 0, string? accessToken = null);
        Task<EmptyResponse?> PutAddCustomPlaylistCoverImage(string? playlist_id, string? accessToken = null);
        Task<RPagedPlaylists?> GetNextPageCategorysPlaylists(string nextPage, string? accessToken = null);
    }
}