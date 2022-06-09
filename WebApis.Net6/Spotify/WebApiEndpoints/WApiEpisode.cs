using WebApis.Net6.Spotify.Models;

namespace WebApis.Net6.Spotify.WebApiEndpoints;

public static class WApiEpisode
{
    ///<summary>
    ///Get Episode
    ///Get Spotify catalog information for a single episode identified by its unique Spotify ID.
    ///</summary>
    public static async Task<Episode?> GetEpisode(string id, string? market = null,
        string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<Episode>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/episodes/{id}",
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
    ///Get Several Episodes
    ///Get Spotify catalog information for several episodes based on their Spotify IDs.
    ///</summary>
    public static async Task<Episode[]?> GetSeveralEpisodes(string[] ids, string? market = null,
        string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<Episode[]>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/episodes",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids },
                new() { Name = "market", SimpleValue = market }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get User's Saved Episodes
    ///This API endpoint is in beta and could change without warning.Please share any feedback 
    ///that you have, or issues that you discover, in our developer community forum.
    ///</summary>
    public static async Task<Paged<Episode>?> GetUsersSavedEpisodes(string id, int limit = 20,
        int offset = 0, string? market = null, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<Paged<Episode>>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me/episodes",
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
    ///Save Episodes for Current User
    ///Save one or more episodes to current Spotify user's library.
    ///</summary>
    public static async Task<EmptyResponse?> PutSaveEpisodesForCurrentUser(string[] ids,
        string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Put,
            EndPointUrl = "/me/episodes",
            BodyObject = new { ids = ids },
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Remove User's Saved Episodes
    ///Delete one or more episodes from current Spotify user's library.
    ///</summary>
    public static async Task<EmptyResponse?> DeleteRemoveUsersSavedEpisodes(string[] ids,
        string? market = null, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Delete,
            EndPointUrl = "/me/episodes",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "market", SimpleValue = market }
            },
            BodyObject = new { ids = ids }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Check User's Saved Episodes
    ///Check if one or more episodes is already saved in the current Spotify user's library.
    ///</summary>
    public static async Task<bool[]?> GetCheckUsersSavedEpisodes(string[] ids, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<bool[]>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me/episodes/contains",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);
}
