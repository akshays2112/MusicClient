using WApiGlobals = WebApis.Net6.Globals;
using static WebApis.Net6.Spotify.Globals;
using WebApis.Net6.Spotify.Models;

namespace WebApis.Net6.Spotify.WebApiEndpoints
{
    public static class WApiUserProfile
    {
        ///<summary>
        ///Get Current User's Profile
        ///Get detailed profile information about the current user (including the current user's username).
        ///</summary>
        public static async Task<UserProfile?> GetCurrentUsersProfile()
            => await WApiGlobals.CallWebApiEndpoint<UserProfile>(new()
            {
                HttpMethod = HttpMethod.Get,
                EndPointUrl = "/me"
            }, Globals.SpotifyAccessToken?.AccessToken);

        public static async Task<Paged<Artist>?> GetUsersTopArtists(int limit = 20, int offset = 0,
            TimeRanges? time_range = TimeRanges.medium_term)
            => await GetUsersTopItems<Paged<Artist>>(ArtistsOrTracks.artists, limit, offset, time_range);

        public static async Task<Paged<Track>?> GetUsersTopTracks(int limit = 20, int offset = 0,
            TimeRanges? time_range = TimeRanges.medium_term)
            => await GetUsersTopItems<Paged<Track>>(ArtistsOrTracks.tracks, limit, offset, time_range);

        ///<summary>
        ///Get User's Top Items
        ///Get the current user's top artists or tracks based on calculated affinity.
        ///</summary>
        public static async Task<T?> GetUsersTopItems<T>(ArtistsOrTracks type, int limit = 20, int offset = 0,
            TimeRanges? time_range = TimeRanges.medium_term)
            => await WApiGlobals.CallWebApiEndpoint<T>(new()
            {
                HttpMethod = HttpMethod.Get,
                EndPointUrl = "/me/top/{type}",
                EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
                {
                    new() { Placeholder = "{type}", SimpleValue = type.ToString() }
                },
                QueryParameters = new QueryParameter[]
                {
                    new() {
                        Name = "limit", SimpleValue = limit,
                        Constraints = new Constraint[] { new() { MinValue = 1, MaxValue = 50 } }
                    },
                    new() {
                        Name = "offset", SimpleValue = offset,
                        Constraints = new Constraint[] { new() { MinValue = 0, MaxValue = 5 } }
                    },
                    new() { Name = "time_range", SimpleValue = time_range.ToString() }
                }
            }, Globals.SpotifyAccessToken?.AccessToken);

        ///<summary>
        ///Get User's Profile
        ///Get public profile information about a Spotify user.
        ///</summary>
        public static async Task<UserProfile?> GetUsersProfile(string user_id)
            => await WApiGlobals.CallWebApiEndpoint<UserProfile>(new()
            {
                HttpMethod = HttpMethod.Get,
                EndPointUrl = "/users/{user_id}",
                EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
                {
                    new() { Placeholder = "{user_id}", SimpleValue = user_id }
                }
            }, Globals.SpotifyAccessToken?.AccessToken);

        ///<summary>
        ///Follow Playlist
        ///Add the current user as a follower of a playlist.
        ///</summary>
        public static async Task<EmptyResponse?> PutFollowPlaylist(string playlist_id, bool @public = true)
            => await WApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
            {
                HttpMethod = HttpMethod.Put,
                EndPointUrl = "/playlists/{playlist_id}/followers",
                EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
                {
                    new() { Placeholder = "{playlist_id}", SimpleValue = playlist_id }
                },
                BodyObject = new { @public }
            }, Globals.SpotifyAccessToken?.AccessToken);

        ///<summary>
        ///Unfollow Playlist
        ///Add the current user as a follower of a playlist.
        ///</summary>
        public static async Task<EmptyResponse?> DeleteUnfollowPlaylist(string playlist_id)
            => await WApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
            {
                HttpMethod = HttpMethod.Delete,
                EndPointUrl = "/playlists/{playlist_id}/followers",
                EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
                {
                    new() { Placeholder = "{playlist_id}", SimpleValue = playlist_id }
                }
            }, Globals.SpotifyAccessToken?.AccessToken);

        ///<summary>
        ///Get Followed Artists
        ///Get the current user's followed artists.
        ///</summary>
        public static async Task<Paged<Artist>?> GetFollowedArtists(string? after, int limit = 20, int offset = 0)
            => await WApiGlobals.CallWebApiEndpoint<Paged<Artist>>(new()
            {
                HttpMethod = HttpMethod.Get,
                EndPointUrl = "/me/following",
                QueryParameters = new QueryParameter[]
                {
                    new() { Name = "type", SimpleValue = "artist" },
                    new() { Name = "after", SimpleValue = after },
                    new() { Name = "limit", SimpleValue = limit, Constraints = new Constraint[] { new() { MinValue = 1, MaxValue = 50 } } },
                    new() { Name = "offset", SimpleValue = offset, Constraints = new Constraint[] { new() { MinValue = 0, MaxValue = 50 } } }
                }
            }, Globals.SpotifyAccessToken?.AccessToken);

        ///<summary>
        ///Follow Artists or Users
        ///Add the current user as a follower of one or more artists or other Spotify users.
        ///</summary>
        public static async Task<EmptyResponse?> PutFollowArtistsOrUsers(ArtistOrUser type, string[] ids)
            => await WApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
            {
                HttpMethod = HttpMethod.Put,
                EndPointUrl = "/me/following",
                QueryParameters = new QueryParameter[] { new() { Name = "type", SimpleValue = type.ToString() } },
                BodyObject = new { ids }
            }, Globals.SpotifyAccessToken?.AccessToken);

        ///<summary>
        ///Follow Artists or Users
        ///Add the current user as a follower of one or more artists or other Spotify users.
        ///</summary>
        public static async Task<EmptyResponse?> DeleteUnfollowArtistsOrUsers(ArtistOrUser type, string[] ids)
            => await WApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
            {
                HttpMethod = HttpMethod.Delete,
                EndPointUrl = "/me/following",
                QueryParameters = new QueryParameter[] { new() { Name = "type", SimpleValue = type.ToString() } },
                BodyObject = new { ids }
            }, Globals.SpotifyAccessToken?.AccessToken);

        ///<summary>
        ///Check If User Follows Artists or Users
        ///Get the current user's followed artists.
        ///</summary>
        public static async Task<bool[]?> GetCheckIfUserFollowsArtistsOrUsers(string[] ids, ArtistOrUser artistOrUser)
            => await WApiGlobals.CallWebApiEndpoint<bool[]>(new()
            {
                HttpMethod = HttpMethod.Get,
                EndPointUrl = "/me/following/contains",
                QueryParameters = new QueryParameter[]
                {
                    new() { Name = "ids", SimpleValue = ids },
                    new() { Name = "type", SimpleValue = artistOrUser.ToString() }
                }
            }, Globals.SpotifyAccessToken?.AccessToken);

        ///<summary>
        ///Check if Users Follow Playlist
        ///Get the current user's followed artists.
        ///</summary>
        public static async Task<bool[]?> GetCheckIfUsersFollowPlaylist(string playlist_id, string[] ids)
            => await WApiGlobals.CallWebApiEndpoint<bool[]>(new()
            {
                HttpMethod = HttpMethod.Get,
                EndPointUrl = "/playlists/{playlist_id}/followers/contains",
                EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
                {
                    new() { Placeholder = "{playlist_id}", SimpleValue = playlist_id }
                },
                QueryParameters = new QueryParameter[]
                {
                    new() { Name = "ids", SimpleValue = ids, Constraints = new Constraint[] { new() { MaxCount = 5 } } }
                }
            }, Globals.SpotifyAccessToken?.AccessToken);
    }
}
