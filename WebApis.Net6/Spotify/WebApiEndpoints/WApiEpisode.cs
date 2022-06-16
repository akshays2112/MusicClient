﻿using WebApis.Net6.Spotify.Models;

namespace WebApis.Net6.Spotify.WebApiEndpoints;

public class WApiEpisode : IWApiEpisode
{
    private readonly WApiGlobals _wApiGlobals;
    private readonly WApiSpotifyGlobals _wApiSpotifyGlobals;

    public WApiEpisode(WApiGlobals wApiGlobals, WApiSpotifyGlobals wApiSpotifyGlobals)
    {
        _wApiGlobals = wApiGlobals;
        _wApiSpotifyGlobals = wApiSpotifyGlobals;
    }

    ///<summary>
    ///Get Episode
    ///Get Spotify catalog information for a single episode identified by its unique Spotify ID.
    ///</summary>
    public async Task<Episode?> GetEpisode(string id, string? market = null,
        string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Episode>(new()
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
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Several Episodes
    ///Get Spotify catalog information for several episodes based on their Spotify IDs.
    ///</summary>
    public async Task<Episode[]?> GetSeveralEpisodes(string[] ids, string? market = null,
        string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Episode[]>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/episodes",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids },
                new() { Name = "market", SimpleValue = market }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get User's Saved Episodes
    ///This API endpoint is in beta and could change without warning.Please share any feedback 
    ///that you have, or issues that you discover, in our developer community forum.
    ///</summary>
    public async Task<Paged<Episode>?> GetUsersSavedEpisodes(string id, int limit = 20,
        int offset = 0, string? market = null, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Paged<Episode>>(new()
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
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Save Episodes for Current User
    ///Save one or more episodes to current Spotify user's library.
    ///</summary>
    public async Task<EmptyResponse?> PutSaveEpisodesForCurrentUser(string[] ids,
        string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Put,
            EndPointUrl = "/me/episodes",
            BodyObject = new { ids = ids },
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Remove User's Saved Episodes
    ///Delete one or more episodes from current Spotify user's library.
    ///</summary>
    public async Task<EmptyResponse?> DeleteRemoveUsersSavedEpisodes(string[] ids,
        string? market = null, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Delete,
            EndPointUrl = "/me/episodes",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "market", SimpleValue = market }
            },
            BodyObject = new { ids = ids }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Check User's Saved Episodes
    ///Check if one or more episodes is already saved in the current Spotify user's library.
    ///</summary>
    public async Task<bool[]?> GetCheckUsersSavedEpisodes(string[] ids, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<bool[]>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me/episodes/contains",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);
}
