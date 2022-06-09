using WebApis.Net6.Spotify.Models;

namespace WebApis.Net6.Spotify.WebApiEndpoints;

public static class WApiShow
{
    ///<summary>
    ///Get Show
    ///Get Spotify catalog information for a single artist identified by their unique Spotify ID.
    ///</summary>
    public static async Task<Show?> GetShow(string id, string? market = null,
        string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<Show>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/shows/{id}",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
               new() { Placeholder = "{id}", SimpleValue = id }
            },
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "market", SimpleValue = market }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Several Shows
    ///Get Spotify catalog information for several shows based on their Spotify IDs.
    ///</summary>
    public static async Task<Show[]?> GetSeveralShows(string[] ids, string? market = null,
        string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<Show[]>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/shows",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids },
                new() { Name = "market", SimpleValue = market }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Show Episodes
    ///Get Spotify catalog information about an show’s episodes. Optional parameters 
    ///can be used to limit the number of episodes returned.
    ///</summary>
    public static async Task<Paged<Episode>?> GetShowEpisodes(string id, int limit = 20, 
        int offset = 0, string? market = null, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<Paged<Episode>>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/shows/{id}/episodes",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{id}", SimpleValue = id }
            },
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "limit", SimpleValue = limit, Constraints = new Constraint[]
                    { new() { Value = 1, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 50, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "offset", SimpleValue = offset, Constraints = new Constraint[]
                    { new() { Value = 0, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 5, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "market", SimpleValue = market }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get User's Saved Shows
    ///Get a list of shows saved in the current Spotify user's library. Optional 
    ///parameters can be used to limit the number of shows returned.
    ///</summary>
    public static async Task<Paged<Show>?> GetUsersSavedShows(string id, int limit = 20,
        int offset = 0, string? market = null, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<Paged<Show>>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me/shows",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "limit", SimpleValue = limit, Constraints = new Constraint[]
                    { new() { Value = 1, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 50, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "offset", SimpleValue = offset, Constraints = new Constraint[]
                    { new() { Value = 0, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 5, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "market", SimpleValue = market }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Save Shows for Current User
    ///Save one or more shows to current Spotify user's library.
    ///</summary>
    public static async Task<EmptyResponse?> PutSaveShowsForCurrentUser(string[] ids,
        string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Put,
            EndPointUrl = "/me/shows",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Remove User's Saved Shows
    ///Delete one or more shows from current Spotify user's library.
    ///</summary>
    public static async Task<EmptyResponse?> DeleteRemoveUsersSavedShows(string[] ids,
        string? market = null, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Delete,
            EndPointUrl = "/me/shows",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids },
                new() { Name = "market", SimpleValue = market }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Check User's Saved Shows
    ///Check if one or more shows is already saved in the current Spotify user's library.
    ///</summary>
    public static async Task<bool[]?> GetCheckUsersSavedShows(string[] ids, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<bool[]>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me/shows/contains",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);
}
