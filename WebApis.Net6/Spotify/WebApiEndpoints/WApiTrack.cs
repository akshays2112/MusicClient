using WebApis.Net6.Spotify.Models;

namespace WebApis.Net6.Spotify.WebApiEndpoints;

public static class WApiTrack
{
    ///<summary>
    ///Get Track
    ///Get Spotify catalog information for a single track identified by its unique Spotify ID.
    ///</summary>
    public static async Task<Track?> GetEpisode(string id, string? market = null,
        string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<Track>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/tracks/{id}",
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
    ///Get Several Tracks
    ///Get Spotify catalog information for multiple tracks based on their Spotify IDs.
    ///</summary>
    public static async Task<Track[]?> GetSeveralEpisodes(string[] ids, string? market = null,
        string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<Track[]>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/tracks",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids },
                new() { Name = "market", SimpleValue = market }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get User's Saved Tracks
    ///Get a list of the songs saved in the current Spotify user's 'Your Music' library.
    ///</summary>
    public static async Task<Paged<Track>?> GetUsersSavedEpisodes(int? limit = 20,
        int? offset = 0, string? market = null, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<Paged<Track>>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me/tracks",
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
    ///Save Tracks for Current User
    ///Save one or more tracks to current Spotify user's library.
    ///</summary>
    public static async Task<EmptyResponse?> PutSaveTracksForCurrentUser(string[] ids,
        string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Put,
            EndPointUrl = "/me/tracks",
            BodyObject = new { ids },
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Remove User's Saved Tracks
    ///Delete one or more tracks from current Spotify user's library.
    ///</summary>
    public static async Task<EmptyResponse?> DeleteRemoveUsersSavedTracks(string[] ids,
        string? market = null, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Delete,
            EndPointUrl = "/me/tracks",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "market", SimpleValue = market }
            },
            BodyObject = new { ids }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Check User's Saved Tracks
    ///Check if one or more tracks is already saved in the current Spotify user's library.
    ///</summary>
    public static async Task<bool[]?> GetCheckUsersSavedTracks(string[] ids, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<bool[]>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me/tracks/contains",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Tracks' Audio Features
    ///Get audio features for multiple tracks based on their Spotify IDs.
    ///</summary>
    public static async Task<AudioFeature[]?> GetTracksAudioFeatures(string[] ids, 
        string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<AudioFeature[]>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/audio-features",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Track's Audio Features
    ///Get audio feature information for a single track identified by its unique Spotify ID.
    ///</summary>
    public static async Task<AudioFeature?> GetTrackAudioFeatures(string id,
        string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<AudioFeature>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/audio-features/{id}",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
               new() { Placeholder = "{id}", SimpleValue = id }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Track's Audio Analysis
    ///Get a low-level audio analysis for a track in the Spotify catalog. The audio 
    ///analysis describes the track’s structure and musical content, including 
    ///rhythm, pitch, and timbre.
    ///</summary>
    public static async Task<AudioAnalysis?> GetTracksAudioAnalysis(string id,
        string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<AudioAnalysis>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/audio-analysis/{id}",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
               new() { Placeholder = "{id}", SimpleValue = id }
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);
}
