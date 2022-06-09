using WebApis.Net6.Spotify.Models;

namespace WebApis.Net6.Spotify.WebApiEndpoints;

public static class WApiUserProfile
{
    ///<summary>
    ///Get Current User's Profile
    ///Get detailed profile information about the current user (including the current user's username).
    ///</summary>
    public static async Task<UserProfile?> GetCurrentUsersProfile(string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<UserProfile>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me"
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    public static async Task<Paged<Artist>?> GetUsersTopArtists(int limit = 20, int offset = 0,
        WApiSpotifyGlobals.TimeRanges? time_range = WApiSpotifyGlobals.TimeRanges.medium_term, string? accessToken = null)
        => await GetUsersTopItems<Paged<Artist>>(WApiSpotifyGlobals.ArtistsOrTracks.artists, limit, offset, time_range, accessToken);

    public static async Task<Paged<Track>?> GetUsersTopTracks(int limit = 20, int offset = 0,
        WApiSpotifyGlobals.TimeRanges? time_range = WApiSpotifyGlobals.TimeRanges.medium_term, string? accessToken = null)
        => await GetUsersTopItems<Paged<Track>>(WApiSpotifyGlobals.ArtistsOrTracks.tracks, limit, offset, time_range, accessToken);

    ///<summary>
    ///Get User's Top Items
    ///Get the current user's top artists or tracks based on calculated affinity.
    ///</summary>
    public static async Task<T?> GetUsersTopItems<T>(WApiSpotifyGlobals.ArtistsOrTracks type, int limit = 20, int offset = 0,
        WApiSpotifyGlobals.TimeRanges? time_range = WApiSpotifyGlobals.TimeRanges.medium_term, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<T>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me/top/{type}",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{type}", SimpleValue = type.ToString() }
            },
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "limit", SimpleValue = limit, Constraints = new Constraint[]
                    { new() { Value = 1, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 50, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "offset", SimpleValue = offset, Constraints = new Constraint[]
                    { new() { Value = 0, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 5, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "time_range", SimpleValue = time_range.ToString() }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get User's Profile
    ///Get public profile information about a Spotify user.
    ///</summary>
    public static async Task<UserProfile?> GetUsersProfile(string user_id, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<UserProfile>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/users/{user_id}",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{user_id}", SimpleValue = user_id }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Follow Playlist
    ///Add the current user as a follower of a playlist.
    ///</summary>
    public static async Task<EmptyResponse?> PutFollowPlaylist(string playlist_id,
        bool @public = true, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Put,
            EndPointUrl = "/playlists/{playlist_id}/followers",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{playlist_id}", SimpleValue = playlist_id }
            },
            BodyObject = new { @public }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Unfollow Playlist
    ///Add the current user as a follower of a playlist.
    ///</summary>
    public static async Task<EmptyResponse?> DeleteUnfollowPlaylist(string playlist_id,
        string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Delete,
            EndPointUrl = "/playlists/{playlist_id}/followers",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{playlist_id}", SimpleValue = playlist_id }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Followed Artists
    ///Get the current user's followed artists.
    ///</summary>
    public static async Task<Paged<Artist>?> GetFollowedArtists(string? after, int limit = 20,
        int offset = 0, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<Paged<Artist>>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me/following",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "type", SimpleValue = "artist" },
                new() { Name = "after", SimpleValue = after },
                new() { Name = "limit", SimpleValue = limit, Constraints = new Constraint[]
                    { new() { Value = 1, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 50, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "offset", SimpleValue = offset, Constraints = new Constraint[]
                    { new() { Value = 0, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 5, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Follow Artists or Users
    ///Add the current user as a follower of one or more artists or other Spotify users.
    ///</summary>
    public static async Task<EmptyResponse?> PutFollowArtistsOrUsers(WApiSpotifyGlobals.ArtistOrUser type,
        string[] ids, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Put,
            EndPointUrl = "/me/following",
            QuerySimpleParameters = new SimpleParameter[] { new() { Name = "type", SimpleValue = type.ToString() } },
            BodyObject = new { ids }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Follow Artists or Users
    ///Add the current user as a follower of one or more artists or other Spotify users.
    ///</summary>
    public static async Task<EmptyResponse?> DeleteUnfollowArtistsOrUsers(WApiSpotifyGlobals.ArtistOrUser type,
        string[] ids, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Delete,
            EndPointUrl = "/me/following",
            QuerySimpleParameters = new SimpleParameter[] { new() { Name = "type", SimpleValue = type.ToString() } },
            BodyObject = new { ids }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Check If User Follows Artists or Users
    ///Get the current user's followed artists.
    ///</summary>
    public static async Task<bool[]?> GetCheckIfUserFollowsArtistsOrUsers(string[] ids,
        WApiSpotifyGlobals.ArtistOrUser artistOrUser, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<bool[]>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me/following/contains",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids },
                new() { Name = "type", SimpleValue = artistOrUser.ToString() }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Check if Users Follow Playlist
    ///Get the current user's followed artists.
    ///</summary>
    public static async Task<bool[]?> GetCheckIfUsersFollowPlaylist(string playlist_id,
        string[] ids, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<bool[]>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/playlists/{playlist_id}/followers/contains",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{playlist_id}", SimpleValue = playlist_id }
            },
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() 
                {
                    Name = "ids", 
                    SimpleValue = ids, 
                    Constraints = new Constraint[] 
                    {
                        new() 
                        {
                            Value = 5, 
                            ConstraintComparison = 
                                ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) | 
                                ((int)WApiGlobals.ConstraintComparison.Length) 
                        }
                    } 
                }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);
}
