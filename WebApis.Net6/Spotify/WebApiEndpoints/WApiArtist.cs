using WApiGlobals = WebApis.Net6.Globals;
using WApiSpotifyGlobals = WebApis.Net6.Spotify.Globals;
using WebApis.Net6.Spotify.Models;

namespace WebApis.Net6.Spotify.WebApiEndpoints;

public class WApiArtist
{
    ///<summary>
    ///Get Artist
    ///Get Spotify catalog information for a single artist identified by their unique Spotify ID.
    ///</summary>
    public static async Task<Artist?> GetArtist(string id, string? market = null,
        string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<Artist>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/artists/{id}",
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
    ///Get Several Artists
    ///Get Spotify catalog information for several artists based on their Spotify IDs.
    ///</summary>
    public static async Task<Artist[]?> GetSeveralArtists(string[] ids, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<Artist[]>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/artists",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Artist's Albums
    ///Get Spotify catalog information about an artist's albums.
    ///</summary>
    public static async Task<Paged<Album>?> GetArtistsAlbums(string id,
        WApiSpotifyGlobals.IncludeGroups[] include_groups, int limit = 20,
        int offset = 0, string? market = null, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<Paged<Album>>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/artists/{id}/albums",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{id}", SimpleValue = id }
            },
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "include_groups", SimpleValue = include_groups },
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
    ///Get Artist's Top Tracks
    ///Get Spotify catalog information about an artist's top tracks by country.
    ///</summary>
    public static async Task<Track[]?> GetArtistsTopTracks(string id, 
        string? market = null, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<Track[]>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/artists/{id}/top-tracks",
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
    ///Get Artist's Related Artists
    ///Get Spotify catalog information about artists similar to a given artist. 
    ///Similarity is based on analysis of the Spotify community's listening history.
    ///</summary>
    public static async Task<Artist[]?> GetArtistsRelatedArtists(string id,
        string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<Artist[]>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/artists/{id}/related-artists",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{id}", SimpleValue = id }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);
}
