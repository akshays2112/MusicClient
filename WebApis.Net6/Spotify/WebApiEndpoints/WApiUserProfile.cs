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
        /// </summary>
        public static async Task<UserProfile?> GetCurrentUsersProfile()
            => await WApiGlobals.CallWebApiEndpoint<UserProfile>(new() 
            { 
                HttpMethod = HttpMethod.Get, 
                EndPointUrl = "/me" 
            }, AccessToken);

        ///<summary>
        ///Follow Artists or Users
        ///Add the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        public static async Task<EmptyResponse?> PutFollowArtistsOrUsers(ArtistOrUser type, string[] ids)
            => await WApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
            {
                HttpMethod = HttpMethod.Put,
                EndPointUrl = "/me/following",
                QueryParameters = new QueryParameter[] { new() { Name = "type", SimpleValue = type.ToString() } },
                BodyObject = new { ids }
            }, AccessToken);

        public static async Task<Paged<Artist>?> GetUsersTopArtists(int limit = 20, int offset = 0,
            TimeRanges? time_range = TimeRanges.medium_term)
            => await GetUsersTopItems<Paged<Artist>>(ArtistsOrTracks.artists, limit, offset, time_range);

        public static async Task<Paged<Track>?> GetUsersTopTracks(int limit = 20, int offset = 0,
            TimeRanges? time_range = TimeRanges.medium_term)
            => await GetUsersTopItems<Paged<Track>>(ArtistsOrTracks.tracks, limit, offset, time_range);

        ///<summary>
        ///Get User's Top Items
        ///Get the current user's top artists or tracks based on calculated affinity.
        /// </summary>
        public static async Task<T?> GetUsersTopItems<T>(ArtistsOrTracks type, int limit = 20, int offset = 0,
            TimeRanges? time_range = TimeRanges.medium_term)
            => await WApiGlobals.CallWebApiEndpoint<T>(new()
            {
                HttpMethod = HttpMethod.Put,
                EndPointUrl = "/me/top/{type}",
                EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
                {
                    new() { Placeholder = "{type}", SimpleValue = type.ToString() }
                },
                QueryParameters = new QueryParameter[]
                {
                    new() { Name = "limit", SimpleValue = limit },
                    new() { Name = "offset", SimpleValue = offset },
                    new() { Name = "time_range", SimpleValue = time_range.ToString() }
                }
            }, AccessToken);
    }
}
