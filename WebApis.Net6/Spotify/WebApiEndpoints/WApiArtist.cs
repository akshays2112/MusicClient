using WebApis.Net6.Spotify.Models;
using WebApis.Net6.Spotify.Models.Responses;

namespace WebApis.Net6.Spotify.WebApiEndpoints;

public class WApiArtist : IWApiArtist
{
    private readonly IWApiGlobals _wApiGlobals;
    private readonly IWApiSpotifyGlobals _wApiSpotifyGlobals;

    public WApiArtist(IWApiGlobals wApiGlobals, IWApiSpotifyGlobals wApiSpotifyGlobals)
    {
        _wApiGlobals = wApiGlobals;
        _wApiSpotifyGlobals = wApiSpotifyGlobals;
    }

    ///<summary>
    ///Get Artist
    ///Get Spotify catalog information for a single artist identified by their unique Spotify ID.
    ///</summary>
    public async Task<Artist?> GetArtist(string id, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Artist>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/artists/{id}",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{id}", SimpleValue = id }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Several Artists
    ///Get Spotify catalog information for several artists based on their Spotify IDs.
    ///</summary>
    public async Task<RArtists?> GetSeveralArtists(string[] ids, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<RArtists>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/artists",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Artist's Albums
    ///Get Spotify catalog information about an artist's albums.
    ///</summary>
    public async Task<Paged<Album>?> GetArtistsAlbums(string id,
        WApiSpotifyGlobals.IncludeGroups[] include_groups, int limit = 20,
        int offset = 0, string? market = null, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Paged<Album>>(new()
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
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    public async Task<Paged<Album>?> GetNextPageArtistsAlbums(string nextPage, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Paged<Album>>(new()
        {
            HttpMethod = HttpMethod.Get,
            PrecalculatedQueryString = nextPage
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Artist's Top Tracks
    ///Get Spotify catalog information about an artist's top tracks by country.
    ///</summary>
    public async Task<RTracks?> GetArtistsTopTracks(string id,
        string? market, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<RTracks>(new()
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
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Artist's Related Artists
    ///Get Spotify catalog information about artists similar to a given artist. 
    ///Similarity is based on analysis of the Spotify community's listening history.
    ///</summary>
    public async Task<RArtists?> GetArtistsRelatedArtists(string id,
        string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<RArtists>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/artists/{id}/related-artists",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
                new() { Placeholder = "{id}", SimpleValue = id }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);
}
