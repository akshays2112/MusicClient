using WebApis.Net6.Spotify.Models;
using WebApis.Net6.Spotify.Models.Responses;
using WebApis.Net6.Spotify.Models.Queries;

namespace WebApis.Net6.Spotify.WebApiEndpoints;

public class WApiPlaylist : IWApiPlaylist
{
    private readonly IWApiGlobals _wApiGlobals;
    private readonly IWApiSpotifyGlobals _wApiSpotifyGlobals;

    public WApiPlaylist(IWApiGlobals wApiGlobals, IWApiSpotifyGlobals wApiSpotifyGlobals)
    {
        _wApiGlobals = wApiGlobals;
        _wApiSpotifyGlobals = wApiSpotifyGlobals;
    }

    ///<summary>
    ///Get Playlist
    ///Get a playlist owned by a Spotify user.
    ///</summary>
    public async Task<Playlist?> GetPlaylist(string id, WApiSpotifyGlobals.TrackOrEpisode[]? additional_types = null,
        string? fields = null, string? market = null, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Playlist>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/playlists/{playlist_id}",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{playlist_id}", SimpleValue = id }
            },
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "additional_types", SimpleValue = additional_types },
                new() { Name = "fields", SimpleValue = fields },
                new() { Name = "market", SimpleValue = market }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Change Playlist Details
    ///Change a playlist's name and public/private state. (The user must, of course, own the playlist.)
    ///</summary>
    public async Task<EmptyResponse?> PutChangePlaylistDetails(string id, string? name = null, bool @public = true,
        bool collaborative = false, string? description = null, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Put,
            EndPointUrl = "/playlists/{playlist_id}",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{playlist_id}", SimpleValue = id }
            },
            BodyObject = new { name, @public, collaborative, description }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    public async Task<Paged<RTrack>?> GetPlaylistTracks(string id, string? fields = null, int limit = 20, int offset = 0,
        string? market = null, string? accessToken = null)
        => await GetPlaylistItems<RTrack>(id, new WApiSpotifyGlobals.TrackOrEpisode[] { WApiSpotifyGlobals.TrackOrEpisode.track },
            fields, limit, offset, accessToken);

    public async Task<Paged<REpisode>?> GetPlaylistEpisodes(string id, string? fields = null, int limit = 20, int offset = 0,
        string? market = null, string? accessToken = null)
        => await GetPlaylistItems<REpisode>(id, new WApiSpotifyGlobals.TrackOrEpisode[] { WApiSpotifyGlobals.TrackOrEpisode.episode },
            fields, limit, offset, accessToken);

    ///<summary>
    ///Get Playlist Items
    ///Get a playlist owned by a Spotify user.
    ///</summary>
    public async Task<Paged<T>?> GetPlaylistItems<T>(string id, WApiSpotifyGlobals.TrackOrEpisode[]? additional_types = null,
        string? fields = null, int limit = 20, int offset = 0, string? market = null, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Paged<T>>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/playlists/{playlist_id}/tracks",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{playlist_id}", SimpleValue = id }
            },
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "additional_types", SimpleValue = additional_types },
                new() { Name = "fields", SimpleValue = fields },
                new() { Name = "limit", SimpleValue = limit, Constraints = new Constraint[]
                    { new() { Value = 1, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 50, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "offset", SimpleValue = offset, Constraints = new Constraint[]
                    { new() { Value = 0, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 5, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "market", SimpleValue = market }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    public async Task<Paged<RTrack>?> GetNextPagePlaylistTracks(string nextPage, string? accessToken = null)
        => await GetNextPagePlaylistItems<RTrack>(nextPage, accessToken);

    public async Task<Paged<REpisode>?> GetNextPagePlaylistEpisodes(string nextPage, string? accessToken = null)
        => await GetNextPagePlaylistItems<REpisode>(nextPage, accessToken);

    public async Task<Paged<T>?> GetNextPagePlaylistItems<T>(string nextPage, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Paged<T>>(new()
        {
            HttpMethod = HttpMethod.Get,
            PrecalculatedQueryString = nextPage
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Add Items to Playlist
    ///Add one or more items to a user's playlist.
    ///</summary>
    public async Task<RSnapshotId?> PostAddItemsToPlaylist(string playlist_id, string[]? uris, int position = 0, 
        string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<RSnapshotId>(new()
        {
            HttpMethod = HttpMethod.Post,
            EndPointUrl = "/playlists/{playlist_id}/tracks",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{playlist_id}", SimpleValue = playlist_id }
            },
            BodyObject = new { uris, position }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Update Playlist Items
    ///Either reorder or replace items in a playlist depending on the request's parameters. To reorder 
    ///items, include range_start, insert_before, range_length and snapshot_id in the request's body. To 
    ///replace items, include uris as either a query parameter or in the request's body. Replacing items 
    ///in a playlist will overwrite its existing items. This operation can be used for replacing or 
    ///clearing items in a playlist.
    ///Note: Replace and reorder are mutually exclusive operations which share the same endpoint, but have 
    ///different parameters.These operations can't be applied together in a single request.
    ///</summary>
    public async Task<RSnapshotId?> PutUpdatePlaylistItems(string playlist_id, string[]? uris, int range_start = 0,
        int insert_before = 0, int range_length = 1, string? snapshot_id = null, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<RSnapshotId>(new()
        {
            HttpMethod = HttpMethod.Put,
            EndPointUrl = "/playlists/{playlist_id}/tracks",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{playlist_id}", SimpleValue = playlist_id }
            },
            BodyObject = new { uris, range_start, insert_before, range_length, snapshot_id }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Remove Playlist Items
    ///Remove one or more items from a user's playlist.
    ///</summary>
    public async Task<RSnapshotId?> DeleteRemovePlaylistItems(string playlist_id, QTracks? uris,
        string? snapshot_id = null, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<RSnapshotId>(new()
        {
            HttpMethod = HttpMethod.Delete,
            EndPointUrl = "/playlists/{playlist_id}/tracks",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{playlist_id}", SimpleValue = playlist_id }
            },
            BodyObject = new { uris, snapshot_id }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Current User's Playlists
    ///Get a list of the playlists owned or followed by the current Spotify user.
    ///</summary>
    public async Task<Paged<Playlist>?> GetCurrentUsersPlaylists(int limit = 20,
        int offset = 0, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Paged<Playlist>>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me/playlists",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "limit", SimpleValue = limit, Constraints = new Constraint[]
                    { new() { Value = 1, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 50, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "offset", SimpleValue = offset, Constraints = new Constraint[]
                    { new() { Value = 0, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 5, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    public async Task<Paged<Playlist>?> GetNextPageCurrentUsersPlaylists(string nextPage, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Paged<Playlist>>(new()
        {
            HttpMethod = HttpMethod.Get,
            PrecalculatedQueryString = nextPage
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get User's Playlists
    ///Get a list of the playlists owned or followed by a Spotify user.
    ///</summary>
    public async Task<Paged<Playlist>?> GetUsersPlaylists(string? user_id, int limit = 20,
        int offset = 0, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Paged<Playlist>>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/users/{user_id}/playlists",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{user_id}", SimpleValue = user_id }
            },
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "limit", SimpleValue = limit, Constraints = new Constraint[]
                    { new() { Value = 1, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 50, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "offset", SimpleValue = offset, Constraints = new Constraint[]
                    { new() { Value = 0, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 5, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    public async Task<Paged<Playlist>?> GetNextPageUsersPlaylists(string nextPage, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Paged<Playlist>>(new()
        {
            HttpMethod = HttpMethod.Get,
            PrecalculatedQueryString = nextPage
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Create Playlist
    ///Create a playlist for a Spotify user. (The playlist will be empty until you add tracks.)
    ///</summary>
    public async Task<Playlist?> PostCreatePlaylist(string? user_id, string? name, 
        bool @public = true, bool collaborative = false, string? description = null, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Playlist>(new()
        {
            HttpMethod = HttpMethod.Post,
            EndPointUrl = "/users/{user_id}/playlists",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{user_id}", SimpleValue = user_id }
            },
            BodyObject = new { name, @public, collaborative, description }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Featured Playlists
    ///Get a list of Spotify featured playlists (shown, for example, on a Spotify player's 'Browse' tab).
    ///</summary>
    public async Task<RPagedPlaylists?> GetFeaturedPlaylists(string? country, string? locale = null, int limit = 20,
        int offset = 0, DateTime? timestamp = null, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<RPagedPlaylists>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/browse/featured-playlists",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "country", SimpleValue = country },
                new() { Name = "locale", SimpleValue = locale },
                new() { Name = "timestamp", SimpleValue = timestamp },
                new() { Name = "limit", SimpleValue = limit, Constraints = new Constraint[]
                    { new() { Value = 1, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 50, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "offset", SimpleValue = offset, Constraints = new Constraint[]
                    { new() { Value = 0, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 5, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    public async Task<RPagedPlaylists?> GetNextPageFeaturedPlaylists(string nextPage, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<RPagedPlaylists>(new()
        {
            HttpMethod = HttpMethod.Get,
            PrecalculatedQueryString = nextPage
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Category's Playlists
    ///Get a list of Spotify playlists tagged with a particular category.
    ///</summary>
    public async Task<RPagedPlaylists?> GetCategorysPlaylists(string? category_id, string? country = null, int limit = 20,
        int offset = 0, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<RPagedPlaylists>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/browse/categories/{category_id}/playlists",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{category_id}", SimpleValue = category_id }
            },
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "country", SimpleValue = country },
                new() { Name = "limit", SimpleValue = limit, Constraints = new Constraint[]
                    { new() { Value = 1, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 50, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "offset", SimpleValue = offset, Constraints = new Constraint[]
                    { new() { Value = 0, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 5, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    public async Task<RPagedPlaylists?> GetNextPageCategorysPlaylists(string nextPage, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<RPagedPlaylists>(new()
        {
            HttpMethod = HttpMethod.Get,
            PrecalculatedQueryString = nextPage
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Playlist Cover Image
    ///Get the current image associated with a specific playlist.
    ///</summary>
    public async Task<Image[]?> GetPlaylistCoverImage(string? playlist_id, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Image[]>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/playlists/{playlist_id}/images",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{playlist_id}", SimpleValue = playlist_id }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Add Custom Playlist Cover Image
    ///Replace the image used to represent a specific playlist.
    ///</summary>
    public async Task<EmptyResponse?> PutAddCustomPlaylistCoverImage(string? playlist_id, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Put,
            EndPointUrl = "/playlists/{playlist_id}/images",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{playlist_id}", SimpleValue = playlist_id }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);
}
