using WebApis.Net7.Spotify.Models;
using WebApis.Net7.Spotify.Models.Responses;

namespace WebApis.Net7.Spotify.WebApiEndpoints;

public class WApiUserProfile : IWApiUserProfile
{
    private readonly IWApiGlobals _wApiGlobals;
    private readonly IWApiSpotifyGlobals _wApiSpotifyGlobals;

    public WApiUserProfile(IWApiGlobals wApiGlobals, IWApiSpotifyGlobals wApiSpotifyGlobals)
    {
        _wApiGlobals = wApiGlobals;
        _wApiSpotifyGlobals = wApiSpotifyGlobals;
    }

    ///<summary>
    ///Get Current User's Profile
    ///Get detailed profile information about the current user (including the current user's username).
    ///</summary>
    public async Task<UserProfile?> GetCurrentUsersProfile(string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<UserProfile>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me"
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    public async Task<Paged<Artist>?> GetUsersTopArtists(int limit = 20, int offset = 0,
        WApiSpotifyGlobals.TimeRanges? time_range = WApiSpotifyGlobals.TimeRanges.medium_term, string? accessToken = null)
        => await GetUsersTopItems<Paged<Artist>>(WApiSpotifyGlobals.ArtistsOrTracks.artists, limit, offset, time_range, accessToken);

    public async Task<Paged<Artist>?> GetNextPageUsersTopArtists(string nextPage, string? accessToken = null)
        => await GetNextPageUsersTopItems<Artist>(nextPage, accessToken);

    public async Task<Paged<Track>?> GetUsersTopTracks(int limit = 20, int offset = 0,
        WApiSpotifyGlobals.TimeRanges? time_range = WApiSpotifyGlobals.TimeRanges.medium_term, string? accessToken = null)
        => await GetUsersTopItems<Paged<Track>>(WApiSpotifyGlobals.ArtistsOrTracks.tracks, limit, offset, time_range, accessToken);

    public async Task<Paged<Track>?> GetNextPageUsersTopTracks(string nextPage, string? accessToken = null)
        => await GetNextPageUsersTopItems<Track>(nextPage, accessToken);

    ///<summary>
    ///Get User's Top Items
    ///Get the current user's top artists or tracks based on calculated affinity.
    ///</summary>
    public async Task<T?> GetUsersTopItems<T>(WApiSpotifyGlobals.ArtistsOrTracks type, int limit = 20, int offset = 0,
        WApiSpotifyGlobals.TimeRanges? time_range = WApiSpotifyGlobals.TimeRanges.medium_term, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<T>(new()
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
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    public async Task<Paged<T>?> GetNextPageUsersTopItems<T>(string nextPage, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Paged<T>>(new()
        {
            HttpMethod = HttpMethod.Get,
            PrecalculatedQueryString = nextPage
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get User's Profile
    ///Get public profile information about a Spotify user.
    ///</summary>
    public async Task<UserProfile?> GetUsersProfile(string user_id, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<UserProfile>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/users/{user_id}",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{user_id}", SimpleValue = user_id }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Follow Playlist
    ///Add the current user as a follower of a playlist.
    ///</summary>
    public async Task<EmptyResponse?> PutFollowPlaylist(string playlist_id,
        bool @public = true, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Put,
            EndPointUrl = "/playlists/{playlist_id}/followers",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{playlist_id}", SimpleValue = playlist_id }
            },
            BodyObject = new { @public }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Unfollow Playlist
    ///Add the current user as a follower of a playlist.
    ///</summary>
    public async Task<EmptyResponse?> DeleteUnfollowPlaylist(string playlist_id,
        string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Delete,
            EndPointUrl = "/playlists/{playlist_id}/followers",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{playlist_id}", SimpleValue = playlist_id }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Followed Artists
    ///Get the current user's followed artists.
    ///</summary>
    public async Task<RPagedArtists?> GetFollowedArtists(string? after, int limit = 20, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<RPagedArtists>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me/following",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "type", SimpleValue = "artist" },
                new() { Name = "after", SimpleValue = after },
                new() { Name = "limit", SimpleValue = limit, Constraints = new Constraint[]
                    { new() { Value = 1, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 50, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    public async Task<RPagedArtists?> GetNextPageFollowedArtists(string nextPage, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<RPagedArtists>(new()
        {
            HttpMethod = HttpMethod.Get,
            PrecalculatedQueryString = nextPage
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    public async Task<EmptyResponse?> PutFollowArtists(string[] ids, string? accessToken = null)
        => await PutFollowArtistsOrUsers(WApiSpotifyGlobals.ArtistOrUser.artist, ids, accessToken);

    public async Task<EmptyResponse?> PutFollowUsers(string[] ids, string? accessToken = null)
        => await PutFollowArtistsOrUsers(WApiSpotifyGlobals.ArtistOrUser.user, ids, accessToken);

    ///<summary>
    ///Follow Artists or Users
    ///Add the current user as a follower of one or more artists or other Spotify users.
    ///</summary>
    public async Task<EmptyResponse?> PutFollowArtistsOrUsers(WApiSpotifyGlobals.ArtistOrUser type,
        string[] ids, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Put,
            EndPointUrl = "/me/following",
            QuerySimpleParameters = new SimpleParameter[] { new() { Name = "type", SimpleValue = type.ToString() } },
            BodyObject = new { ids }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    public async Task<EmptyResponse?> DeleteUnfollowArtists(string[] ids, string? accessToken = null)
        => await DeleteUnfollowArtistsOrUsers(WApiSpotifyGlobals.ArtistOrUser.artist, ids, accessToken);

    public async Task<EmptyResponse?> DeleteUnfollowUsers(string[] ids, string? accessToken = null)
        => await DeleteUnfollowArtistsOrUsers(WApiSpotifyGlobals.ArtistOrUser.user, ids, accessToken);

    ///<summary>
    ///Follow Artists or Users
    ///Add the current user as a follower of one or more artists or other Spotify users.
    ///</summary>
    public async Task<EmptyResponse?> DeleteUnfollowArtistsOrUsers(WApiSpotifyGlobals.ArtistOrUser type,
        string[] ids, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Delete,
            EndPointUrl = "/me/following",
            QuerySimpleParameters = new SimpleParameter[] { new() { Name = "type", SimpleValue = type.ToString() } },
            BodyObject = new { ids }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    public async Task<bool[]?> GetCheckIfUserFollowsArtists(string[] ids, string? accessToken = null)
        => await GetCheckIfUserFollowsArtistsOrUsers(ids, WApiSpotifyGlobals.ArtistOrUser.artist, accessToken);

    public async Task<bool[]?> GetCheckIfUserFollowsUsers(string[] ids, string? accessToken = null)
        => await GetCheckIfUserFollowsArtistsOrUsers(ids, WApiSpotifyGlobals.ArtistOrUser.user, accessToken);

    ///<summary>
    ///Check If User Follows Artists or Users
    ///Get the current user's followed artists.
    ///</summary>
    public async Task<bool[]?> GetCheckIfUserFollowsArtistsOrUsers(string[] ids,
        WApiSpotifyGlobals.ArtistOrUser artistOrUser, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<bool[]>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me/following/contains",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids },
                new() { Name = "type", SimpleValue = artistOrUser.ToString() }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Check if Users Follow Playlist
    ///Get the current user's followed artists.
    ///</summary>
    public async Task<bool[]?> GetCheckIfUsersFollowPlaylist(string playlist_id,
        string[] ids, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<bool[]>(new()
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
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);
}
