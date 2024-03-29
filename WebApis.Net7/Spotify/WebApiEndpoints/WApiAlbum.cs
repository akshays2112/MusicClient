﻿using WebApis.Net7.Spotify.Models;
using WebApis.Net7.Spotify.Models.Responses;

namespace WebApis.Net7.Spotify.WebApiEndpoints;

public class WApiAlbum : IWApiAlbum
{
    private readonly IWApiGlobals _wApiGlobals;
    private readonly IWApiSpotifyGlobals _wApiSpotifyGlobals;

    public WApiAlbum(IWApiGlobals wApiGlobals, IWApiSpotifyGlobals wApiSpotifyGlobals)
    {
        _wApiGlobals = wApiGlobals;
        _wApiSpotifyGlobals = wApiSpotifyGlobals;
    }

    ///<summary>
    ///Get Album
    ///Get Spotify catalog information for a single album.
    ///</summary>
    public async Task<Album?> GetAlbum(string id, string? market = null,
        string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint(new WebApiEndpoint<Album?>()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/albums/{id}",
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
    ///Get Several Albums
    ///Get Spotify catalog information for multiple albums identified by their Spotify IDs.
    ///</summary>
    public async Task<RAlbums?> GetSeveralAlbums(string[] ids, string? market = null,
        string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint(new WebApiEndpoint<RAlbums?>()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/albums",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids },
                new() { Name = "market", SimpleValue = market }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Album Tracks
    ///Get Spotify catalog information about an album’s tracks. Optional parameters can be used to limit the number of tracks returned.
    ///</summary>
    public async Task<Paged<Track>?> GetAlbumTracks(string id, int limit = 20,
        int offset = 0, string? market = null, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Paged<Track>>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/albums/{id}/tracks",
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
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    public async Task<Paged<Track>?> GetNextPageAlbumTracks(string nextPage, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Paged<Track>>(new()
        {
            HttpMethod = HttpMethod.Get,
            PrecalculatedQueryString = nextPage
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Saved Albums
    ///Get a list of the albums saved in the current Spotify user's 'Your Music' library.
    ///</summary>
    public async Task<Paged<RAlbum>?> GetSavedAlbums(int limit = 20, int offset = 0,
        string? market = null, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Paged<RAlbum>>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me/albums",
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
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    public async Task<Paged<RAlbum>?> GetNextPageSavedAlbums(string nextPage, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Paged<RAlbum>>(new()
        {
            HttpMethod = HttpMethod.Get,
            PrecalculatedQueryString = nextPage
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Save Albums
    ///Save one or more albums to the current user's 'Your Music' library.
    ///</summary>
    public async Task<EmptyResponse?> PutSaveAlbums(string[] ids, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Put,
            EndPointUrl = "/me/albums",
            BodyObject = new { ids }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Remove Albums
    ///Remove one or more albums from the current user's 'Your Music' library.
    ///</summary>
    public async Task<EmptyResponse?> DeleteRemoveAlbums(string[] ids, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Delete,
            EndPointUrl = "/me/albums",
            BodyObject = new { ids }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Check Saved Albums
    ///Check if one or more albums is already saved in the current Spotify user's 'Your Music' library.
    ///</summary>
    public async Task<bool[]?> GetCheckSavedAlbums(string[] ids, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<bool[]>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me/albums/contains",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get New Releases
    ///Get a list of new album releases featured in Spotify (shown, for example, on a Spotify player’s “Browse” tab).
    ///</summary>
    public async Task<RPagedAlbums?> GetNewReleases(string? country, int limit = 20,
        int offset = 0, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<RPagedAlbums>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/browse/new-releases",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "limit", SimpleValue = limit, Constraints = new Constraint[]
                    { new() { Value = 1, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 50, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "offset", SimpleValue = offset, Constraints = new Constraint[]
                    { new() { Value = 0, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 5, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "country", SimpleValue = country }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    public async Task<RPagedAlbums?> GetNextPageNewReleases(string nextPage, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<RPagedAlbums>(new()
        {
            HttpMethod = HttpMethod.Get,
            PrecalculatedQueryString = nextPage
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);
}
